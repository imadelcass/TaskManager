export const useTaskStore = defineStore("tasks", {
  state: () => ({
    tasks: [] as Task[],
  }),

  actions: {
    // Fetch tasks
    async fetch(params?: FetchParams): Promise<Task[] | void> {
      try {
        const { data } = await axios.get<Task[]>("tasks", { params })

        if (params?.all) {
          this.tasks = data
          return
        } else {
          return data
        }
      } catch (error) {
        console.error("Failed to fetch tasks:", error)
        return
      }
    },

    // Add a task
    async add(task: Omit<Task, "id">): Promise<Task> {
      try {
        const { data } = await axios.post<Task>("tasks", task)
        return data
      } catch (error) {
        console.error("Failed to add task:", error)
        throw error
      }
    },

    // Update a task
    async update(task: Task): Promise<Task> {
      try {
        const { data } = await axios.put<Task>(`tasks/${task.id}`, task)
        return data
      } catch (error) {
        console.error("Failed to update task:", error)
        throw error
      }
    },

    // Delete a task
    async delete(id: number): Promise<void> {
      try {
        await axios.delete(`tasks/${id}`)
      } catch (error) {
        console.error("Failed to delete task:", error)
        throw error
      }
    },
  },
})
