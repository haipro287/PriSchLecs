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





<!--<template>
    <div>
        <h4>GIÁO ÁN ĐƯỢC NHIỀU LƯỢT LIKE</h4>
        <div>
            <a-row type="flex">
                <a-col :span="12" v-for="(card, index) in cards_plan" :key="index" class="mt-3 pl-5">

                    <a-icon v-bind:type="card.type_file" v-bind:class="card.type_file" />
                    <router-link to="/lecture/0">
                        <span class="title">{{card.title}}</span>
                    </router-link>
                </a-col>
            </a-row>
        </div>

        <h4>ĐỀ THI ĐƯỢC DOWNLOAD NHIỀU NHẤT</h4>
        <div>
            <a-row type="flex">
                <a-col :span="12" v-for="(card, index) in cards_test " :key="index" class="mt-3 pl-5">

                    <a-icon v-bind:type="card.type_file" v-bind:class="card.type_file" />
                    <router-link to="/lecture/0">
                        <span >{{card.title}}</span>
                    </router-link>
                </a-col>
            </a-row>
        </div>



        <h4>BÀI GIẢNG ĐƯỢC XEM NHIỀU NHẤT</h4>
        <div>
            <a-row type="flex">
                <a-col :span="6" class="mt-5" v-for="(card, index) in cards_slide" :key="index">
                    <router-link to="/lecture/0">
                        <a-card hoverable style="width: 250px">
                            <img alt="example"
                                 v-bind:src="card.img"
                                 slot="cover" />
                            <h6>{{card.title}}</h6>
                            <p>{{card.content}}</p>
                        </a-card>
                    </router-link>
                </a-col>
            </a-row>
        </div>



    </div>
</template>
<script>
    export default {
        data() {
            return {
                current: 0,
                cards_slide: [
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 1',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 2',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 3',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 3',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 3',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 3',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 3',
                        content : 'cong tu nhan chia so 1 chu so'
                    },
                    {
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png',
                        title: 'Toan lop 4',
                        content : 'cong tu nhan chia so 2 chu so'
                    }
                ],
                cards_test: [
                         {
                        type_file:"file-word",
                        title: "Đề thi giữa học kì 1 môn tiếng việt lớp 2"
                    },
                    {
                        type_file: "file-excel",
                        title: "Đề thi giữa học kì 2 môn tiếng việt lớp 3"
                    },
                    {
                        type_file: "file-word",
                        title: "Đề thi giữa học kì 1 môn toán lớp 5"
                    },
                    {
                        type_file: "file-excel",
                        title: "Đề thi giữa học kì 1 môn tiếng anh lớp 4"
                    },
                    {
                        type_file: "file-excel",
                        title: "Đề thi giữa học kì 2 môn lịch sử lớp 5"
                    },
                    {
                        type_file: "file-word",
                        title: "Đề thi giữa học kì 1 môn tiếng việt lớp 2"
                    }
                ],
                cards_plan: [
                         {
                        type_file:"file-word",
                        title: "Giáo án toán 2 học kì I"
                    },
                    {
                        type_file: "file-excel",
                        title: "Giáo án TH&XH lớp 2"
                    },
                    {
                        type_file: "file-excel",
                        title: "Giáo án môn toán lớp 5 kì I"
                    },
                    {
                        type_file: "file-word",
                        title: "Giáo án tiếng anh lớp 4 cả năm"
                    },
                    {
                        type_file: "file-excel",
                        title: "Giáo án học kì 2 môn lịch sử lớp 5 cả năm"
                    },
                    {
                        type_file: "file-word",
                        title: "Giáo án môn tiếng việt lớp 2 kì I"
                    }
                ]

            };
        },
        methods: {
             goToLecture() {
                this.$router.replace('/lecture/0');
            }
        }
    }
</script>
<style>
    .file-word {
        transform: translateY(-5px);
        color : blue  !important;
    }
    .file-excel{
        transform: translateY(-5px);
        color: orangered !important;
    }
    h4 {
        text-align: center;
        padding: 50px 0px;
    }
    .title{
        color: black;
    }

</style>-->
