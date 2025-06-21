# 📦 Aplicación de Inventario - Microservicios con Angular y .NET

Este proyecto es una solución fullstack desarrollada con **Angular 19** y **.NET 9**, estructurada en microservicios para la gestión de productos y transacciones, con funcionalidades de filtrado dinámico, stock, y CRUD completo.

---

## ✅ Requisitos

Para ejecutar el proyecto en tu entorno local necesitas tener instalado:

- [✔️ .NET SDK 9.0.301](https://dotnet.microsoft.com/)
- [✔️ Node.js v22.16.0](https://nodejs.org/)
- [✔️ NPM v10.9.2](https://www.npmjs.com/)
- [✔️ Angular CLI v19.2.11](https://angular.io/cli)
- [✔️ SQL Server] o tu gestor de base de datos
- Editor de código recomendado: **Visual Studio 2022** (backend) y **Visual Studio Code** (frontend)

---

## 🚀 Ejecución del Backend

La aplicación está compuesta por **dos microservicios independientes**:

- `ProductoAPIService`
- `TransaccionAPIService`

Cada uno se ejecuta en un puerto diferente y cuenta con su propia interfaz Swagger para pruebas.

---

### 1️⃣ Ejecutar el microservicio de productos

Abre una terminal y navega al directorio del servicio:

```bash
cd BackendPruebaTecnica/ProductoAPIService
dotnet restore
dotnet run
```
- Servicio disponible en: https://localhost:7256
- Swagger UI: https://localhost:7256/swagger

### 2️⃣ Ejecutar el microservicio de transacciones
Abre otra terminal y navega al directorio del segundo servicio:

```bash
cd BackendPruebaTecnica/TransaccionAPIService
dotnet restore
dotnet run
```
- Servicio disponible en: https://localhost:7241

- Swagger UI: https://localhost:7241/swagger

### 🔧 Nota importante
Si cambias de máquina, entorno o base de datos:

- Actualiza la cadena de conexión en appsettings.json.

- Verifica que CORS esté habilitado para http://localhost:4200.

## 🌐 Ejecución del Frontend

El frontend de esta aplicación está desarrollado con **Angular 19.2.10** y Angular CLI **19.2.11**.

### ▶️ Pasos para ejecutar

1. Abre una terminal y navega a la carpeta del frontend:

```bash
cd FrontPruebaTecnica
npm install
ng serve --open
```
![image](https://github.com/RenatoNavas/EvaluacionTecnicaFullStack/blob/edcfaf3f9341be8ea6d7ac9c23d8f2c9961d8006/crearproducto.png)
