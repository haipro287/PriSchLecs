<template>
    <div>
        <h5>Tạo / cập nhật danh mục</h5>
        <div class="row">
            <a-tabs defaultActiveKey="1">
                <a-tab-pane tab="Thông tin danh mục" key="1"><!--tab sửa danh mục-->
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
                                <a-textarea placeholder="Mô tả ngắn"
                                            v-model="Model.description"
                                            v-decorator="['description', { rules: [{ required: true, message: 'Vui lòng nhập mô tả ngắn danh mục!' }] }]"
                                            :autosize="{ minRows: 3, maxRows: 6 }" />
                            </a-form-item>
                        </div>
                    </a-form>
                </a-tab-pane>
                <a-tab-pane :disabled="$route.params.id==0" tab="Tùy chọn bài giảng" key="2"><!--tab thêm bài giảng-->
                    <div class="card">
                        <div class="card-header card-header-flex">
                            <div class="flex-column justify-content-center">
                                <a-button type="primary" @click="showModal" icon="plus">
                                    Thêm bài giảng
                                </a-button>
                                <a-modal title="Chọn bài giảng"
                                         :visible="visible"
                                         @ok="handleOk"
                                         @cancel="handleCancel" width="1280px">
                                    <a-row><!--bảng danh sách các bài giảng để thêm-->
                                        <b-card class="mt-3" footer-tag="footer">
                                            <a-form layout="vertical" :form="FrmSearch" @submit="FrmSearchSubmit">
                                                <div class="row">
                                                    <div class="col-md-6 col-sm-12 col-lg-3">
                                                        <a-form-item label="Từ khóa" class="mb-0">
                                                            <a-input v-decorator="['Keyword']"
                                                                     placeholder="Từ khóa..." />
                                                        </a-form-item>
                                                    </div>
                                                    <div class="col-md-6 col-sm-12 col-lg-3">
                                                        <a-form-item label="Ngày tạo" class="mb-0">
                                                            <a-range-picker :ranges="Ranges"
                                                                            v-decorator="['CreatedTime']"
                                                                            :placeholder="['Từ ngày', 'Đến ngày']" />
                                                        </a-form-item>
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-top:10px;">
                                                    <div class="col-lg-12">
                                                        <a-button type="primary" html-type="submit" icon="search">
                                                            Tìm kiếm
                                                        </a-button>
                                                    </div>
                                                </div>
                                            </a-form>
                                        </b-card>
                                        <div class="card">
                                            <div class="card-header card-header-flex">
                                                <div class="flex-column justify-content-center">
                                                    Danh sách bài giảng
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
                                                        <a-button class="btn btn-sm btn-primary mr-2" type="primary" icon="plus" @click="CreateConnect(record.id)">
                                                            Thêm
                                                        </a-button>
                                                    </span>
                                                    <span slot="callForPrice" slot-scope="record">
                                                        {{record.toString()}}
                                                    </span>
                                                </a-table>
                                                <a-pagination class="mt-2 ant-pagination ant-table-pagination"
                                                              :total="Pagination.Total"
                                                              :pageSize="Pagination.PageSize"
                                                              :pageSizeOptions="PageSizeOptions"
                                                              v-model="Pagination.PageIndex"
                                                              showSizeChanger
                                                              showQuickJumper
                                                              :showTotal="(total, range) => `Từ ${range[0]} đến ${range[1]} của ${total} bản ghi`"
                                                              @change="ChangePage"
                                                              @showSizeChange="ChangePageSize"
                                                              :locale="{items_per_page:' / trang',
                                                                      jump_to:'Đến',
                                                                      jump_to_confirm:'xác nhận',
                                                                      next_3:'Đến 3 Trang Kế',
                                                                      next_5:'Đến 5 Trang Kế',
                                                                      next_page:'Trang Kế',
                                                                      page:'',
                                                                      prev_3:'Về 3 Trang Trước',
                                                                      prev_5:'Về 5 Trang Trước',
                                                                      prev_page:'Trang Trước',
                                                                      }">
                                                </a-pagination>
                                            </div>
                                        </div>
                                    </a-row>
                                </a-modal>
                            </div>
                        </div>
                        <div class="card-body" style="padding:16px;">
                            <a-row>
                                <b-card class="mt-3" footer-tag="footer"><!--bảng danh sách các bài giảng có sẵn trong danh mục-->
                                    <a-form layout="vertical" :form="FrmSearch" @submit="FrmSearchSubmit">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-12 col-lg-3">
                                                <a-form-item label="Từ khóa" class="mb-0">
                                                    <a-input v-decorator="['Keyword']"
                                                             placeholder="Từ khóa..." />
                                                </a-form-item>
                                            </div>
                                            <div class="col-md-6 col-sm-12 col-lg-3">
                                                <a-form-item label="Ngày tạo" class="mb-0">
                                                    <a-range-picker :ranges="Ranges"
                                                                    v-decorator="['CreatedTime']"
                                                                    :placeholder="['Từ ngày', 'Đến ngày']" />
                                                </a-form-item>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top:10px;">
                                            <div class="col-lg-12">
                                                <a-button type="primary" html-type="submit" icon="search">
                                                    Tìm kiếm
                                                </a-button>
                                            </div>
                                        </div>
                                    </a-form>
                                </b-card>
                                <div class="card">
                                    <div class="card-header card-header-flex">
                                        <div class="flex-column justify-content-center">
                                            Danh sách bài giảng
                                        </div>
                                    </div>
                                    <div class="card-body" style="padding:16px;">
                                        <a-table :columns="Columns"
                                                 :dataSource="dataOfl"
                                                 :tableLayout="auto"
                                                 :scroll="{}"
                                                 bordered
                                                 :pagination="false">
                                            <span slot="action" slot-scope="record">
                                                <a-button class="btn btn-sm btn-danger mr-2" @click="DeleteConnect(record.id)">
                                                    <a-icon type="delete" />
                                                    Xóa
                                                </a-button>

                                            </span>
                                            <span slot="callForPrice" slot-scope="record">
                                                {{record.toString()}}
                                            </span>
                                        </a-table>
                                        <a-pagination class="mt-2 ant-pagination ant-table-pagination"
                                                      :total="Pagination.Total"
                                                      :pageSize="Pagination.PageSize"
                                                      :pageSizeOptions="PageSizeOptions"
                                                      v-model="Pagination.PageIndex"
                                                      showSizeChanger
                                                      showQuickJumper
                                                      :showTotal="(total, range) => `Từ ${range[0]} đến ${range[1]} của ${total} bản ghi`"
                                                      @change="ChangePage"
                                                      @showSizeChange="ChangePageSize"
                                                      :locale="{items_per_page:' / trang',
                                                                      jump_to:'Đến',
                                                                      jump_to_confirm:'xác nhận',
                                                                      next_3:'Đến 3 Trang Kế',
                                                                      next_5:'Đến 5 Trang Kế',
                                                                      next_page:'Trang Kế',
                                                                      page:'',
                                                                      prev_3:'Về 3 Trang Trước',
                                                                      prev_5:'Về 5 Trang Trước',
                                                                      prev_page:'Trang Trước',
                                                                      }">
                                        </a-pagination>
                                    </div>
                                </div>
                            </a-row>
                        </div>
                    </div>
                </a-tab-pane>
            </a-tabs>
        </div>

    </div>
