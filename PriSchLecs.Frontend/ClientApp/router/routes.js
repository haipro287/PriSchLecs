const NotFound = () => import('views/notFound');
const Home = () => import('views/home');
const Lecture = () => import('views/lecture');

export const routes = [
    {
        name: 'notFound',
        path: '*',
        component: NotFound
    },
    {
        name: 'home',
        path: '/',
        component: Home
    },
    {
        name: 'lecture',
        path: '/lecture/:id',
        component: Lecture
    }
];
