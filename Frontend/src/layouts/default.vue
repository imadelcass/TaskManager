<template>
  <div class="flex h-screen bg-gradient-to-br from-slate-50 to-blue-50">
    <!-- Sidebar -->
    <aside class="w-64 bg-white/80 backdrop-blur-sm shadow-xl border-r border-gray-200/50">
      <!-- Logo Section -->
      <div class="p-6 border-b border-gray-200/50">
        <div class="flex items-center space-x-3">
          <div class="w-8 h-8 bg-gradient-to-r from-blue-500 to-purple-600 rounded-lg flex items-center justify-center shadow-lg">
            <icon icon="tabler:checklist" class="w-5 h-5 text-white" />
          </div>
          <h1 class="font-bold text-xl bg-gradient-to-r from-gray-800 to-gray-600 bg-clip-text text-transparent">
            TaskManager
          </h1>
        </div>
      </div>

      <!-- Navigation -->
      <nav class="mt-6 px-4">
        <ul class="space-y-2">
          <li>
            <router-link
              to="/tasks"
              class="group flex items-center px-4 py-3 text-gray-700 rounded-xl hover:bg-gradient-to-r hover:from-blue-50 hover:to-purple-50 hover:text-blue-600 transition-all duration-200 ease-in-out"
              active-class="bg-gradient-to-r from-blue-500 to-purple-600 text-white font-semibold shadow-lg"
            >
              <icon icon="tabler:clipboard-list" class="w-5 h-5 mr-3 transition-transform group-hover:scale-110" />
              Tasks
            </router-link>
          </li>
        </ul>
      </nav>
    </aside>

    <!-- Main content -->
    <div class="flex-1 flex flex-col min-w-0">
      <!-- Navbar -->
      <header class="h-16 bg-white/80 backdrop-blur-sm shadow-sm border-b border-gray-200/50 flex items-center px-6 justify-between">
        <div class="flex items-center space-x-4">
          <h1 class="text-xl font-bold bg-gradient-to-r from-gray-800 to-gray-600 bg-clip-text text-transparent">
            Dashboard
          </h1>
        </div>
      </header>

      <!-- Page content -->
      <main class="flex-1 p-6 overflow-auto">
        <div class="max-w-7xl mx-auto">
          <router-view />
        </div>
      </main>
    </div>
  </div>
</template>