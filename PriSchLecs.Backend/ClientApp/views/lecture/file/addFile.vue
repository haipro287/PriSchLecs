<template>
    <a-row>
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
            <div class="card-body" style="padding:16px;">
                <div class="air__utils__scrollTable">
                    <a-table :columns="Columns"
                             :dataSource="Items"
                             :scroll="{ x: '100%' }"
                             bordered
                             :pagination="false">
                        <span slot="action" slot-scope="record">
                            <a-button class="btn btn-sm btn-primary mr-2" @click="AddFile(record.id)" icon="plus">
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
        </div>

    </a-row>
</template>

<script>
    import axios from 'axios';
    import moment from 'moment';
    import lectureFileApi from './lectureFileApi';
    import fileApi from '../../file/api';
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
                Columns: [
                    {
                        title: 'ID',
                        dataIndex: 'id',
                    },
                    {
                        title: 'Tên sản phẩm',
                        dataIndex: 'name',
                    },
                    {
                        title: 'SKU',
                        dataIndex: 'sku',
                    },
                    {
                        title: 'Giá',
                        dataIndex: 'price',
                    },
                    {
                        title: 'Gọi để biết giá',
                        dataIndex: 'callForPrice',
                        scopedSlots: { customRender: 'callForPrice' }
                    },
                    {
                        title: 'Mô tả ngắn',
                        dataIndex: 'shortDescription',
                    },
                    {
                        title: 'Ngày tạo',
                        dataIndex: 'createdTimeDisplay',
                    },
                    {
                        title: 'Ngày cập nhật',
                        dataIndex: 'updatedTimeDisplay',
                    },
                    {
                        title: 'Action',
                        scopedSlots: { customRender: 'action' },
                        width: 50,
                    },
                ],
                addForm: {
                    lectureId: this.$route.params.id,
                    fileId: null,
                    id: 0,
                }
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
                axios.post(fileApi.search, params).then(r => {
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
            AddFile(id) {
                this.addForm.fileId = id;
                axios.post(lectureFileApi.create, this.addForm).then(response => {
                    console.log(response);
                    if (response.data.result != 1) {
                        this.$message.error(response.data.message);
                    }
                    else {
                        this.$message.success("Thêm tệp thành công!");
                        this.LoadData();
                    }
                }).catch(error => {
                    this.$message.error(error);
                });
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
