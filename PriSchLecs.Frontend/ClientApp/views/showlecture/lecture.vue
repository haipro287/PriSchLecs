<template>
    <div class="card">
        <div class="card-header card-header-flex">
            <h1>{{ Model.name }}</h1>
            <h4>{{ Model.description }}</h4>
        </div>
        <div class="card-body">
            <p><span v-html="Model.content"></span></p>
        </div>
        <div class="card-footer">
            <a-tabs default-active-key="1">
                <a-tab-pane key="1" tab="Bình luận">
                    <comment></comment>
                </a-tab-pane>
                <a-tab-pane key="2" tab="Tải tài liệu">
                    <file></file>
                </a-tab-pane>
            </a-tabs>
        </div>
    </div> 
</template>
<script>
    import comment from '../optionlecture/comment';
    import file from '../optionlecture/file';
    import axios from 'axios';
    import api from './showlectureApi';

    export default {
        created() {
            axios.get(api.lectureGetById + this.$route.params.id).then(r => {
                this.Model.name = r.data.name;
                this.Model.description = r.data.description;
                this.Model.content = r.data.content;
                this.Model.id = this.$route.params.id;
                this.Model.view = r.data.view;
                this.Model.download = r.data.download;
            }).then(() => {
                this.CreateForm();
            });
        },

        data() {
            return {
                Model: {
                    name: '',
                    description: "",
                    content: '',
                    id: 0,
                    view: '',
                    download: '',
                },
                likeNumbers: 150,
                isLiked: false,
            }
        },
        methods: {
            addLike() {
                this.isLiked = !this.isLiked;
                if (this.isLiked) {
                    this.likeNumbers++;
                }
                else {
                    this.likeNumbers--;
                }
            },
            CreateForm() {
                let options = {
                    mapPropsToFields: () => {
                        return {
                            name: this.$form.createFormField({ value: this.Model.name, }),
                            description: this.$form.createFormField({ value: this.Model.description }),
                            content: this.$form.createFormField({ value: this.Model.content }),
                            id: this.$form.createFormField({ value: this.Model.id }),
                        };
                    }
                }
            },
            
        },
        components: {
            comment,
            file
        }
    };
</script>
<style>
    
</style>