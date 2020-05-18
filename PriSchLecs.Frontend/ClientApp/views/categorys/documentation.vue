<template>
    <div>
        <div id="lessonPlan" class="px-3">
            <div v-for="category in list_card ">
                <div class="d-flex ant-row-flex-space-between title">
                    <h3>{{category.class_number}}</h3>
                    <router-link to="/categorys/lesson/listSubject">
                        Xem thêm
                    </router-link>
                </div>


                <div>
                    <a-row type="flex">
                        <a-col :span="8" class="justify-content-center" v-for="(card, index) in category.card_plan" :key="index">
                            <router-link to="/lecture/0">
                                <a-card hoverable class="m-4 card">
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
        </div>
        
    </div>
</template>

<script>

    export default {
        data() {
            return {
               
                list_card: [
                    {
                        class_number: " Lớp 1",
                        card_plan: [{
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
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png',
                        title: 'Toan lop 4',
                        content : 'cong tu nhan chia so 2 chu so'
                    }]

                    },
                    {
                        class_number: " Lớp 2",
                        card_plan: [{
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 1',
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
                    }]

                    },
                    {
                        class_number: " Lớp 3",
                        card_plan: [{
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
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png',
                        title: 'Toan lop 4',
                        content : 'cong tu nhan chia so 2 chu so'
                    }]

                    },
                    {
                        class_number: " Lớp 4",
                        card_plan: [{
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
                        img: 'https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png',
                        title: 'Toan lop 4',
                        content : 'cong tu nhan chia so 2 chu so'
                    }
                        ]

                    },
                    {
                        class_number: " Lớp 5",
                        card_plan: [{
                       img : "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                        title: 'Toan lop 1',
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
                    }]

                    }
                ]
            }
        }
    }
</script>
<style>
     #lessonPlan {
        margin-bottom : 30px;
    }
    .title {
        padding: 50px 10px;
    }
    .link {
        color: #808080;

    }
    .card {
        margin-right : 100px;
        width : 270px !important;
       
    }
</style>

