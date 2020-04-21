import Vue from 'vue';
import axios from 'axios';
import router from './router/index';
import store from './store';
import { sync } from 'vuex-router-sync';
import App from './app.vue';

// Registration of global components

sync(store, router);

Vue.use(axios);

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
