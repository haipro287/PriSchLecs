<template>
    <div>
        <b-card no-body>
            <b-tabs v-model="tabIndex" card>
                <b-tab title="Mô tả" :title-link-class="linkClass(0)">
                    Tài liệu tham khảo giáo án điện tử tiểu học môn lịch sử với những hình ảnh nhiều màu sác và sinh động, giúp các em học sinh dễ dàng tiếp thu bài giảng và việc giảng dạy của các thầy cô sẽ thuận lợi hơn. Nêu kết quả của các phong trào trên. Theo em, vì sao các phong trào chống thực dân Pháp của nhân dân ta trong thời kì đó đều thất bại Chia sẻ với các bạn trong nhóm những thông tin, tư liệu mà em tìm hiểu được về quê hương và thời niên thiếu của Nguyễn...
                </b-tab>
                <b-tab title="Bình luận" :title-link-class="linkClass(1)">
                    <comment>
                        
                    </comment>
                </b-tab>
            </b-tabs>
        </b-card>
    </div>
</template>

<script>
    import comment from './comment';

    export default {
        data() {
            return {
                tabIndex: 0
            }
        },
        methods: {
            linkClass(idx) {
                if (this.tabIndex === idx) {
                    return ['bg-primary', 'text-light']
                } else {
                    return ['bg-light', 'text-info']
                }
            }
        },
        components: {
            comment
        }

    }
</script>