import Vue from 'vue';
import axios from 'axios';
import router from './router/index';
import store from './store';
import { sync } from 'vuex-router-sync';
import App from './views/App.vue';

import Antdv from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

// Registration of global components

sync(store, router);

// Install BootstrapVue
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)
// Install Axios
Vue.use(axios);
// Install AntDesignVue
Vue.use(Antdv);

Vue.config.productionTip = false

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
