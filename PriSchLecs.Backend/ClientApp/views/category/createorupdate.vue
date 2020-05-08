<template>
    <div>
        <h5>Tạo / cập nhật danh mục</h5>
        <div class="row">
            <a-tabs defaultActiveKey="1">
                <a-tab-pane tab="Thông tin danh mục" key="1">
                    <a-form layout="vertical">
                        <div class="col-lg-12 text-right">
                            <a-button type="primary" html-type="button" icon="save" @click="SaveAndFinish">Lưu lại</a-button>
                            <a-button type="primary" html-type="button" icon="save" @click="Save">Lưu và sửa tiếp</a-button>
                            <a-button type="danger" html-type="button" icon="save" @click="Reset">Reset thông tin</a-button>
                        </div>
                        <div class="col">
                            <a-form-item label="Tên danh mục" class="mb-2">
                                <a-input v-model="Model.name" 
                                         v-decorator="['Name', { rules: [{ required: true, message: 'Vui lòng nhập tên danh mục!' }] }]" />
                            </a-form-item>
                        </div>
                        <div class="col">
                            <a-form-item label="Mô tả ngắn" class="mb-2">
                                <!--<a-input v-decorator="['shortdescription', { rules: [{ required: true, message: 'Vui lòng nhập tên bài giảng!' }] }]" />-->
                                <a-textarea placeholder="Mô tả ngắn"
                                            v-model="Model.description"
                                            v-decorator="['description', { rules: [{ required: true, message: 'Vui lòng nhập mô tả ngắn danh mục!' }] }]"
                                            :autosize="{ minRows: 3, maxRows: 6 }" />
                            </a-form-item>
                        </div>
                    </a-form>
                </a-tab-pane>
                <a-tab-pane v-if="$route.params.id!=0" tab="Tùy chọn bài giảng" key="2">
                    <div class="card">
                        <div class="card-header card-header-flex">
                            <div class="flex-column justify-content-center">
                                <router-link to="/category/addlecture"> <!--thêm liên kết bài giảng/danh mục-->
                                    <a-button type="primary" icon="plus">
                                        Thêm bài giảng
                                    </a-button>
                                </router-link>
                            </div>
                        </div>
                        <div class="card-body" style="padding:16px;">
                            <a-table :columns="Columns"
                                     :dataSource="Items"
                                     :tableLayout="auto"
                                     :scroll="{}"
                                     bordered
                                     :pagination="false">
                                <span slot="action" slot-scope="record">
                                    <a-button class="btn btn-sm btn-danger mr-2" @click="DeleteProduct(record.id)"> <!--cái này chỉ để xóa bài giảng, cần phải sửa để xóa liên kết api-->
                                        <a-icon type="delete" />
                                        Xóa
                                    </a-button>
                                </span>
                            </a-table>

                        </div>
                    </div>
                </a-tab-pane>
            </a-tabs>
        </div>

    </div>
</template>
<script>
    import Axios from 'axios';
    import CKEditor from '@ckeditor/ckeditor5-build-classic';
    export default {
        created() {
            Axios.get("https://localhost:44356/api/Category/GetById/" + this.$route.params.id).then(r => {
                this.Model.name = r.data.name;
                this.Model.description = r.data.description;
                this.Model.id = this.$route.params.id;
            }).then(() => {
                this.CreateForm();
            });
        },
        mounted() {

        },
        data() {
            return {
                Model: {
                    name: '',
                    description: "",
                    id: 0,
                },
                editor: CKEditor,
                editorConfig: {

                },
            }
        },
        methods: {
            CreateForm() {
                let options = {
                    mapPropsToFields: () => {
                        return {
                            name: this.$form.createFormField({ value: this.Model.name, }),
                            description: this.$form.createFormField({ value: this.Model.description, }),
                            id: this.$form.createFormField({ value: this.Model.id, }),

                        };
                    }
                }
                /*this.FrmProduct = this.$form.createForm(this, options);*/
            },
            GetModel() {   /*đoạn này chưa hiểu để làm gì*/
                this.Model.Name = this.FrmProduct.getFieldValue('Name');
                this.Model.ShortDescription = this.FrmProduct.getFieldValue('ShortDescription');
                this.Model.Sku = this.FrmProduct.getFieldValue('Sku');
                this.Model.Price = this.FrmProduct.getFieldValue('Price');
                this.Model.OldPrice = this.FrmProduct.getFieldValue('OldPrice');
                this.Model.CallForPrice = this.FrmProduct.getFieldValue('CallForPrice');
                this.Model.Id = this.$route.params.id;
            },
            async SaveAndFinish() {
                /*this.GetModel();*/      /*cần sửa*/
                Axios.post("https://localhost:44356/api/Category/createorupdate/", this.Model).then(r => {
                    if (r.data.result != 1) {
                        this.$message.error(r.data.message);
                    }
                    else {
                        this.$message.success('Lưu dữ liệu thành công', 3);
                        this.$router.replace("/category/list");
                    }
                }).catch(error => {
                    this.$message.error('Không thể kết nối tới máy chủ', 3);
                    console.log(error);
                });
            },
            Save() {
                /*this.GetModel();*/  /*cần sửa*/
                Axios.post("https://localhost:44356/api/Category/createorupdate/", this.Model).then(r => {
                    if (r.data.result != 1) {
                        this.$message.error(r.data.message);
                    }
                    else {
                        this.$message.success('Lưu dữ liệu thành công!', 3);
                        this.$router.replace("/category/createorupdate/" + r.data.id);
                    }
                }).catch(error => {
                    this.$message.error('Đã xảy ra lỗi!', 3);
                    console.log(error);
                });
            },
            Reset() {
                if (confirm("Có thực sự muốn reset?")) {
                    Axios.get("https://localhost:44356/api/category/getbyid/" + this.$route.params.id).then(r => {
                        this.Model.name = r.data.name;
                        this.Model.description = r.data.description;
                        this.Model.id = this.$route.params.id;
                    })
                    this.$message.success('Reset thành công', 3);
                }     
            }
        },
        components: {

        }
    }
</script>
