<template>
    <a-layout id="components-layout-demo-side" style="min-height: 100vh">
        <a-layout-sider collapsible v-model="collapsed" width="250">
            <div class="logo">PRISCHLECS ADMIN</div>
            <a-menu theme="dark" :defaultSelectedKeys="['1']" mode="inline">
                <a-sub-menu v-for="(submenu, subindex) in menu" :key="subindex">
                    <span slot="title"><a-icon type="user" />{{submenu.name}}</span>
                    <a-menu-item v-for="menuitem in submenu.children" :key="menuitem.name">
                        <router-link :to="menuitem.path">{{menuitem.name}}</router-link>
                    </a-menu-item>
                </a-sub-menu>
            </a-menu>
        </a-layout-sider>
        <a-layout>
            <a-layout-content style="margin: 0 16px">
                <div :style="{ padding: '24px', background: '#fff', minHeight: '360px' }">
                    <router-view></router-view>
                </div>
            </a-layout-content>
            <a-layout-footer style="text-align: center">
                
            </a-layout-footer>
        </a-layout>
    </a-layout>
</template>
<script>
    import { menu } from '../menu/menu'
    export default {
        data() {
            return {
                collapsed: false,
                menu,
            };
        },
        mounted() {
            
        },
        methods: {

        },
        components: {

        }
    };
</script>
<style>
    #components-layout-demo-side .logo {
        height: 32px;
        background: rgba(255, 255, 255, 0.2);
        margin: 16px;
        color: white;
        text-align: center;
    }
</style>
