import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import DetailsView from '../views/DetailsView.vue'
import LogsView from '../views/LogsView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/:id',
      name: 'id',
      component: DetailsView
    },
    {
      path: '/Logs',
      name: 'logs',
      component: LogsView
    }
  ]
})

export default router
