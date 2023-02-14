create database day2
use day2
create table customermaster
(CUSTOMER_NUMBER VARCHAR(40) PRIMARY KEY,
FIRSTNAME VARCHAR(20)NOT NULL,
middlename VARCHAR(20),
lastname VARCHAR(20) NOT NULL,
CUSTOMER_CITY VARCHAR(20) NOT NULL,
CUSTOMER_CONTACT_NO VARCHAR(10) NOT NULL,
occupation VARCHAR(20) NOT NULL,
CUSTOMER_DATE_OF_BIRTH DATE NOT NULL) 

create table loan_details(
customer_number varchar(40) foreign key references customermaster(CUSTOMER_NUMBER ),
branch_id int,
loan_aount bigint)
create table account_master(
account_number varchar(10) primary key,
customer_number varchar(40) foreign key references customermaster(CUSTOMER_NUMBER ),
branch_id int foreign key references branch_master(branch_id),
opening_balance bigint,
account_opening_date date ,
account_type varchar(10),
account_status varchar(10))
create table branch_master
(branch_id int primary key ,
branch_name varchar(10),
branch_city varchar(10))

create table transaction_details
(transaction_number int primary key,
account_number varchar(10) foreign key references account_master(account_number),
date_of_transaction date,medium_of_transaction varchar(10),
transaction_type varchar(10),
transaction_amount bigint)