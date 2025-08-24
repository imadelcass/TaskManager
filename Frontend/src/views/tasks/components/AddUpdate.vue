<template>
  <el-dialog
    :model-value="useDialog('task_dialog').isOpen()"
    @close="useDialog('task_dialog').close()"
    :close-on-click-modal="false"
    :style="{ width: '90%' }"
  >
    <template #header>
      <div>
        <h3>{{ form.id ? 'update-task' : 'add-task' }}</h3>
      </div>
    </template>
    <el-form
      ref="formRef"
      v-loading="loading"
      :model="form"
      :rules="rules"
      label-width="120px"
      status-icon
      label-position="top"
    >
      <div class="grid grid-cols-2 gap-2">
        <div class="col-span-2">
          <el-form-item label="Title" prop="title" label-width="100%">
            <el-input v-model="form.title" />
          </el-form-item>
        </div>
        <div class="col-span-2">
          <el-form-item label="Description" prop="description" label-width="100%">
            <el-input type="textarea" :rows="4" v-model="form.description" />
          </el-form-item>
        </div>  
        <div class="col-span-2">
          <el-form-item label="Completed" prop="isCompleted" label-width="100%">
            <el-switch v-model="form.isCompleted" />
          </el-form-item>
        </div>
      </div>
    </el-form>
    <template #footer>
      <el-button @click="useDialog('task_dialog').close()">cancel</el-button>
      <el-button type="primary" :loading="loading" @click="submit(formRef)">save</el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { useDialog } from '@/composables/dialog'

// const emit = defineEmits(['refresh'])

const props = defineProps<{
  item?: Task
}>()

const emit = defineEmits(['refresh'])

const initForm = {
  title: null,
  description: null,
  isCompleted: false,
}

const taskStore = useTaskStore()
const form = ref(initForm)
const formRef = ref(null)
const loading = ref(false)

const rules = {
  title: [
    {
      required: true,
      message: 'Please input title',
      trigger: 'blur',
    },
  ],
}

watch(
  () => props.item,
  (newVal) => {
    if (newVal.id) {
      form.value = newVal
    } else {
      form.value = { ...initForm }
    }
  },
)

const submit = (formRef) => {
  formRef.validate((valid) => {
    if (valid) {
      loading.value = true
      if (form.value.id) {
        taskStore.update(form.value).finally(() => {
          form.value = { ...initForm }
          useDialog('task_dialog').close()
          emit('refresh')
          loading.value = false
        })
      } else {
        taskStore.add(form.value).finally(() => {
          form.value = { ...initForm }
          useDialog('task_dialog').close()
          emit('refresh')
          loading.value = false
        })
      }
    }
  })
}
</script>