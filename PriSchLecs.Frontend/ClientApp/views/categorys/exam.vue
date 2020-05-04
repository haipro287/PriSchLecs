<template>
    <div id="lessonPlan" class="px-3">
        <div v-for="category in list_card ">
            <div class="d-flex ant-row-flex-space-between title">
                <h3>{{category.class_number}}</h3>
                <router-link to="/categorys/lessonPlan/listSubjectPlan">
                    Xem thêm
                </router-link>

            </div>


            <div>
                <a-row type="flex">
                    
                    <a-col :span="12" v-for="(card, index) in category.card_plan " :key="index" class="mt-3 pl-5">
                        <a-icon v-bind:type="card.type_file" v-bind:class="card.type_file" />
                        <router-link to="/lecture/0">
                            <span>{{card.title}}</span>
                        </router-link>
                    </a-col>
                    
                </a-row>
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
                            type_file: "file-word",
                            title: "Giáo án toán 1 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 1 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 1 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 1 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 1 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 1 học kì I"
                        }]

                    },
                    {
                        class_number: " Lớp 2",
                        card_plan: [{
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 2 học kì I"
                        }]

                    },
                    {
                        class_number: " Lớp 3",
                        card_plan: [{
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 3 học kì I"
                        }]

                    },
                    {
                        class_number: " Lớp 4",
                        card_plan: [{
                            type_file: "file-word",
                            title: "Giáo án toán 4 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 4 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 4 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 4 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 4 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 4 học kì I"
                        }
                        ]

                    },
                    {
                        class_number: " Lớp 5",
                        card_plan: [{
                            type_file: "file-word",
                            title: "Giáo án toán 5 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 5 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 5 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 5 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 5 học kì I"
                        },
                        {
                            type_file: "file-word",
                            title: "Giáo án toán 5 học kì I"
                        }]

                    }
                ]
            }
        }
    }
</script>
<style>
    #lessonPlan {
        margin-bottom: 30px;
        padding: 0px 50px !important;
    }

    .file-word {
        transform: translateY(-5px);
        color: blue !important;
    }

    .file-excel {
        transform: translateY(-5px);
        color: orangered !important;
    }

    .title {
        padding: 50px 10px;
    }

    .link {
        color: #808080;
    }
</style>

