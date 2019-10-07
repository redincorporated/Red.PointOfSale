
create table items(
	id integer not null primary key,
	name varchar(255),
	code varchar(255),
	price double,
	description varchar(255)
);

create table customers(
	id integer not null primary key,
	name varchar(255),
	code varchar(255)
);

create table sales_receipts(
	id integer not null primary key,
	date datetime,
	customer_id integer
);

create table sales_receipt_items(
	id integer not null primary key,
	sales_receipt_id integer,
	item_id integer,
	quantity double,
	price double
);

create table users(
	id integer not null primary key,
	username varchar(255),
	password varchar(255),
	email varchar(255),
	phone varchar(255),
	name varchar(255)
);
