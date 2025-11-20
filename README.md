# Restaurant Management System

## Description
A simple **Restaurant Management System** built using **Object-Oriented Programming (OOP)** in **C#**.  
The system includes **Customer Menu**, **Employee Menu**, and **Cashier Menu**.  

It allows users to:
- View Food and Drinks menus
- Create, update, and cancel orders
- Add, update, search, and delete items
- Handle payments
- Save and read data using file operations

---

## Features

### Customer Menu
- View Food Menu
- View Drinks Menu
- Create Order
- Cancel Order

### Employee Menu
- View All Items
- Add New Item
- Search for Item
- Update Item
- Delete Item

### Cashier Menu
- View All Orders
- Search Order
- Payment Process
- Delete Order

---

## UML Diagram

```plaintext
           +------------------------+
           |       clsItem          |
           +------------------------+
           | -Id: int               |
           | -Name: string          |
           | -Category: string      |
           | -Price: double         |
           | -Quantity: int         |
           +------------------------+
           | +Id {get; set;}        |
           | +Name {get; set;}      |
           | +Category {get; set;}  |
           | +Price {get; set;}     |
           | +Quantity {get; set;}  |
           +------------------------+

           +------------------------+
           | clsItemFileOperations  |
           +------------------------+
           | -_filename: string     |
           +------------------------+
           | +AddNewItem(item)      |
           | +ReadAllItems()        |
           | +SearchOnItem(id)      |
           | +UpdateItem(id)        |
           | +DeleteItem(id)        |
           | +ChooseTypeOfMenu(type)|
           +------------------------+

           +------------------------+
           |       clsOrder         |
           +------------------------+
           | -OrderId: int          |
           | -CustomerName: string  |
           | -ItemId: int           |
           | -ItemName: string      |
           | -ItemPrice: double     |
           | -TotalPrice: double    |
           | -OrderDate: DateTime   |
           +------------------------+
           | +Constructor()         |
           +------------------------+

           +------------------------+
           | clsOrderFileOperation  |
           +------------------------+
           | -_filename: string     |
           +------------------------+
           | +SaveNewOrder(order)   |
           | +ReadAllOrders()       |
           | +DeleteOrder(id)       |
           +------------------------+

           +------------------------+
           |     clsEmployee        |
           +------------------------+
           | +EmployeeMenu()        |
           | +EnterItem()           |
           | +PrintItems(list)      |
           +------------------------+

           +------------------------+
           |   clsCustomerMenu      |
           +------------------------+
           | +CustomerMenu()        |
           +------------------------+

           +------------------------+
           |    clsCashierMenu      |
           +------------------------+
           | +CashierMenu()         |
           +------------------------+

           +------------------------+
           |     clsMainMenu        |
           +------------------------+
           | +MainMenu()            |
           +------------------------+
