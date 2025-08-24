<template>
  <vxe-grid ref="tableRef" v-bind="mergedOptions">
    <template #toolbar_buttons="{ row }">
      <div class="mb-3 flex space-x-2">
        <el-button
          type="primary"
          @click="emit('add-item')"
          class="bg-indigo-600 hover:bg-indigo-700 focus:ring-1 focus:ring-indigo-200"
        >
          <span class="font-normal">{{ addLabel }}</span>
          <icon icon="tabler:plus" class="ml-2 w-4 h-4" />
        </el-button>
      </div>
    </template>

    <template #actions="{ row }">
      <div class="flex justify-center space-x-1">
        <div>
          <el-button
            link
            @click="emit('update-item', row)"
            class="text-gray-400 hover:text-blue-500"
          >
            <icon icon="tabler:pencil" class="w-4.5 h-4.5" />
          </el-button>
        </div>
        <div>
          <el-popconfirm
            icon-color="#EF4444"
            title="are-you-sure-to-delete-this"
            @confirm="emit('delete-item', row)"
          >
            <template #reference>
              <el-button link class="text-gray-400 hover:text-red-500">
                <icon icon="tabler:trash" class="w-4.5 h-4.5" />
              </el-button>
            </template>
          </el-popconfirm>
        </div>
      </div>
    </template>
  </vxe-grid>
</template>

<script lang="ts" setup generic="T">
import { computed } from 'vue'
import type { VxeGridProps } from 'vxe-table'

const props = defineProps<{
  columns?: VxeGridProps<T>['columns']
  proxyConfig?: VxeGridProps<T>['proxyConfig']
  addLabel?: string
}>()

const emit = defineEmits<{
  'add-item': []
  'update-item': [any]
  'delete-item': [any]
}>()

const mergedOptions = computed<VxeGridProps<T>>(() => ({
  columns: props.columns,
  proxyConfig: props.proxyConfig,
  border: true,
  height: 500,
  stripe: true,
  resizable: true,
  showOverflow: true,
  toolbarConfig: {
    export: true,
    refresh: true,
    print: true,
    custom: true,
    slots: {
      buttons: 'toolbar_buttons',
    },
  },
  pagerConfig: {
    enabled: true,
    pageSize: 10,
  },
}))

const tableRef = ref()

const refresh = () => {
  tableRef.value.commitProxy('query')
}


defineExpose({ refresh })
</script>
