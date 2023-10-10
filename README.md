# Luxury Bags E-Commerce Application

Work in progress!

## Overview

This is a full-stack e-commerce application for selling luxury bags. The backend API is built with ASP.NET using Entity Framework and Identity for authentication. 
The database is powered by SQLite. The frontend is developed in Angular 15 and styled with Bootstrap for a responsive and user-friendly interface.

## Features

- User Authentication: Secure user registration and login system using ASP.NET Identity.
- Product Catalog: Browse a wide selection of luxury bags with details and images.
- Shopping Cart: Add products to your cart, update quantities, and proceed to checkout.
- Order Management: View and manage your orders, order history, and order details.
- Responsive Design: Mobile-friendly user interface for a seamless shopping experience.

## Installation

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://cli.angular.io/)
- [SQLite](https://www.sqlite.org/)

### Backend Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/luxury-bags-ecommerce.git

2. Navigate to the backend directory:
  
    ```bash
    cd .\API\

4. Restore dependencies and run migrations:

    ```bash
    dotnet restore
    dotnet ef database update

3. Start the API:
   
    ```bash
    dotnet watch --no-hot-reload

The backend API will be available at http://localhost:5001.

### Frontend Setup

1. Navigate to the frontend directory:

   ```bash
   cd .\Client\

2. Install Angular CLI if you haven't already:

    ```bash
    npm install -g @angular/cli

3. Install dependencies:

      ```bash
      npm install

4. Start the Angular development server:

      ```bash
      ng serve  

The frontend will be available at http://localhost:4200.

### Usage

Open your web browser and visit http://localhost:4200 to access the Luxury Bags E-Commerce Application.
Register an account or log in to start shopping.
Browse the product catalog, add items to your cart, and proceed to checkout.
View and manage your orders from your account dashboard.

### Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix: git checkout -b feature/your-feature-name
Commit your changes: git commit -m 'Add some feature'
Push to your branch: git push origin feature/your-feature-name
Create a pull request on GitHub.

### License

This project is licensed under the MIT License - see the LICENSE file for details.

### Acknowledgments

Special thanks to the ASP.NET and Angular communities for their excellent documentation and resources.
Happy shopping! 🛍️
