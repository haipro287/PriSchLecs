<template>
    <div>
        <h3>Lịch sử lớp 4</h3>
        <p><i>Giáo án điện tử tiểu học môn lịch sử: "Nhân vật tiêu biểu trong lịch sử Việt Nam"</i></p>
        <div class="embed-responsive embed-responsive-16by9">
            <iframe class="embed-responsive-item" src="https://tailieu.vn/readpdf/viewfile/1.1.114/web/?f=https://tailieu.vn/readpdf/tailieu/2011/20111126/tengteng6/lich_su_cua_ha_8303.pdf?rand=112178" allowfullscreen></iframe>
        </div>

        <h2 class="lecture-name">Giáo án điện tử tiểu học môn lịch sử: "Nhân vật tiêu biểu trong lịch sử Việt Nam"</h2>
        <a-button type="primary" icon="like">Like</a-button>
        <a-button type="primary" icon="download" size="medium" onclick="window.location.href = '_blank';">Download</a-button>
        <a-button type="primary" icon="share-alt" onclick="window.location.href = '_blank';">Share</a-button>

        <span class="rating">
            Đánh giá: 8.5/10
            <a-rate v-model="value" />
        </span>

        <p class="lecture-reaction-count">Số lượt xem: 345 - Số lượt thích: 200 - Số lượt tải: 123</p>
        <div class="lecture-tag">
            <a-tag><a href="_blank">Lịch sử</a></a-tag>
            <a-tag><a href="_blank">Lớp 4</a></a-tag>
            <a-tag><a href="_blank">Nguyễn Ái Quốc</a></a-tag>
        </div>
        <tagBar></tagBar>
        <router-link to="/">
            <a-button>
                Về trang chủ
            </a-button>
        </router-link>
    </div>
</template>
<script>
    import tagBar from './tagBar';
    export default {
        data() {
            return {
                value: 4
            }
        },
        components: {
            tagBar
        }
    };

</script>
<style>
    * {
        font-size: 14px;
    }

    .rating {
        float: right;
    }

    .video {
        width: 20%;
        height: 20%;
    }

    .lecture-name {
        padding: 10px 0px;
    }

    .lecture-tag {
        padding-bottom: 0px;
    }

    .lecture-reaction-count {
        margin-bottom: 7px;
    }
</style>