import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import VxeUIAll from 'vxe-pc-ui'
import 'vxe-pc-ui/es/style.css'

import VxeUITable from 'vxe-table'
import 'vxe-table/es/style.css'

const app = createApp(App)

app.use(createPinia())
app.use(VxeUIAll)
app.use(VxeUITable)
app.use(router)

app.mount('#app')