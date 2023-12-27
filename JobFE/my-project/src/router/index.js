import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/sign-up',
    name: 'sign-up',
    component: () => import(/* webpackChunkName: "about" */ '../views/Register.vue')
  },
  {
    path: '/sign-up-admin',
    name: 'sign-up-admin',
    component: () => import(/* webpackChunkName: "about" */ '../views/RegisterAdmin.vue')
  },
  {
    path: '/detail-job/:id',
    name: 'detail-job',
    component: () => import(/* webpackChunkName: "about" */ '../views/DetailJob.vue')
  },
  {
    path: '/job',
    name: 'job',
    component: () => import(/* webpackChunkName: "about" */ '../views/Job.vue')
  },
  {
    path: '/job-list',
    name: 'job-list',
    component: () => import(/* webpackChunkName: "about" */ '../views/JobList.vue')
  },
  {
    path: '/admin',
    name: 'admin',
    component: () => import(/* webpackChunkName: "about" */ '../views/admin/Dashboard.vue')
  },
  {
    path: '/job-admin',
    name: 'job-admin',
    component: () => import(/* webpackChunkName: "about" */ '../views/admin/JobAdmin.vue')
  },
  {
    path: '/account',
    name: 'account',
    component: () => import(/* webpackChunkName: "about" */ '../views/admin/Account.vue')
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
