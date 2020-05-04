const NotFound = () => import('views/notFound');
const Home = () => import('views/home');
const Lecture = () => import('views/lecture');

const Lesson = () => import('views/categorys/lesson');
const LessonPlan = () => import('views/categorys/lessonPlan');
const Exam = () => import('views/categorys/exam');
const Documentation = () => import('views/categorys/documentation');

const ListSubject = () => import('views/categorys/lessonMore/listSubject');
const ListLesson = () => import('views/categorys/lessonMore/listLesson');

const ListSubjectPlan = () => import('views/categorys/lessonPlanMore/listSubjectPlan');
const ListLessonPlan = () => import('views/categorys/lessonPlanMore/listLessonPlan');



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
        name: 'lessonPlan',
        path: '/categorys/lessonPlan',
        component: LessonPlan
    },
    {
        name: 'exam',
        path: '/categorys/exam',
        component: Exam
    },
    {
        name: 'documentation',
        path: '/categorys/documentation',
        component: Documentation
    },    
    {
        name: 'lesson',
        path: '/categorys/lesson',
        component: Lesson
    },
    {
        name: 'listSubject',
        path: '/categorys/lesson/listSubject',
        component: ListSubject
    },
    {
        name: 'listLesson',
        path: '/categorys/lesson/listLesson',
        component: ListLesson
    },
    {
        name: 'listSubjectPlan',
        path: '/categorys/lessonPlan/listSubjectPlan',
        component: ListSubjectPlan
    },
     {
        name: 'listLessonPlan',
        path: '/categorys/lessonPlan/listLessonPlan',
        component: ListLessonPlan  
    }
    
];
