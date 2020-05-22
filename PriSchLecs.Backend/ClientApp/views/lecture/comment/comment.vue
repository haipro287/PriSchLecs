<template>
    <a-spin tip="Đang tải..." :spinning="IsLoading">
        <a-row>

            <div class="air__utils__heading">
                <h5>Quản lý sản phẩm</h5>
            </div>
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
                            <a-button class="btn btn-primary" type="primary" html-type="submit" icon="search">
                                Tìm kiếm
                            </a-button>
                        </div>
                    </div>
                </a-form>

            </b-card>
            <div class="card">
                <div class="card-header card-header-flex">
                    <div class="d-flex flex-column justify-content-center">
                        <a-button class="btn btn-sm btn-primary mr-2" icon="plus" @click="showModal(null)">
                            Tạo bình luận
                        </a-button>
                    </div>
                </div>
                <div class="card-body" style="padding:16px;">
                    <a-table :columns="Columns"
                             :dataSource="Items"
                             :pagination="false">
                        <span slot="act" slot-scope="record">
                            <a-button class="btn btn-sm btn-danger mr-2" @click="DeleteProduct(record.id)">
                                <a-icon type="delete" />
                                Xóa
                            </a-button>
                            <a-button class="btn btn-sm btn-primary mr-2" @click="showModal(record.id)">
                                <a-icon type="retweet" />
                                Trả lời
                            </a-button>
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

                    <a-modal title="Trả lời bình luận"
                             :visible="visible"
                             :width="1000"
                             @ok="handleOk"
                             :confirmLoading="false"
                             @cancel="handleCancel">
                        <div>
                            <a-input v-model="replyContent"></a-input>
                            <a-button class="btn btn-sm btn-primary mr-2" @click="reply()">
                                <a-icon type="retweet" />
                                Trả lời
                            </a-button>
                        </div>
                    </a-modal>
                </div>
            </div>
        </a-row>
    </a-spin>


</template>

<script>
    import axios from 'axios';
    import commentApi from './commentApi';
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
                LectureId: null,
                ParentId: null,
                Items: [],
                PageSizeOptions: ['5', '15', '25', '50', '100', '200', '500', '1000'],
                Columns: [
                    {
                        title: 'ID',
                        dataIndex: 'id',
                        key: 'id'
                    },
                    {
                        title: 'người dùng',
                        dataIndex: 'username',
                        key: 'username'
                    }, {
                        title: 'Email',
                        dataIndex: 'email',
                        key: 'email'
                    },
                    {
                        title: 'Nội dung',
                        dataIndex: 'content',
                        key: 'content'
                    },
                    {
                        title: 'Ngày tạo',

                        dataIndex: 'createdTimeDisplay',
                        key: 'createdTimeDisplay'
                    },
                    {
                        title: 'Ngày cập nhật',
                        dataIndex: 'updatedTimeDisplay',
                        key: 'updatedTimeDisplay'
                    },
                    {
                        title: 'Action',
                        scopedSlots: { customRender: 'act' },
                    },
                ],
                replyContent: null,
                visible: false,
                parentOfReply: null
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
                            LectureId: this.$route.params.id,
                            ParentId: this.ParentId
                        }
                    },

                }
            },
            LoadData() {
                this.IsLoading = true;
                this.ParentId = null;
                var params = this.GetSearchParam();
                console.log(params);
                axios.post(commentApi.list, params).then(r => {
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
                    this.Items.forEach(item => {
                        item.key = item.id;
                        this.ParentId = item.id;
                        let params = this.GetSearchParam();
                        axios.post(commentApi.list, params).then(r => {
                            console.log(r.data.items);
                            item.children = r.data.items;
                            item.children.forEach(child => {
                                child.key = child.id;
                            })
                        });
                    });
                }
                else {
                    this.IsLoading = false;
                    this.$message.error('Không thể kết nối tới hệ thống', 3);
                }
            },
            DeleteProduct(id) {
                if (confirm("Có thật sự muốn xóa?")) {
                    axios.delete(commentApi.delete + id).then(response => {
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
            reply(id) {
                axios.post(commentApi.comment, {
                    content: this.replyContent,
                    username: "Admin",
                    email: "cnpm@vnu.edu.vn",
                    lectureId: this.$route.params.id,
                    parentId: this.parentOfReply
                }).then(() => {
                    this.showModal(null);
                    this.$message.success('đăng bình luận thành công!', 3);
                })
            },
            showModal(id) {
                this.visible = true;
                this.parentOfReply = id;
            },
            handleOk() {
                this.visible = false;
                this.LoadData();
            },
            handleCancel() {
                this.visible = false;
                this.LoadData();
            },
        }
    }
</script>

<style>
</style>
