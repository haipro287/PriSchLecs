import baseApi from '../../baseApi';

export default {
    list: baseApi.baseApi + "comment/search/",
    delete: baseApi.baseApi + "comment/delete/",
    comment: baseApi.baseApi + "comment/createorupdate/"
}