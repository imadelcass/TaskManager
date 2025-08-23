<template>
  <VxeGrid
    :columns="columns"
    :proxy-config="proxyConfig"
  />
</template>

<script lang="ts" setup>
import VxeGrid from '@/components/VxeGrid.vue'
import type { VxeGridProps } from 'vxe-table'

interface RowVO {
  id: number
  name: string
  nickname: string
  role: string
  sex: string
  age: number
  address: string
}

const proxyConfig: VxeGridProps<RowVO>['proxyConfig'] = {
  ajax: {
    query: () =>
      new Promise<RowVO[]>((resolve) => {
        setTimeout(() => {
          resolve([
            {
              id: 10001,
              name: 'Test1',
              nickname: 'T1',
              role: 'Develop',
              sex: 'Man',
              age: 28,
              address: 'Shenzhen',
            },
          ])
        }, 300)
      }),
  },
}

const columns: VxeGridProps<RowVO>['columns'] = [
  { type: 'seq', width: 70 },
  { field: 'name', title: 'Name' },
  { field: 'nickname', title: 'Nickname' },
  { field: 'role', title: 'Role' },
  { field: 'address', title: 'Address', showOverflow: true },
]
</script>
