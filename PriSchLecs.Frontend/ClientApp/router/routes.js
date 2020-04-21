const Home = () => import('views/home')
const Lecture = () => import('views/lecture');

export const routes = [
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
