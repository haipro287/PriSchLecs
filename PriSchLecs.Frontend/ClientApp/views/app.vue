<template>
    <a-layout id="components-layout-demo-top-side-2">
        <a-layout-header class="header" id="test">
            <router-link to="/">
                <div class="logo">
                    Chia sẻ bài giảng tiểu học
                </div>
            </router-link>
            <a-menu theme="dark"
                    mode="horizontal"
                    :defaultSelectedKeys="['2']"
                    :style="{ lineHeight: '64px' }">
                <a-menu-item v-for="subCategory in category" :key="subCategory.name">
                    <router-link :to="subCategory.path">{{ subCategory.name }}</router-link>
                </a-menu-item>
            </a-menu>
            <div class="search">
                <a-input v-decorator="['Keyword']"
                         placeholder="Từ khóa..."
                         style="width: 190px;" />
                <a-button type="primary" html-type="submit" icon="search" style="width: 45px;">
                </a-button>
            </div>
        </a-layout-header>
        <a-layout>
            <a-layout-sider width="200" style="background: #fff">
                <a-menu mode="inline" :style="{ height: '100vh', borderRight: 0, overflow: 'scroll' }" theme="dark">
                    <a-sub-menu v-for="submenu in menu" :key="submenu.name">
                        <span slot="title"><a-icon type="user" />{{submenu.name}}</span>
                        <a-menu-item v-for="menuitem in submenu.children" :key="menuitem.name">
                            <router-link :to="menuitem.path">{{menuitem.name}}</router-link>
                        </a-menu-item>
                    </a-sub-menu>
                </a-menu>
            </a-layout-sider>
            <a-layout style="padding: 0 24px 24px">
                <a-layout-content :style="{ background: '#fff', padding: '24px', margin: 0, minHeight: '280px' }">
                    <router-view></router-view>
                </a-layout-content>
            </a-layout>
        </a-layout>
        
    </a-layout>
</template>
<script>
    import lecture from './showlecture/lecture';
    import { menu } from '../menu/menu';
    import { categories } from '../menu/menu';
    import category from '../views/showlecture/category';
    export default {
        data() {
            return {
                collapsed: false,
                menu: menu,
                category: categories
            };
        },
        components: {
            lecture,
            category
        },
        method() {
            
        }
    };

</script>

<style>
    @import '../css/menu.css';
</style>
