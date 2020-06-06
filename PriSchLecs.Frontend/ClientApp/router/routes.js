const Anonymous = () => import('../views/anonymous');
const NotFound = () => import('../views/notFound');

const Home = () => import('../views/showcategory/home');

const Lecture = () => import('../views/showlecture/lecture');
const CategoryList = () => import('../views/showlecture/categorylist');
const SearchLecture = () => import('../views/showlecture/searchlecture');



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
        name: 'category',
        path: '/category',
        component: Anonymous,
        children: [
            {
                name: 'list',
                path: 'list/:id',
                component: CategoryList
            }
        ]
    },
    {
        name: 'search',
        path: '/search/:keyword',
        component: SearchLecture
    },
    {
        name: 'searchnull',
        path: '/search',
        component: SearchLecture
    }
    
];
