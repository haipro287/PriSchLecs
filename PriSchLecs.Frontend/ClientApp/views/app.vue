
<template>
    <a-layout id="components-layout-demo-top-side-2">
        <a-layout-header class="header" id="test">
            <div class="logo">
                Chia sẻ kiến thức tiểu học
            </div>
            <a-menu theme="dark"
                    mode="horizontal"
                    :defaultSelectedKeys="['2']"
                    :style="{ lineHeight: '64px' }">
                <a-menu-item v-for="subCategory in category" :key="subCategory.name">
                    <router-link :to="subCategory.path">{{ subCategory.name }}</router-link>
                </a-menu-item>
            </a-menu>
            <div class="search">
                <input type="text" placeholder="Tìm kiếm" />
                <a-icon type="search" style="width: 20px; height: 60%; position: absolute; top: 8px; left: calc(100% - 77px); transform: scale(1.5);"/>
            </div>
        </a-layout-header>
        <a-layout>
            <a-layout-sider width="200" style="background: #fff">
                <a-menu mode="inline"
                        :style="{ height: '100%', borderRight: 0 }">
                    <a-sub-menu key="sub1">
                        <span slot="title"><a-icon type="user" />Lớp 1</span>
                        <a-menu-item key="1">
                            <router-link to="/math1">Toán</router-link>
                        </a-menu-item>
                        <a-menu-item key="2">
                            <router-link to="/literature1">Văn</router-link>
                        </a-menu-item>
                        <a-menu-item key="3">
                            <router-link to="/english1">Anh</router-link>
                        </a-menu-item>
                    </a-sub-menu>
                    <a-sub-menu key="sub2">
                        <span slot="title"><a-icon type="user" />Lớp 2</span>
                        <a-menu-item key="4">
                            <router-link to="/math2">Toán</router-link>
                        </a-menu-item>
                        <a-menu-item key="5">
                            <router-link to="/literature2">Văn</router-link>
                        </a-menu-item>
                        <a-menu-item key="6">
                            <router-link to="/english2">Anh</router-link>
                        </a-menu-item>
                    </a-sub-menu>
                    <a-sub-menu key="sub3">
                        <span slot="title"><a-icon type="user" />Lớp 3</span>
                        <a-menu-item key="7">
                            <router-link to="/math3">Toán</router-link>
                        </a-menu-item>
                        <a-menu-item key="8">
                            <router-link to="/literature3">Văn</router-link>
                        </a-menu-item>
                        <a-menu-item key="9">
                            <router-link to="/english3">Anh</router-link>
                        </a-menu-item>
                    </a-sub-menu>
                    <a-sub-menu key="sub4">
                        <span slot="title"><a-icon type="user" />Lớp 4</span>
                        <a-menu-item key="10">
                            <router-link to="/math4">Toán</router-link>
                        </a-menu-item>
                        <a-menu-item key="11">
                            <router-link to="/literature4">Văn</router-link>
                        </a-menu-item>
                        <a-menu-item key="12">
                            <router-link to="/english4">Anh</router-link>
                        </a-menu-item>
                    </a-sub-menu>
                    <a-sub-menu key="sub5">
                        <span slot="title"><a-icon type="user" />Lớp 5</span>
                        <a-menu-item key="13">
                            <router-link to="/math5">Toán</router-link>
                        </a-menu-item>
                        <a-menu-item key="14">
                            <router-link to="/literature5">Văn</router-link>
                        </a-menu-item>
                        <a-menu-item key="15">
                            <router-link to="/english5">Anh</router-link>
                        </a-menu-item>
                    </a-sub-menu>
                </a-menu>
            </a-layout-sider>
            <a-layout style="padding: 0 24px 24px">
                <a-breadcrumb style="margin: 16px 0">
                    <a-breadcrumb-item>Home</a-breadcrumb-item>
                    <a-breadcrumb-item>List</a-breadcrumb-item>
                    <a-breadcrumb-item>App</a-breadcrumb-item>
                </a-breadcrumb>
                <a-layout-content :style="{ background: '#fff', padding: '24px', margin: 0, minHeight: '280px' }">
                    <router-view></router-view>
                    <lecture></lecture>

                    <div v-for="(content, index) in contents " :key="index">
                        {{content.name}}
                        {{content.grade}}
                    </div>
                </a-layout-content>
            </a-layout>
        </a-layout>
        <a-layout-footer style="background: #001529; color: #fff;">
            <div class="welcome">
                Ứng dụng chia sẻ kiến thức bậc tiểu học
            </div>
            <div class="contact">
                <h2 style="color: #fff;">Liên hệ với chúng tôi</h2>
                <div class="address">
                    <a-icon type="bank"/>
                    <p>Địa chỉ: UET-VNU, Xuân Thủy, Cầu Giấy, Hà Nội</p>
                </div>
                <div class="telephone">
                    <a-icon type="phone" />
                    <p>SĐT: 0123456789</p>
                </div>
                <div class="email">
                    <a-icon type="red-envelope" />
                    <p>Email: cungHocCNPM@gmail.com</p>
                </div>
            </div>
        </a-layout-footer>
    </a-layout>
</template>
<script>
    import lecture from './lecture';
    import { menu } from '../menu/menu';
    import { categories } from '../menu/menu';
    export default {
        data() {
            return {
                collapsed: false,
                contents: [
                    {
                        name: 'hai',
                        grade: 'ao;spq',
                    },
                    {
                        name: 'huy',
                        grade: 'q92p401',
                    }
                ],
                menu: menu,
                category: categories 
            };
        },
        components: {
            lecture
        }
    };
    
</script>

<style>
    @import '../css/menu.css';
</style>
    