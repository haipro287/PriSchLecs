<template>
    <a-row>
        <h1>Chào mừng đến với trang web của chúng tôi.</h1>
        <b-card class="mt-3" footer-tag="footer">
            <a-form layout="form" :form="FrmSearch" @submit="FrmSearchSubmit">

                <a-form-item label="Tìm kiếm bài giảng" class="mb-0">
                    <a-input v-decorator="['Keyword']"
                             placeholder="Từ khóa..." />
                </a-form-item>
               
                <div class="row" style="margin-top:10px; position: relative; left: 600px;" @click="GetId">
                    <router-link :to="{path: '/lecture/ + GetId.ID'}">
                        <div class="col-lg-12">
                            <a-button type="primary" html-type="submit" icon="search" >
                                Tìm kiếm
                            </a-button>
                        </div>
                    </router-link>
                </div>
            </a-form>
        </b-card>
    </a-row>


</template>

<script>
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
                Sort: {
                    Predicate: '',
                    Reverse: true
                },
                Search: {
                    PredicateObject: {
                    }
                },
                Items: []
            }
        },
        methods: {
            CreateFormSearch() {
                let options = {
                    mapPropsToFields: () => {
                        return {
                            Keyword: this.$form.createFormField({ value: '', }),
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
                            Keyword: this.FrmSearch.getFieldValue('Keyword')
                        }
                    }
                }
            },
            LoadData() {
                this.IsLoading = true;
                var params = this.GetSearchParam();
                console.log(params);
                axios.post(api.searchLecture, params).then(r => {
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
            GetId() {
                return {
                    ID: 27
                }
            }
        }
    }
</script>

<style>
    h1 {
        position: relative;
        left: 200px;
    }
</style>
