const NotFound = () => import('views/notFound');
const Home = () => import('views/home');
const Lecture = () => import('views/lecture');
const Categories = () => import('views/categories');
const Category = () => import('views/category');

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
    }, 
    {
        name: 'categories',
        path: '/categories/:id',
        component: Categories
    },
    {
        name: 'category',
        path: '/category/:id',
        component: Category
    }
];
