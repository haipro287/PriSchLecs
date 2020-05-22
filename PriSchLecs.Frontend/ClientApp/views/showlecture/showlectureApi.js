import baseApi from "../baseApi";

export default {
    getLectureByCategoryId: baseApi.baseApi + '/api/CategoryLecture/GetLectureByCategoryId',
    lectureGetById: baseApi.baseApi + '/api/lecture/getbyid/'
}
