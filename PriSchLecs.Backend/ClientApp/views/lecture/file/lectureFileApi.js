import baseApi from "../../baseApi";
export default {
    getFileByLectureId: baseApi.baseApi + "lecturefile/getfilebylectureid/",
    delete: baseApi.baseApi + "lecturefile/delete/",
    create: baseApi.baseApi + "lecturefile/create/"
}