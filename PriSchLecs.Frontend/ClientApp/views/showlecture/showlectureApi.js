import baseApi from "../baseApi";

export default {
    getLectureByCategoryId: baseApi.baseApi + 'CategoryLecture/GetLectureByCategoryId/',
    lectureGetById: baseApi.baseApi + 'lecture/getbyid/',
    searchLecture: baseApi.baseApi + 'lecture/search/'
}
