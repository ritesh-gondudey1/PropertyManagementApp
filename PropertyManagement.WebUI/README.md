# PropertyManagement.WebUI

A modern web application for managing property listings, built with **React**, **TypeScript**, and **Vite**.

## Overview

PropertyManagement.WebUI is the front-end for the Property Management system. It allows users to view and interact with property data, including features, highlights, spaces, and more. The app communicates with a .NET WebAPI backend.

## Features

- View property listings and details
- Responsive UI built with React and TypeScript
- Fast development with Vite
- Easy integration with PropertyManagement.WebAPI

## Prerequisites

- [Node.js](https://nodejs.org/) (v18 or newer recommended)
- [npm](https://www.npmjs.com/) (comes with Node.js)

## Getting Started

1. **Install dependencies:**  npm install
2. **Run the development server:**  npm run dev   The app will be available at [http://localhost:56191](http://localhost:56191) (or the port configured in `vite.config.ts`).

3. **Build for production:**  npm run build
4. **Preview the production build:**  npm run preview
## Project Structure

The project structure is organized as follows:src/
├── assets/         # Static assets like images and fonts
├── components/     # Reusable React components
├── pages/          # Page-level components
├── services/       # API service functions
├── styles/         # Global and component-specific styles
├── utils/          # Utility functions
├── App.tsx         # Main application component
├── main.tsx        # Application entry point
└── vite.config.ts  # Vite configuration
## API Usage

This app expects a running instance of the PropertyManagement.WebAPI backend. Update API endpoints in the source code as needed to match your backend configuration.

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements.

## License

This project is licensed under the MIT License.
