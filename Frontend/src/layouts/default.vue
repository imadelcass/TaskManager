<template>
  <div class="flex h-screen">
    <!-- Sidebar -->
    <aside class="w-64 bg-white shadow-md">
      <div class="p-6 font-bold text-xl h-16">TaskManager</div>
      <nav class="mt-6">
        <ul>
          <li>
            <router-link
              to="/tasks"
              class="block px-6 py-2 hover:bg-gray-200 rounded"
              active-class="bg-gray-200 font-semibold"
            >
              Tasks
            </router-link>
          </li>
        </ul>
      </nav>
    </aside>

    <!-- Main content -->
    <div class="flex-1 flex flex-col">
      <!-- Navbar -->
      <header class="h-16 bg-white shadow flex items-center px-6 justify-between">
        <h1 class="text-lg font-semibold">Dashboard</h1>
        <div class="flex items-center space-x-4">
          <span>Admin</span>
          <button class="px-3 py-1 bg-blue-500 text-white rounded hover:bg-blue-600">
            Logout
          </button>
        </div>
      </header>

      <!-- Page content -->
      <main class="flex-1 p-6 overflow-auto">
        <router-view />
      </main>
    </div>
  </div>
</template>