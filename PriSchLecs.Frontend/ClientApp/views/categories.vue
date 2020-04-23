<template>
    <div class="text-center">
        <a-row :gutter="16">
            <a-col v-for="(cate, index) in cates" :key="index"
                   :span="8">
                <router-link :to=cate.link>
                    <b-card border-variant="light" :header=cate.name class="text-center" style="color: gray">
                        <b-card-text>{{cate.description}}</b-card-text>
                    </b-card>
                </router-link>
            </a-col>
        </a-row>
    </div>
</template>
<script>   
    import { cates } from '../data/categories-data';
    export default {
        data() {
            return {
                cates: cates
            }
        }
    }
</script>
<style>
    a-col {
        background-color: black;
    }
</style>