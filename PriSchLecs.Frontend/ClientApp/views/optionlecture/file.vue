<template>
    <div>
        <div class="card">
            <div class="card-header card-header-flex">
                <div class="flex-column justify-content-center">
                    <a-button class="btn btn-sm btn-primary mr-2" type="primary" icon="plus" @click="showModal">
                        Thêm tệp đính kèm
                    </a-button>

                </div>
            </div>

            <a-modal title="Thêm tệp đính kèm"
                     :visible="visible"
                     :width="1000"
                     @ok="handleOk"
                     :confirmLoading="false"
                     @cancel="handleCancel">
                <addFile></addFile>
            </a-modal>
            <div class="card-body" style="padding:16px;">

                <a-table :columns="columns"
                         :dataSource="file"
                         bordered
                         :pagination="false">
                    <span slot="action" slot-scope="record">
                        <a-button class="btn btn-sm btn-danger mr-2" @click="deleteFile(record.id)">
                            <a-icon type="delete" />
                            Xóa
                        </a-button>
                        <a :href="fileApi.download + record.id">
                            <a-button class="btn btn-sm btn-primary mr-2">
                                <a-icon type="download" />Tải xuống
                            </a-button>
                        </a>
                    </span>
                    <span slot="name" slot-scope="record">
                        <a :href="fileApi.download + record.id">{{record.name}}</a>
                    </span>
                </a-table>

            </div>
        </div>
    </div>
</template>
<script>
    /*import fileApi from '../file/api';*/
    /*import api from './lectureFileApi';*/
    import Axios from 'axios';
    /*import addFile from './addFile';*/
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
                        scopedSlots: {customRender: 'name'},
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
                fileApi
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
                Axios.get(api.getFileByLectureId + this.$route.params.id).then(r => {
                    this.file = r.data
                }).catch(error => {
                    this.$message.error('Đã xảy ra lỗi!', 3);
                    console.log(error);
                });
            },          
        },
        components: {
            addFile
        }
    }
</script>