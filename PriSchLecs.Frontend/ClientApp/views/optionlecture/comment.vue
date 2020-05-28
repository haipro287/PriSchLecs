<template>
    <a-spin tip="Đang tải..." :spinning="IsLoading">
        <a-row>
            <div>
                <a-button class="btn btn-sm btn-primary mr-2" icon="plus" @click="showModal()">
                    Tạo bình luận
                </a-button>
                <a-modal title="Vui lòng điền thông tin để thêm bình luận"
                         :visible="visible"
                         @ok="handleOk"
                         @cancel="handleCancel">
                    <a-form layout="vertical">
                        <div class="col">
                            <a-form-item label="Họ tên(*)">
                                <a-input v-model="modelComment.username"
                                         v-decorator="['username',{ rules: [{ required: false, message: 'Username is required!' }], },]" 
                                         placeholder="Vui lòng nhập họ tên..." />
                            </a-form-item>
                        </div>
                        <div class="col">
                            <a-form-item label="Email(*)">
                                <a-input v-model="modelComment.email"
                                         v-decorator="['email', { rules: [{required: true, message: 'vui lòng nhập email!'}]}]"
                                         placeholder="Vui lòng nhập địa chỉ email..." />
                            </a-form-item>
                        </div>
                        <div class="col">
                            <a-form-item label="Nội dung bình luận">
                                <a-input v-model="modelComment.content" />
                            </a-form-item>
                        </div>
                    </a-form>
                </a-modal>
            </div>
            <div>
                <a-list :header="`${this.Pagination.Total} bình luận`"
                        item-layout="horizontal"
                        :data-source="Items">
                    <a-list-item slot="renderItem" slot-scope="item, index">
                        <a-comment :author="item.username">
                            <p slot="content">
                                {{ item.content }}
                            </p>
                            <a-tooltip slot="datetime" :title="item.createdTimeDisplay">
                                <span>{{ item.createdTimeDisplay }}</span>
                            </a-tooltip>
                        </a-comment>
                    </a-list-item>
                </a-list>
            </div>
        </a-row>
    </a-spin>


</template>

<script>
    import axios from 'axios';
    import commentApi from './optionlectureApi';
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
                modelComment: {
                    username: '',
                    email: '',
                    content: ''
                },
                FrmSearch: null,
                IsLoading: false,
                Pagination: {
                    Total: 0,
                    PageIndex: 1,
                    PageSize: 10000
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
                axios.post(commentApi.listComment, params).then(r => {
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

            ChangePageSize(current, size) {
                this.Pagination.PageSize = size;
                this.LoadData();
            },
            ChangePage(page, pageSize) {
                this.LoadData();
            },
            showModal() {
                this.visible = true;
            },
            handleOk(e) {
                axios.post(commentApi.addComment, {
                    username: this.modelComment.username,
                    email: this.modelComment.email,
                    content: this.modelComment.content,
                    lectureId: this.$route.params.id,
                    parentId: null
                }).then(r => {
                    this.$message.success('Thêm bình luận thành công!', 3);
                }).catch(error => {
                    this.$message.error('Lỗi khi thêm bình luận', 3);
                    console.log(error);
                });
                setTimeout(() => {
                    this.visible = false;
                }, 1000);
                this.LoadData();
            },
            handleCancel(e) {
                console.log('Clicked cancel button');
                this.visible = false;
                this.LoadData();
            },
        }
    }
</script>

<style>
</style>
