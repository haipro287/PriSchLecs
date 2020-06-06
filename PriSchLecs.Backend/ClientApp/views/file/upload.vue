<template>
    <a-row>
        <h5>Tải tệp lên</h5>
        <div class="card">
            <div class="card-header card-header-flex">
                <a-upload name="file"
                          :multiple="true"
                          :action="Api.upload"
                          :headers ="headers"
                          @change="handleChange"
                          :default-file-list="defaultFileList">
                    <a-button> <a-icon type="upload" /> Chọn file </a-button>
                </a-upload>
            </div>
        </div>
    </a-row>

</template>
<script>
    import Api from "./api";
    import List from "./list";
    export default {
        data() {
            return {
                Api: Api,
                headers: {

                },
            };
        },
        methods: {
            handleChange(info) {
                if (info.file.status !== 'uploading') {
                    console.log(info.file, info.fileList);
                }
                if (info.file.status === 'done') {
                    this.$message.success(`tải lên ${info.file.name} thành công!`);
                } else if (info.file.status === 'error') {
                    this.$message.error(`lỗi tải file ${info.file.name}!`);
                }
            },
        },
        components: {
            List
        }
    };
</script>