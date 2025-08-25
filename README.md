# TaskManager – Clean Architecture Demo

This repository contains a small but realistic application that demonstrates **Clean Architecture** with **.NET 9** and a **Vue 3 (TypeScript)** frontend.  
It follows principles like **DDD**, **CQRS**, and includes **basic domain events**.

---

## 📂 Project Structure

TaskManager/
│── Backend/ # .NET 9 API
│ ├── TaskManager.API # API layer (controllers, DI, swagger)
│ ├── TaskManager.Application # CQRS commands, queries, validators
│ ├── TaskManager.Domain # Entities, value objects
│ └── TaskManager.Infrastructure# EF Core, repositories, persistence
│
│── Frontend/ # Vue 3 + TypeScript app
│ ├── src/
│ │ ├── components/ # UI components
│ │ ├── views/ # Pages
│ │ ├── store/ # Pinia stores
│ │ └── main.ts # Entry point
│ └── index.html


---

## 🚀 Features

### Backend (.NET 9)
- Clean Architecture layers: **Domain, Application, Infrastructure, API**
- **CQRS** with MediatR (Commands & Queries)
- **EF Core + Migrations** for persistence
- **FluentValidation** for input validation
- **Swagger/OpenAPI** enabled

### Frontend (Vue 3 + TS)
- Vue 3 with **TypeScript**
- **Pinia** for state management
- **Axios** for API calls
- **Element plus** for UI library
- **VXETable** for data table 
- Simple UI for managing tasks


---

## 🛠️ Setup & Run

### 1. Clone repository
```bash
git clone https://github.com/imadelcass/TaskManager
cd TaskManager
cd Backend/TaskManager.API
dotnet restore
dotnet ef database update
dotnet run

cd Frontend
npm install
npm run dev

