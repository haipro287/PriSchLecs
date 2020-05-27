<template>
    <div>
        <h1>Chào mừng đến với trang web của chúng tôi.</h1>
        <div class="card-body">
            <h3>Danh sách danh mục</h3>
            <div class="card-body">
                <a-table :columns="Columns"
                         :dataSource="Items"
                         :tableLayout="auto"
                         :scroll="{}"
                         bordered
                         :pagination="false">
                    <span slot="action" slot-scope="record">
                        <router-link :to="{path:'/category/list/' + record.id}">
                            <a-button class="btn btn-sm btn-primary mr-2">
                                <a-icon type="login" style="position: relative; bottom:3px;"/>
                                Xem thêm
                            </a-button>
                        </router-link>
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
    </div>

</template>

<script>
    import axios from 'axios';
    import moment from 'moment';
    import api from './showcategoryApi';

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
                    title: 'Tên danh mục',
                    dataIndex: 'name',
                },
                {
                    title: 'Mô tả ngắn',
                    dataIndex: 'description',
                },
                {
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
                axios.post(api.listCategory, params).then(r => {
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
            }
        }
    }
</script>

<style>
    h1 {
        position: relative;
        left: 200px;
    }
    h3 {
        position: relative;
        left: 450px;
    }
</style>
