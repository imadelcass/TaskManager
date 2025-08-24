import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import VxeUIAll from 'vxe-pc-ui'
import VxeUITable from 'vxe-table'
import { Icon } from "@iconify/vue";
import ElementPlus from 'element-plus'

import 'element-plus/dist/index.css'
import 'vxe-pc-ui/es/style.css'
import 'vxe-table/es/style.css'
import './assets/main.css'

import enUS from 'vxe-table/lib/locale/lang/en-US'

const app = createApp(App)

VxeUIAll.setI18n('en-US', enUS)
VxeUIAll.setLanguage('en-US')

app.component('Icon', Icon)
app.use(ElementPlus)
app.use(createPinia())
app.use(VxeUIAll)
app.use(VxeUITable)
app.use(router)

app.mount('#app')