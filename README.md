# PropertyManagement Solution – Help & Execution Guide

A modern, full-stack web application for managing property listings, built with **.NET 9 (WebAPI)** and **React, TypeScript, Vite (WebUI)**.

---

## Overview

This solution consists of:
- **PropertyManagement.WebAPI**: The backend RESTful API built with ASP.NET Core (.NET 9).
- **PropertyManagement.WebUI**: The frontend single-page application built with React, TypeScript, and Vite.

The WebUI communicates with the WebAPI to provide a seamless property management experience.

---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download) (for WebAPI)
- [Node.js](https://nodejs.org/) (v18 or newer recommended, for WebUI)
- [npm](https://www.npmjs.com/) (comes with Node.js)
- Visual Studio 2022 (recommended for backend development)
- Modern web browser

---

## Solution Help

### Common Folders

| Folder/Project                | Description                                      |
|-------------------------------|--------------------------------------------------|
| PropertyManagement.WebAPI     | ASP.NET Core backend API (.NET 9)                |
| PropertyManagement.WebUI      | React + TypeScript frontend (Vite)               |
| PropertyManagement.Services   | Business logic and service implementations       |
| PropertyManagement.Helper     | Shared utilities, configuration, middleware      |

---

# PropertyManagement.WebUI

A modern web application for managing property listings, built with **React**, **TypeScript**, and **Vite**.

## Overview

PropertyManagement.WebUI is the front-end for the Property Management system. It allows users to view and interact with property data, including features, highlights, spaces, and more. The app communicates with a .NET WebAPI backend.

---

## Features

- View property listings and details
- Responsive UI built with React and TypeScript
- Fast development with Vite
- Easy integration with PropertyManagement.WebAPI

---

## Prerequisites

- [Node.js](https://nodejs.org/) (v18 or newer recommended)
- [npm](https://www.npmjs.com/) (comes with Node.js)
- Running instance of [PropertyManagement.WebAPI](../PropertyManagement.WebAPI) (.NET 9)

---

## Project Help

### Common Commands

| Command                | Description                                 |
|------------------------|---------------------------------------------|
| `npm install`          | Install all dependencies                    |
| `npm run dev`          | Start the development server                |
| `npm run build`        | Build the app for production                |
| `npm run preview`      | Preview the production build                |

### Configuration

- The development server port is set in `vite.config.ts` (default: 56191).
- API endpoints are configured in the frontend service files. Ensure they match your backend URL and port.
- To enable debugging, a `launch.json` is included for Visual Studio Code.

---

## How to Execute the Application

### 1. Clone the Repository
git clone https://github.com/ritesh-gondudey1/PropertyManagementApp.git 
cd PropertyManagement.WebUi


### 2. Install Dependencies
npm install


### 3. Start the Backend

- Ensure the [PropertyManagement.WebAPI](../PropertyManagement.WebAPI) project is running.
- Use Visual Studio 2022 or the .NET CLI:
cd ../PropertyManagement.WebAPI dotnet run


### 4. Start the Frontend (Development Mode)
npm run dev


- The app will be available at [http://localhost:56191](http://localhost:56191) (or the port configured in `vite.config.ts`).

### 5. Build for Production
npm run build


- The production-ready files will be generated in the `dist/` directory.

### 6. Preview the Production Build
npm run preview


### 7. Run the Backend (WebAPI)

#### Using Visual Studio 2022

1. Open the solution in Visual Studio 2022.
2. Set **PropertyManagement.WebAPI** as the startup project.
3. Press **F5** or click **Start Debugging**.

#### Using .NET CLI
cd PropertyManagement.WebAPI dotnet restore dotnet run


- The API will start (default: `https://localhost:7249` or as configured).
- Swagger UI is available at `/swagger` in development mode.

---

## Project Structure
src/ 
├── assets/         # Static assets like images and fonts 
├── components/     # Reusable React components 
├── pages/          # Page-level components 
├── services/       # API service functions 
├── styles/         # Global and component-specific styles 
├── utils/          # Utility functions 
├── App.tsx         # Main application component 
├── main.tsx        # Application entry point 
└── vite.config.ts  # Vite configuration



---

## API Usage

- This app expects a running instance of the PropertyManagement.WebAPI backend.
- Update API endpoints in the source code as needed to match your backend configuration.

---

## Troubleshooting

- If you encounter issues connecting to the backend, verify that both frontend and backend are running and that CORS is properly configured in the backend.
- For port conflicts, update the port in `vite.config.ts` and ensure the backend is not using the same port.

---

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements.

---

## License

This project is licensed under the MIT License.

