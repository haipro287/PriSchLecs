<template>
    <div>
        <a-list item-layout="horizontal" :dataSource="file">
            <a-list-item slot="renderItem" slot-scope="item">
                <a :href="api.download + item.id">{{ item.name }}</a>
            </a-list-item>
        </a-list>
        <!--<div class="card-body" style="padding:16px;">
            <a-table :columns="columns"
                     :dataSource="file"
                     bordered
                     :pagination="false">
                <span slot="action" slot-scope="record">
                    <a :href="api.download + record.id">
                        <a-button class="btn btn-sm btn-primary mr-2">
                            <a-icon type="download" />Tải xuống
                        </a-button>
                    </a>
                </span>
                <span slot="name" slot-scope="record">
                    <a :href="api.download + record.id">{{record.name}}</a>
                </span>
            </a-table>
        </div>-->
    </div>
</template>
<script>
    import api from './optionlectureApi';
    import axios from 'axios';
    export default {
        data() {
            return {
                file: null,
                columns: [
                    {
                        title: 'ID',
                        dataIndex: 'id',
                    },
                    {
                        title: 'Tên tệp',
                        scopedSlots: { customRender: 'name' },
                    },
                    {
                        title: 'Ngày tạo',
                        dataIndex: 'createdTimeDisplay',
                    },
                    {
                        title: 'Ngày cập nhật',
                        dataIndex: 'updatedTimeDisplay',
                    },
                    {
                        title: 'Action',
                        scopedSlots: { customRender: 'action' },
                    },
                ],
                visible: false,
                api
            }
        },
        mounted() {
            this.loadFile();
        },
        methods: {
            showModal() {
                this.visible = true;
            },
            handleOk() {
                this.visible = false;
                this.loadFile();
            },
            handleCancel() {
                this.visible = false;
                this.loadFile();
            },
            loadFile() {
                axios.get(api.getFileByLectureId + this.$route.params.id).then(r => {
                    this.file = r.data
                }).catch(error => {
                    this.$message.error('Đã xảy ra lỗi!', 3);
                    console.log(error);
                });
            },
        },
        components: {
        }
    }
</script>