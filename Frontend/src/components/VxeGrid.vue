<template>
  <vxe-grid v-bind="mergedOptions"></vxe-grid>
</template>

<script lang="ts" setup generic="T">
import { computed } from 'vue'
import type { VxeGridProps } from 'vxe-table'

const props = defineProps<{
  columns?: VxeGridProps<T>['columns']
  proxyConfig?: VxeGridProps<T>['proxyConfig']
}>()

const mergedOptions = computed<VxeGridProps<T>>(() => ({
  border: true,
  height: 500,
  stripe: true,
  resizable: true,
  showOverflow: true,
  columns: props.columns,
  proxyConfig: props.proxyConfig,
}))
</script>
