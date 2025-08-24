<template>
  <VxeGrid
    ref="tableRef"
    :columns="columns"
    :proxy-config="proxyConfig"
    add-label="Add Task"
    @add-item="onAddItem"
    @update-item="onUpdateItem"
    @delete-item="onDeleteItem"
  />
  <add-update :item="item" @refresh="refresh()" />
</template>

<script lang="ts" setup>
import type { VxeGridProps } from 'vxe-table'
import AddUpdate from './components/AddUpdate.vue'

const taskStore = useTaskStore()
const item = ref<Task | null>(null)
const tableRef = ref<any>(null)

const proxyConfig: VxeGridProps<Task>['proxyConfig'] = {
  ajax: {
    query: ({ page }) =>
      new Promise((resolve) => {
        taskStore.fetch(page).then((res) => {
          resolve({
            page: { total: res?.totalCount },
            result: res?.items,
          })
        })
      }),
  },
}

const columns: VxeGridProps<Task>['columns'] = [
  { field: 'title', title: 'Title' },
  { field: 'description', title: 'Description' },
  {
    field: 'isCompleted',
    title: 'Status',
    width: 100,
    formatter: ({ cellValue }) => (cellValue ? 'Completed' : 'Not Completed'),
  },
  {
    field: 'actions',
    title: 'actions',
    width: 120,
    slots: {
      default: 'actions',
    },
  },
]

const onAddItem = (row: any) => {
  item.value = null
  useDialog('task_dialog').open()
}

const onUpdateItem = (row: any) => {
  item.value = row
  useDialog('task_dialog').open()
}

const onDeleteItem = (row: any) => {
  taskStore.delete(row.id).then(() => {
    refresh()
  })
}

const refresh = () => {
  tableRef.value.refresh()
}
</script>
