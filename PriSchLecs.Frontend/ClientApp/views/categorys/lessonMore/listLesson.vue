<template>
    <div>
        <div id="lessonPlan" class="px-3">
            <div>
                <a-row type="flex">
                    <a-col :span="6" class="justify-content-center" v-for="(card, index) in card_plan" :key="index">
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

        <div>
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
            <br />
            
        </div>


    </div>
</template>

<script>

    export default {
        data() {
            return {
                            
                        card_plan: [{
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 1',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                    },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                    },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                    },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                    },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                    },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                         {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                          {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                           {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                            {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                             {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                              {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                               {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 2',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                        
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 3',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 3',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                        {
                            img: "https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png",
                            title: 'Toan lop 3',
                            content: 'cong tu nhan chia so 1 chu so'
                        },
                        {
                            img: 'https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png',
                            title: 'Toan lop 4',
                            content: 'cong tu nhan chia so 2 chu so'
                    }],
                        pageSize: 20,
                current: 4,
                        Pagination: {
                            Total: 0,
                            PageIndex: 1,
                            PageSize: 5
                        },
            }
        },
        watch: {
            pageSize(val) {
            console.log('pageSize', val);
            },
            current(val) {
                console.log('current', val);
            },
        },
        methods: {
            onShowSizeChange(current, pageSize) {
                console.log(current, pageSize);
            },
            ChangePageSize(current, size) {
                this.Pagination.PageSize = size;
                this.LoadData();
            },
            ChangePage(page, pageSize) {
                this.LoadData();
            }
        },
};

                    
            
</script>
<style>
    #lessonPlan {
        margin-bottom: 30px;
    }

    .title {
        padding: 50px 10px;
    }
    .card {
        margin-right: 100px;
        width: 230px !important;
    }
</style>

