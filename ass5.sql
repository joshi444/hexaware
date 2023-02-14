use hexa

create table Student(
id int primary key identity,
name varchar(30),
gender varchar(20),
branch varchar(30),
branchid int
)

insert into student values
('joshi','male','cse',1),
('naruto','male','cse',3),
('hinata','female','it',2),
('peter','male','ece',1),
('mj','female','it',2)

create function Branchid(@bid int)
returns table
as
return (select * from Student where branchid=@bid)

select * from dbo.Branchid(2)


-- function to display student information by Gender
create function GetGender(@gender varchar(20))
returns table
as 
return (select * from Student where gender=@gender)

select * from dbo.GetGender('male')

/*calculate NetSales amount for all order_Id using Functions. Refer the below table
Sales.order_Items tabe from bikestores Database*/

use bikestores

select * from sales.order_items

alter function GetNetsales(@netsale decimal)
returns table
as
return (select * from sales.order_items where list_price-discount=@netsale)

select * from dbo.GetNetsales(@netsales)


/*create a trigger to delete the record from tblEmployee table and insert deleted record 
 details in tblEmployeeaudit Table  (use after or For trigger)*/

 use day2

 select * from tblEmployee
 select * from tblEmployeeaudit
 drop table tblEmployee
 drop table tblEmployeeaudit
 create table tblEmployee(
id int primary key,
name varchar(30),
salary int,
gender nvarchar(20),
departmentid int
)

insert into tblEmployee values
(1,'peter',5000,'male',3),
(2,'lee',3400,'male',2),
(3,'tsunade',6000,'female',1)

create table tblEmployeeaudit(
 id int identity(1,1) primary key,
 AuditData nvarchar(1000)
 )

 create trigger tr_Employee_fordelete
 on tblEmployee
 for delete
 as
 begin
 declare @id int 
 select @id=id from deleted
 insert into tblEmployeeaudit values('New Employee with id'+cast(@id as nvarchar)+
 'is deleted at'+cast(getdate() as nvarchar(30)))
 end
 drop trigger tr_Employee_fordelete

 delete from tblEmployee where id=3
 insert into tblEmployee values(3,'pam',6000,'female',1)


 /*List out the product details which is not at all sold using subquery.
refer tblProduct and tblproductSales tables
*/


create table tblProducts
(
id int identity primary key,
name nvarchar(50),
description nvarchar(250)
)

create table tblProductsales(
id int primary key identity,
productid int foreign key references tblProducts(id),
unitprice int,
quantitysold int
)


insert into tblProducts values
('tv','32 inch black colour LCd tv'),
('laptop','ryzen processor  laptop'),
('desktop','hp  desktop')

insert into tblProductsales values
(2,450,5),
(3,150,7),
(3,750,4),
(2,250,9)

select * from tblProducts
select * from tblProductsales

select id,name,description from tblProducts where id  not in
(
select productid  from tblProductsales
)


select id,name,description from tblProducts
  right join tblProductsales
on tblProducts.id=tblProductsales.id
where tblProducts.id is null