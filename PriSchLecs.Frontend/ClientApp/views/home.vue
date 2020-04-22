<template>
    <div>
        Hello from home
        <router-link to="/lecture/0">
            <a-button>
                Bài giảng
            </a-button>
        </router-link>
        <a-pagination v-model="current" :total="50" showLessItems />
        <b-button>Button</b-button>
        <b-button variant="danger">Button</b-button>
        <b-button variant="success">Button</b-button>
        <b-button variant="outline-primary">Button</b-button>7
        <b-row>
            <b-col md="auto">
                <b-calendar v-model="value" @context="onContext" locale="en-US"></b-calendar>
            </b-col>
            <b-col>
                <p>Value: <b>'{{ value }}'</b></p>
                <p class="mb-0">Context:</p>
                <pre class="small">{{ context }}</pre>
            </b-col>
        </b-row>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                current: 0
            }
        },
        methods: {
            goToLecture() {
                this.$router.replace('/lecture/0');
            }
        }
    }
</script>
<style>
</style>