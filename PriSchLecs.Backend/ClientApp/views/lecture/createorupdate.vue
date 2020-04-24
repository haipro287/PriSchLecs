<template>
    <div>
        <h5>Tạo / cập nhật bài giảng</h5>
        <div class="row">
            <a-form layout="vertical" :form="FrmProduct">
                <div class="col-lg-12 text-right">
                    <a-button type="primary" html-type="button" icon="save" @click="SaveAndFinish">Lưu lại</a-button>
                    <a-button type="primary" html-type="button" icon="save" @click="Save">Lưu và sửa tiếp</a-button>
                    <a-button type="danger" html-type="button" icon="save" @click="Reset">Reset thông tin</a-button>
                </div>
                <div class="col">
                    <a-form-item label="Tên bài giảng" class="mb-2">
                        <a-input v-decorator="['Name', { rules: [{ required: true, message: 'Vui lòng nhập tên bài giảng!' }] }]" />
                    </a-form-item>
                </div>
                <div class="col">
                    <a-form-item label="ngắn" class="mb-2">
                        <!--<a-input v-decorator="['shortdescription', { rules: [{ required: true, message: 'Vui lòng nhập tên bài giảng!' }] }]" />-->
                        <a-textarea placeholder="Mô tả ngắn"
                                    v-decorator="['description', { rules: [{ required: true, message: 'Vui lòng nhập mô tả ngắn bài giảng!' }] }]"
                                    :autosize="{ minRows: 3, maxRows: 6 }" />
                    </a-form-item>
                    <a-form-item label="Content">
                        <ckeditor :editor="editor" v-model="Model.Content" :config="editorConfig"></ckeditor>
                    </a-form-item>
                </div>
            </a-form>
        </div>
    </div>
</template>
<script>
    import Axios from 'axios';
    import CKEditor from '@ckeditor/ckeditor5-build-classic';
    export default {
        created() {
            Axios.get(ProductApi.getById + this.$route.params.id).then(r => {
                this.Model.Name = r.data.name;
                this.Model.ShortDescription = r.data.shortDescription;
                this.Model.Description = r.data.description;
                this.Model.Sku = r.data.sku;
                this.Model.Price = r.data.price;
                this.Model.OldPrice = r.data.oldPrice;
                this.Model.CallForPrice = r.data.callForPrice;
                this.Model.Id = this.$route.params.id;
            }).then(() => {
                this.CreateForm();
            });
        },
        mounted() {

        },
        data() {
            return {
                FrmProduct: null,
                Model: {
                    Name: '',
                    ShortDescription: "Short Description",
                    Description: "",
                    Sku: '',
                    Price: 0,
                    OldPrice: 0,
                    CallForPrice: false,
                    Status: 1,
                    Id: 0,
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
                            Name: this.$form.createFormField({ value: this.Model.Name, }),
                            ShortDescription: this.$form.createFormField({ value: this.Model.ShortDescription }),
                            Sku: this.$form.createFormField({ value: this.Model.Sku }),
                            Price: this.$form.createFormField({ value: this.Model.Price }),
                            OldPrice: this.$form.createFormField({ value: this.Model.OldPrice }),
                            CallForPrice: this.$form.createFormField({ value: this.Model.CallForPrice }),
                        };
                    }
                }
                this.FrmProduct = this.$form.createForm(this, options);
            },
            GetModel() {
                this.Model.Name = this.FrmProduct.getFieldValue('Name');
                this.Model.ShortDescription = this.FrmProduct.getFieldValue('ShortDescription');
                this.Model.Sku = this.FrmProduct.getFieldValue('Sku');
                this.Model.Price = this.FrmProduct.getFieldValue('Price');
                this.Model.OldPrice = this.FrmProduct.getFieldValue('OldPrice');
                this.Model.CallForPrice = this.FrmProduct.getFieldValue('CallForPrice');
                this.Model.Id = this.$route.params.id;
            },
            async SaveAndFinish() {
                this.FrmProduct.validateFieldsAndScroll((errors, values) => {
                    if (!errors) {
                        this.GetModel();
                        Axios.post(ProductApi.createOrUpdate, this.Model).then(r => {
                            if (r.data.result != 1) {
                                this.$message.error(r.data.message);
                            }
                            else {
                                this.$message.success('Lưu dữ liệu thành công', 3);
                                this.$router.replace("/product");
                            }
                        }).catch(error => {
                            this.$message.error('Không thể kết nối tới máy chủ', 3);
                            console.log(error);
                        });
                    }
                });
            },
            Save() {
                this.FrmProduct.validateFieldsAndScroll((errors, values) => {
                    if (!errors) {
                        this.GetModel();
                        Axios.post(ProductApi.createOrUpdate, this.Model).then(r => {
                            if (r.data.result != 1) {
                                this.$message.error(r.data.message);
                            }
                            else {
                                this.$message.success('Lưu dữ liệu thành công!', 3);
                                this.$router.replace("/product/createorupdate/" + r.data.id);
                            }
                        }).catch(error => {
                            this.$message.error('Đã xảy ra lỗi!', 3);
                            console.log(error);
                        });
                    }
                });
            },
            Reset() {
                Axios.get(ProductApi.getById + this.$route.params.id).then(r => {
                    this.FrmProduct.setFieldsValue({
                        Name: r.data.name,
                        ShortDescription: r.data.shortDescription,
                        Sku: r.data.sku,
                        Price: r.data.price,
                        OldPrice: r.data.oldPrice,
                        CallForPrice: r.data.callForPrice,
                    })
                    this.Model.CallForPrice = r.data.callForPrice;
                    this.$message.success('Reset thành công', 3);
                })
            },
            OnChange(e) {
                this.Model.CallForPrice = !this.Model.CallForPrice;
            }
        },
        components: {

        }
    }
</script>
