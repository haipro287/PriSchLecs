import baseApi from '../baseApi';

export default {
    listComment: baseApi.baseApi + 'comment/search/',
    listFile: baseApi.baseApi + 'file/search/',
    getFileByLectureId: baseApi.baseApi + "lecturefile/getfilebylectureid/",
    download: baseApi.baseApi + "file/download/",
    addComment: baseApi.baseApi + 'comment/createorupdate/'
}