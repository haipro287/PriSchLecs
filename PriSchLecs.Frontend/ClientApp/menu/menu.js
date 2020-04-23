/*code in app.vue
<a-sub-menu v-for="subMenu in menu" :key="subMenu.name">
    <span slot="title">
        <router-link :to="subMenu.path">{{ subMenu.name }}</router-link>
    </span>
    <a-menu-item v-for="(subObject, index) in menu.objects" :key="index">
        <router-link :to="subObject.path">{{ subObject.object }}</router-link>
    </a-menu-item>
</a-sub-menu>
 */
export const menu = [
    {
        name: "Lớp 1",
        path: "/grade1",
        objects: [
            {
                object: "Toán",
                path: "/math1"
            },
            {
                object: "Văn",
                path: "/literature1"
            },
            {
                object: "Anh",
                path: "/english1"
            }
        ]
    },
    {
        name: "Lớp 2",
        path: "/grade2",
        objects: [
            {
                object: "Toán",
                path: "/math2"
            },
            {
                object: "Văn",
                path: "/literature2"
            },
            {
                object: "Anh",
                path: "/english2"
            }
        ]
    },
    {
        name: "Lớp 3",
        path: "/grade3",
        objects: [
            {
                object: "Toán",
                path: "/math3"
            },
            {
                object: "Văn",
                path: "/literature3"
            },
            {
                object: "Anh",
                path: "/english3"
            }
        ]
    },
    {
        name: "Lớp 4",
        path: "/grade4",
        objects: [
            {
                object: "Toán",
                path: "/math4"
            },
            {
                object: "Văn",
                path: "/literature4"
            },
            {
                object: "Anh",
                path: "/english4"
            }
        ]
    },
    {
        name: "Lớp 5",
        path: "/grade5",
        objects: [
            {
                object: "Toán",
                path: "/math5"
            },
            {
                object: "Văn",
                path: "/literature5"
            },
            {
                object: "Anh",
                path: "/english5"
            }
        ]
    },
];
export const categories = [
    {
        name: "Bài giảng",
        path: "/category/lesson"
    },
    {
        name: "Giáo án",
        path: "/category/lessonPlan"
    },
    {
        name: "Đề thi & Kiểm tra",
        path: "/category/exam&test"
    },
    {
        name: "Tư liệu",
        path: "/category/documentation"
    }
];