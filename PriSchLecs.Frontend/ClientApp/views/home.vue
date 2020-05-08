<template>
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
    
</style>
