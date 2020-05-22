import BaseApi from "../baseApi";

export default {
    upload: BaseApi.baseApi + "file/upload/",
    download: BaseApi.baseApi + "file/download/",
    search: BaseApi.baseApi + "file/search",
    delete: BaseApi.baseApi + "file/delete/"
};
