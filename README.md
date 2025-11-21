# Restaurant Management System

A **simple Restaurant Management System** built using **Object-Oriented Programming (OOP) in C#**.  
The system supports managing items, orders, employees, and customers efficiently through a console-based interface.

---

## Features

- **Customer Menu**
  - View Food Menu
  - View Drinks Menu
  - Create Order
  - Cancel Order

- **Employee Menu**
  - View All Items
  - Add New Item
  - Search for Item
  - Update Item
  - Delete Item

- **Cashier Menu**
  - View All Orders
  - Search for an Order
  - Payment Process
  - Delete an Order

- **File Handling**
  - Save and read items and orders using text files.

---

## UML Class Diagram

The following diagram shows the structure of the project and the relationships between classes:

@startuml
class clsItem {
    - Id: int
    - Name: string
    - Category: string
    - Price: double
    - Quantity: int
    + Id {get; set;}
    + Name {get; set;}
    + Category {get; set;}
    + Price {get; set;}
    + Quantity {get; set;}
}

class clsItemFileOperations {
    - _filename: string
    + AddNewItem(item)
    + ReadAllItems()
    + SearchOnItem(id)
    + UpdateItem(id)
    + DeleteItem(id)
    + ChooseTypeOfMenu(type)
}

class clsOrder {
    - OrderId: int
    - CustomerName: string
    - ItemId: int
    - ItemName: string
    - ItemPrice: double
    - TotalPrice: double
    - OrderDate: DateTime
    + clsOrder()
}

class clsOrderFileOperation {
    - _filename: string
    + SaveNewOrder(order)
    + ReadAllOrders()
    + DeleteOrder(id)
}

class clsEmployee {
    + EmployeeMenu()
    + EnterItem()
    + PrintItems(list)
}

class clsCustomerMenu {
    + CustomerMenu()
}

class clsCashierMenu {
    + CashierMenu()
}

class clsMainMenu {
    + MainMenu()
}

clsEmployee --> clsItem
clsCustomerMenu --> clsItem
clsCustomerMenu --> clsOrder
clsCashierMenu --> clsOrder
clsMainMenu --> clsEmployee
clsMainMenu --> clsCustomerMenu
clsMainMenu --> clsCashierMenu
@enduml



**Classes Included:**
- `clsItem` – Represents individual items.
- `clsItemFileOperations` – Handles file operations for items.
- `clsOrder` – Represents customer orders.
- `clsOrderFileOperation` – Handles file operations for orders.
- `clsEmployee` – Employee menu and item management.
- `clsCustomerMenu` – Customer menu and order creation.
- `clsCashierMenu` – Cashier menu and payment processing.
- `clsMainMenu` – Main menu navigation.

---


