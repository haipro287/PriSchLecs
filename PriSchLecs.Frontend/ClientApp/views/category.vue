<template>
    <div>
        <h1>Toán</h1>
        <p>Mô tả dài</p>
        <a-tabs defaultActiveKey="1" @change="callback">
            <a-tab-pane tab="Các danh mục" key="1">
                <a-list itemLayout="horizontal" :dataSource="data">
                    <a-list-item slot="renderItem" slot-scope="item, index">
                        <a-list-item-meta :description=item.description>
                            <a slot="title" href="#">{{ item.name }}</a>
                            <a-avatar slot="avatar" shape="square" src="https://cdn2.iconfinder.com/data/icons/files-and-documents-1/512/28-512.png" />
                        </a-list-item-meta>
                    </a-list-item>
                </a-list>
            </a-tab-pane>
            <a-tab-pane tab="Các bài giảng" key="2" forceRender>
                <a-list itemLayout="horizontal" :dataSource="data">
                    <a-list-item slot="renderItem" slot-scope="item, index">
                        <a-list-item-meta :description=item.description>
                            <a slot="title" href="#">{{ item.name }}</a>
                            <a-avatar slot="avatar" shape="square" src="https://img.icons8.com/cotton/2x/file.png" />
                        </a-list-item-meta>
                    </a-list-item>
                </a-list>
            </a-tab-pane>
        </a-tabs>
    </div>

</template>
<script>
    
    import { cates } from '../data/categories-data';
    export default {
        data() {
            return {
                data: cates,
            };
        },
    };
</script>
<style></style>

