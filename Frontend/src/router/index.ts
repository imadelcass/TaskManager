import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: { name: 'tasks' },
      component: () => import('@/layouts/default.vue'),
      children: [
        {
          path: '/tasks',
          name: 'tasks',
          component: () => import('@/views/tasks/index.vue'),
        },
      ],
    },
  ],
})

export default router
