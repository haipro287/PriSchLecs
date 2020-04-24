const Anonymous = () => import('../views/anonymous');

const LectureCreateOrUpdate = () => import('../views/lecture/createorupdate');
const LectureList = () => import('../views/lecture/list');

export const routes = [{
    name: 'lecture',
    path: '/lecture',
    component: Anonymous,
    children: [{
        name: 'createorupdate',
        path: 'createorupdate/:id',
        component: LectureCreateOrUpdate
    }, {
        name: 'list',
        path: 'list',
        component: LectureList
    }]
}];
