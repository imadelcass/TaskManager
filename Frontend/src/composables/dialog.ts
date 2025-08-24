import { ref } from 'vue'

const dialog = ref<Record<string, boolean>>({})

export const useDialog = (value : string) => {
    
  const open = () => (dialog.value[value] = true)

  const close = () => (dialog.value[value] = false)

  const isOpen = () => dialog.value[value]

  return {
    open,
    close,
    isOpen
  }
}