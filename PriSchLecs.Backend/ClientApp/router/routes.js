const Anonymous = () => import('../views/anonymous');

const LectureCreateOrUpdate = () => import('../views/lecture/createorupdate');
const LectureList = () => import('../views/lecture/list');

const CategoryCreateOrUpdate = () => import('../views/category/createorupdate');
const CategoryList = () => import('../views/category/list');

export const routes = [{
    name: 'lecture',
    path: '/lecture',
    component: Anonymous,
    children: [
        {
            name: 'createorupdate',
            path: 'createorupdate/:id',
            component: LectureCreateOrUpdate
        },
        {
            name: 'list',
            path: 'list',
            component: LectureList
        }
    ]
},
{
    name: 'category',
    path: '/category',
    component: Anonymous,
    children: [
        {
            name: 'createorupdate',
            path: 'createorupdate/:id',
            component: CategoryCreateOrUpdate
        },
        {
            name: 'list',
            path: 'list',
            component: CategoryList
        }
    ]
}];
