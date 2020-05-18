<template>
    <div>
        <div id="listLessonPlan" class="px-3">
            <h1>Giáo án Toán lớp 1</h1>
            <div class = "listCard">
                <a-row type="flex">
                    <a-col :span="8" v-for="(card, index) in card_plan " :key="index" class="mt-3 pl-5">
                            <a-icon v-bind:type="card.type_file" v-bind:class="card.type_file" />
                            <router-link to="/lecture/0">
                                <span>{{card.title}}</span>
                            </router-link>
                        </a-col>
                </a-row>

            </div>
        </div>

        <div>
            <a-pagination show-size-changer
                          :default-current="3"
                          :total="500"
                          @showSizeChange="onShowSizeChange" />
            <br />
            
        </div>


    </div>
</template>

<script>

    export default {
        data() {
            return {
                            
                        card_plan: [{
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },           {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        }           ],
                        pageSize: 20,
                        current: 4,
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
        },
    
};

                    
            
</script>
<style>
    #listLessonPlan {
    }
    .file-word {
        transform: translateY(-5px);
        color : blue  !important;
    }
    .file-excel{
        transform: translateY(-5px);
        color: orangered !important;
    }
    .title {
        padding: 50px 10px;
    }
    .link {
        color: #808080;
    }
    .listCard {
        padding-bottom : 30px
    }
    h1 {
        text-align : center;
        padding : 30px;
    }
</style>

