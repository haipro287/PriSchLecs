import Vue from 'vue';
import axios from 'axios';
import router from './router/index';
import store from './store';
import { sync } from 'vuex-router-sync';
import App from './app.vue';

import Antdv from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';

// Registration of global components

sync(store, router);

Vue.use(axios);
Vue.use(Antdv); 

const app = new Vue({
    store,
    router,
    ...App
});

export {
    app,
    router,
    store
};
