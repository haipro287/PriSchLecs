<template>
    <div>
        Hello from home
        <router-link to="/lecture/0">
            <a-button>
                Bài giảng
            </a-button>
        </router-link>
    </div>
</template>
<script>
    export default {
        methods: {
            goToLecture() {
                this.$router.replace('/lecture/0');
            }
        }
    }
</script>
<style>
</style>