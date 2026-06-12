StorageApi is an application for warehouse keeping.

It store products in table Products, with properties:
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