</template>
<script>
    import axios from 'axios';
    import CKEditor from '@ckeditor/ckeditor5-build-classic';
    import moment from 'moment';
    import api from './categoryApi';

    export default {
        created() {
            axios.get(api.getById + this.$route.params.id).then(r => {
                this.Model.name = r.data.name;
                this.Model.description = r.data.description;
                this.Model.id = this.$route.params.id;
            }).then(() => {
                this.CreateForm();
            });
            this.CreateFormSearch();
        },
        mounted() {
            this.LoadData();
            this.LoadLOCData();
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
                visible: false,

                dataOfl: [],

                FrmSearch: null,
                IsLoading: false,
                Ranges: { 'Hôm nay': [moment(), moment()], 'Hôm qua': [moment().add('days', -1), moment().add('days', -1)], 'Tuần này': [moment().startOf('isoWeek'), moment().endOf('isoWeek')], 'Tuần trước': [moment().add(-1, 'weeks').startOf('isoWeek'), moment().add(-1, 'weeks').endOf('isoWeek')], 'Tháng này': [moment().startOf('month'), moment().endOf('month')], 'Tháng trước': [moment().subtract(1, 'months').startOf('month'), moment().subtract(1, 'months').endOf('month')] },
                Pagination: {
                    Total: 0,
                    PageIndex: 1,
                    PageSize: 5
                },
                Sort: {
                    Predicate: '',
                    Reverse: true
                },
                Search: {
                    PredicateObject: {

                    }
                },
                Items: [],
                PageSizeOptions: ['5', '15', '25', '50', '100', '200', '500', '1000'],
                Columns: [{
                    title: 'ID',
                    dataIndex: 'id',
                }, {
                    title: 'Tên bài giảng',
                    dataIndex: 'name',
                }, {
                    title: 'Mô tả ngắn',
                    dataIndex: 'description',
                }, {
                    title: 'Số lượt xem',
                    dataIndex: 'views'
                }, {
                    title: 'Số lượt tải',
                    dataIndex: 'downloads'
                }, {
                    title: 'Số bình luận',
                    dataIndex: 'comments'
                }, {
                    title: 'Ngày tạo',
                    dataIndex: 'createdTimeDisplay',
                }, {
                    title: 'Ngày cập nhật',
                    dataIndex: 'updatedTimeDisplay',
                }, {
                    title: 'Action',
                    scopedSlots: { customRender: 'action' },
                    width: 240
                },
                ]
            }
        },
        methods: {
            /* các hàm để bật tắt modal */
            showModal() {
                this.visible = true;
            },
            handleOk(e) {
                this.visible = false;
            },
            handleCancel(e) {
                console.log('Clicked cancel button');
                this.visible = false;
            },
            /* các hàm sửa danh mục và hiển thị danh sách các bài giảng để thêm */
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
                /*this.GetModel();*/
                axios.post(api.createOrUpdate, this.Model).then(r => {
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
                /*this.GetModel();*/
                axios.post(api.createOrUpdate, this.Model).then(r => {
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
                    axios.get(api.getById + this.$route.params.id).then(r => {
                        this.Model.name = r.data.name;
                        this.Model.description = r.data.description;
                        this.Model.id = this.$route.params.id;
                    })
                    this.$message.success('Reset thành công', 3);
                }     
            },

            moment,
            CreateFormSearch() {
                let options = {
                    mapPropsToFields: () => {
                        return {
                            Keyword: this.$form.createFormField({ value: '', }),
                            CreatedTime: this.$form.createFormField({ value: [] }),
                        };
                    }
                }
                this.FrmSearch = this.$form.createForm(this, options);
            },
            FrmSearchSubmit(e) {
                e.preventDefault();
                this.Pagination.PageIndex = 1;
                this.LoadData();
            },
            GetSearchParam() {
                return {
                    Pagination: this.Pagination,
                    Sort: this.Sort,
                    Search: {
                        PredicateObject: {
                            Keyword: this.FrmSearch.getFieldValue('Keyword'),
                            CreateStart: this.FrmSearch.getFieldValue('CreatedTime').length > 0 ? moment(this.FrmSearch.getFieldValue('CreatedTime')[0]).format() : null,
                            CreateEnd: this.FrmSearch.getFieldValue('CreatedTime').length > 0 ? moment(this.FrmSearch.getFieldValue('CreatedTime')[1]).format() : null,
                        }
                    }
                }
            },
            LoadData() {
                this.IsLoading = true;
                var params = this.GetSearchParam();
                console.log(params);
                axios.post(api.listLecture, params).then(r => {
                    this.IsLoading = false;
                    this.LoadDataSuccess(r);
                }).catch(error => {
                    this.IsLoading = false;
                    this.$message.error('Không thể kết nối tới máy chủ', 3);
                    console.log(error);
                });
            },
            LoadDataSuccess(r) {
                this.Items = [];
                console.log(r);
                if (r.data.items) {
                    this.Pagination.Total = r.data.totalRecord;
                    this.Items = r.data.items;
                    let key = 1;
                    this.Items.forEach(item => {
                        item.key = (this.Pagination.PageIndex - 1) * this.Pagination.PageSize + key;
                        key = key + 1;
                    });
                }
                else {
                    this.IsLoading = false;
                    this.$message.error('Không thể kết nối tới hệ thống', 3);
                }
            },
            DeleteProduct(id) {
                if (confirm("Có thật sự muốn xóa?")) {
                    axios.delete(api.delete + id).then(response => {
                        console.log(response);
                        if (response.data.result == 1) {
                            this.LoadData();
                        }
                    });
                }
            },
            ChangePageSize(current, size) {
                this.Pagination.PageSize = size;
                this.LoadData();
            },
            ChangePage(page, pageSize) {
                this.LoadData();
            },
            /* các hàm hiển thị danh sách bài giảng trong danh mục */
            GetLOCParam() {
                return {
                    Pagination: this.Pagination,
                    Sort: this.Sort,
                    Search: {
                        PredicateObject: {
                            CategoryId: this.$route.params.id,
                            Keyword: this.FrmSearch.getFieldValue('Keyword'),
                            CreateStart: this.FrmSearch.getFieldValue('CreatedTime').length > 0 ? moment(this.FrmSearch.getFieldValue('CreatedTime')[0]).format() : null,
                            CreateEnd: this.FrmSearch.getFieldValue('CreatedTime').length > 0 ? moment(this.FrmSearch.getFieldValue('CreatedTime')[1]).format() : null,
                        }
                    }
                }
            },
            LoadLOCData() {
                this.IsLoading = true;
                var params = this.GetLOCParam();
                console.log(params);
                axios.post(api.getLectureByCategoryId, params).then(r => {
                    this.IsLoading = false;
                    this.LoadLOCDataSuccess(r);
                }).catch(error => {
                    this.IsLoading = false;
                    this.$message.error('Không thể kết nối tới máy chủ', 3);
                    console.log(error);
                });
            },
            LoadLOCDataSuccess(r) {
                this.dataOfl = [];
                console.log(r);
                if (r.data.items) {
                    this.Pagination.Total = r.data.totalRecord;
                    this.dataOfl = r.data.items;
                    let key = 1;
                    this.dataOfl.forEach(item => {
                        item.key = (this.Pagination.PageIndex - 1) * this.Pagination.PageSize + key;
                        key = key + 1;
                    });
                }
                else {
                    this.IsLoading = false;
                    this.$message.error('Không thể kết nối tới hệ thống', 3);
                }
            },
            /* các hàm tạo xóa liên kết*/
            CreateConnect(id) {
                var param = {
                    categoryId: this.$route.params.id,
                    lectureId: id,
                };
                if (confirm("Thêm bài giảng " + id + "?")) {
                    axios.post(api.createCategoryLecture, param).then(r => {
                        this.LoadLOCData();
                    }).catch(error => {
                        this.$message.error('Lỗi khi thêm liên kết', 3);
                        console.log(error);
                    });
                }
            },
            DeleteConnect(id) {
                if (confirm("Có thật sự muốn xóa liên kết?")) {
                    axios.delete(api.deleteCategoryLecture + this.$route.params.id + '-' + id).then(response => {
                        console.log(response);
                        if (response.data.result == 1) {
                            this.LoadLOCData();
                        }
                    });
                }
            },
        },
        components: {

        }
    }
</script>
