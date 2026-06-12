StorageApi supports an application for warehouse keeping.

It can store products, with properties:
- Name
- Price
- Category
- Shelf
- Count
- Description

In devmode it will create an empty sqlite db "MyDatabase.db".
It can be populated with test data like this:
> sqlite3 MyDatabase.db < testdata.sql

The API listens for HTTP requests on http://localhost:5119/api/Products.
It is also available for test on http://localhost:5119/swagger/index.html

The API responds to the following requests:

- GET http://localhost:5119/api/Products
    Lists all products in store

- GET http://localhost:5119/api/Products/2
    List product with id 2

- GET http://localhost:5119/api/Products?shelf=A1&category=Food
    List all products on shelf A1 in category food.

- GET http://localhost:5119/api/Products/status
    Product inventory status:
    {
        "numberOfProducts": 13,
        "totalInventoryValue": 4278500,
        "averagePrice": 42125
    }

- POST http://localhost:5119/api/Products
    Add a product to the inventory. Takes a Json body:
    {
        "name": "string",
        "price": 1000000,
        "category": "string",
        "shelf": "string",
        "count": 100000,
        "description": "string"
    }

PUT http://localhost:5119/api/Products
    Updates a complete existing product. Json body:
    {
        "id": 0,
        "name": "string",
        "price": 0,
        "category": "string",
        "shelf": "string",
        "count": 0,
        "description": "string",
    }

DELETE http://localhost:5119/api/Products/1
    Remove product with index 1 from inventory.
