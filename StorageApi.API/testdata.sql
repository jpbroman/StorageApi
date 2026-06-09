PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Price" INTEGER NOT NULL,
    "Category" TEXT NOT NULL,
    "Shelf" TEXT NOT NULL,
    "Count" INTEGER NOT NULL,
    "Description" TEXT NOT NULL
);
INSERT INTO Products VALUES(1,'Kaffe Beans',229,'Food','A1',45,'Premium roasted Kaffe beans');
INSERT INTO Products VALUES(2,'Green Tea',49,'Food','A1',40,'Organic green tea bags');
INSERT INTO Products VALUES(3,'Notebook',35,'Office','B2',60,'A5 lined notebook');
INSERT INTO Products VALUES(4,'Ballpoint Pens',20,'Office','B2',100,'Pack of 10 blue pens');
INSERT INTO Products VALUES(5,'USB Cable',89,'Electronics','C3',15,'USB-C charging cable');
INSERT INTO Products VALUES(6,'Wireless Mouse',249,'Electronics','C3',8,replace('Ergonomic wireless\nmouse','\n',char(10)));
INSERT INTO Products VALUES(7,'LED Bulb',59,'Home','D4',30,'9W warm white LED bulb');
INSERT INTO Products VALUES(8,'Dish Soap',39,'Home','D4',20,'500ml lemon-scented dish soap');
INSERT INTO Products VALUES(9,'Water Bottle',99,'Sports','E5',18,'750ml reusable water bottle');
INSERT INTO Products VALUES(10,'Yoga Mat',299,'Sports','E5',6,'Non-slip exercise mat');
INSERT INTO Products VALUES(11,'FooBar',100,'Bogus','B1',100,'Bogus product');
INSERT INTO Products VALUES(12,'Helmet',399,'Sports','S1',10,'Jofa hockey helmet');
INSERT INTO Products VALUES(13,'Motorola',12345,'Electronics','E2',12,'Mobile phone');
INSERT INTO Products VALUES(14,'Volvo 240',75000,'Cars','G1',1,'Used Volvo car in good condition');
COMMIT;
