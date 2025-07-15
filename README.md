# 🍽️ Restaurant Management Application

<div style="display: flex; justify-content: center;">
    <img src="https://github.com/user-attachments/assets/be905b3c-921f-4af1-b27c-d3fa39fccb92" alt="Home page for admin" width: 400px;">
</div>

## 📌 Overview
This is a desktop application for managing online food orders in a restaurant, developed using **C#**, **WPF**, and **SQL Server**. It follows the **MVVM** architecture and uses **Data Binding** to synchronize the user interface with the underlying logic.

---

## 📂 Table of Contents
- Features
- Technologies
- Installation
- Database Setup
- Usage
- Screenshots
- License

---

## ✅ Features

### For Unauthenticated Users
- View the complete menu (dishes + menus)
- Search by name or allergens
- Create a client account

### For Clients
- Place food orders online
- View and track their orders
- Cancel active orders

### For Employees
- Manage categories, dishes, menus, and allergens
- View and update all orders
- Generate reports on inventory, orders, and clients

---

## 🛠️ Technologies

- C# (.NET 8 / WPF)
- SQL Server 2022
- MVVM + Data Binding
- ADO.NET or Entity Framework (with stored procedures)
- Advanced stored procedures (JOINs, subqueries)
- Configuration file for discounts and thresholds

---

## 💻 Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/MoroianuAndrei/Restaurant.git
   cd Restaurant
   ```

2. Open the solution in **Visual Studio 2022+**

3. Configure your database connection string in the configuration file (`App.config` or `appsettings.json`)

---

## 🗃️ Database Setup

### 📁 Backup file included: `dbRestaurant.bak`

#### 🔄 Restore in SQL Server

1. Open **SQL Server Management Studio (SSMS)**
2. Right-click on **Databases** → `Restore Database...`
3. Choose **Device** → `...` → `Add` → select the `dbRestaurant.bak` file
4. In the "Destination" section, set the database name to `dbRestaurant` (or another name if preferred)
5. (Optional) Go to the **Options** tab and check **Overwrite the existing database** if needed
6. Click `OK` and wait for the message: *"The database was restored successfully."*

---

## ▶️ Usage

1. Log in as a user (client or employee)
2. Navigate through the interface:
   - `Menu` – View available dishes and menus
   - `Search` – Filter by keyword or allergens
   - `Orders` – Place, track, or cancel orders
   - `Admin` – (for employees) manage dishes and stock

---

## 🖼️ Screenshots

### Administrator
<div style="display: flex; justify-content: center;">
    <img src="https://github.com/user-attachments/assets/45eb8d21-debc-46d7-917a-b852d7f7b579" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/b2106511-b99b-4042-9f7a-e04620c86e08" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/e7f87216-c147-43e4-b97b-01e12e7f3cdd" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/585f1368-a64a-4732-9821-2a23c18d2303" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/0ab658fe-daef-4f93-876a-e45105542885" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/ab139279-aa1b-4a95-a3f8-92c490ab4ff5" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/af12fcbf-5acc-465e-9127-d7c6770b2116" style="margin-right: 10px; width: 400px;">
</div>

### Cashier
<div style="display: flex; justify-content: center;">
    <img src="https://github.com/user-attachments/assets/d16d04a8-113a-409f-aff6-b6d2f281d455" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/856fb67f-c2a4-4db0-aa6a-78305a92142b" style="margin-right: 10px; width: 400px;">
    <img src="https://github.com/user-attachments/assets/1f5fb6c1-b2ef-402e-89d4-917773d847e4" style="margin-right: 10px; width: 400px;">
</div>

---

## 📄 License

This project is for educational use only. No official license or warranty is provided.
