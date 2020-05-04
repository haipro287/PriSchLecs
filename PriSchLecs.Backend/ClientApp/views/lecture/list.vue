<template>
    <!--<a-spin tip="Đang tải..." :spinning="IsLoading">-->
    <a-row>
        <h5>Quản lý bài giảng</h5>
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
                    <!--d-flex-->
                    <router-link to="/lecture/createorupdate/0">
                        <a-button type="primary" icon="plus">
                            Tạo bài giảng
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
                         :pagination="false"
                         >
                    <span slot="action" slot-scope="record">
                        <router-link :to="{path:'/lecture/createorupdate/' + record.id}">
                            <a-button class="btn btn-sm btn-primary mr-2">
                                <a-icon type="edit" />
                                Sửa
                            </a-button>
                        </router-link>
                        <a-button class="btn btn-sm btn-danger mr-2" @click="DeleteProduct(record.id)">
                            <a-icon type="delete" />
                            Xóa
                        </a-button>
                        <a-button class="btn btn-sm mr-2" style="border:#4CAF50; background-color:#4CAF50; color:#fff">
                            <a-icon type="folder-add" />
                            Thêm danh mục
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
    <!--</a-spin>-->
</template>

<script>
    import axios from 'axios';
    import moment from 'moment';
    export default {
        created() {
            this.CreateFormSearch();

        },
        mounted() {
            this.LoadData();
        },
        data() {
            return {
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
                    width: 180
                },
                ]
            }
        },
        methods: {
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
            //Events
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
                axios.post("https://localhost:44356/api/Lecture/Search/", params).then(r => {
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
                    axios.delete("https://localhost:44356/api/Lecture/Delete/" + id).then(response => {
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
            }
        }
    }
</script>

<style>
</style>
