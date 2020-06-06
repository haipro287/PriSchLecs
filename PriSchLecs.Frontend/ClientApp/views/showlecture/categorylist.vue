<template>
    <div class="card">
        <div class="card-header card-header-flex">
            <a-list :grid="{ gutter: [16,16], xs: 1, sm: 2, md: 4, lg: 4, xl: 6, xxl: 3 }"
                    :dataSource="dataOfl">
                <a-list-item slot="renderItem" slot-scope="subitem, index">
                    <router-link :to="{path:'/lecture/' + subitem.id }">
                        <a-card hoverable style="width: 300px">
                            <img slot="cover"
                                 alt="example"
                                 src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png" />
                            <a-card-meta :title="subitem.name" :description="subitem.name">
                                <a-avatar slot="avatar"
                                          src="https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png" />
                            </a-card-meta>
                        </a-card>
                    </router-link>
                </a-list-item>
            </a-list>
        </div>
        <div class="card-body">
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

</template>
<script>
    import axios from 'axios';
    import moment from 'moment';
    import api from './showlectureApi';

    export default {
        created() {
            this.CreateFormSearch();
            this.LoadData();
        },
        mounted() {
            this.LoadData();
        },
        data() {
            return {
                loading: false,
                Model: {
                    name: '',
                    description: "",
                    id: 0,
                },
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
                    PageSize: 6
                },
                Sort: {
                    Predicate: '',
                    Reverse: true
                },
                Search: {
                    PredicateObject: {

                    }
                },
                PageSizeOptions: ['6', '12', '24', '48', '96', '200', '500', '1000'],
            }
        },
        watch: {
            '$route': 'LoadData'
        },
        methods: {
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
            ChangePageSize(current, size) {
                this.Pagination.PageSize = size;
                this.LoadData();
            },
            ChangePage(page, pageSize) {
                this.LoadData();
            },
            /* các hàm hiển thị danh sách bài giảng trong danh mục */
            GetParam() {
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
            LoadData() {
                this.IsLoading = true;
                var params = this.GetParam();
                console.log(params);
                axios.post(api.getLectureByCategoryId, params).then(r => {
                    this.IsLoading = false;
                    this.LoadDataSuccess(r);
                }).catch(error => {
                    this.IsLoading = false;
                    this.$message.error('Không thể kết nối tới máy chủ', 3);
                    console.log(error);
                });
            },
            LoadDataSuccess(r) {
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
            
        },
        components: {

        }
    }
</script>
