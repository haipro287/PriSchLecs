import baseApi from '../baseApi';

export default {
    createOrUpdate: baseApi.baseApi + "category/createOrUpdate/",
    delete: baseApi.baseApi + "category/delete/",
    list: baseApi.baseApi + "category/search/",
    getById: baseApi.baseApi + "category/getbyid/",
    getLectureByCategoryId: baseApi.baseApi + "categorylecture/getlecturebycategoryid/",
    deleteCategoryLecture: baseApi.baseApi + "categorylecture/delete/",
    createCategoryLecture: baseApi.baseApi + "categorylecture/create/",
    listLecture: baseApi.baseApi + "lecture/search/"
}
