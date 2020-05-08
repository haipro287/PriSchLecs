<template>
    <!--when have API Upload will appear-->
    <a-row>
        <h2>Kho dữ liệu tải lên</h2>
        <div class="card">
            <div class="card-header card-header-flex">
                <a-upload name="file"
                          :multiple="true"
                          action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                          :headers="headers"
                          @change="handleChange"
                          :default-file-list="defaultFileList">
                    <a-button> <a-icon type="upload" /> Click to Upload </a-button>
                </a-upload>
            </div>
        </div>
        <div class="card">
            <a-upload-dragger name="file"
                              :multiple="true"
                              action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                              @change="handleChange">
                <p class="ant-upload-drag-icon">
                    <a-icon type="inbox" />
                </p>
                <p class="ant-upload-text">
                    Click or drag file to this area to upload
                </p>
                <p class="ant-upload-hint">
                    Support for a single or bulk upload. Strictly prohibit from uploading company data or other
                    band files
                </p>
            </a-upload-dragger>
        </div>

    </a-row>

</template>
<script>
export default {
  data() {
    return {
        headers: {
        authorization: 'authorization-text',
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
};
</script>