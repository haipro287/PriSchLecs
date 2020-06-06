import baseApi from '../baseApi';

export default {
    createOrUpdate: baseApi.baseApi + "lecture/createorupdate/",
    delete: baseApi.baseApi + "lecture/delete/",
    list: baseApi.baseApi + "lecture/search/",
    getById: baseApi.baseApi + "lecture/getbyid/",
    getCategoryByLectureId: baseApi.baseApi + "categorylecture/getcategorybylectureid/",
    deleteCategoryLecture: baseApi.baseApi + "categorylecture/delete/",
    createCategoryLecture: baseApi.baseApi + "categorylecture/create/",
    listCategory: baseApi.baseApi + "category/search/"
}
