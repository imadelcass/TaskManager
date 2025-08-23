import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      redirect: { name: 'tasks' },
    },
    {
      path: '/tasks',
      name: 'tasks',
      component: () => import('@/views/tasks/index.vue'),
    }
  ],
})

export default router
