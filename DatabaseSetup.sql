create database BlogAspNet

use BlogAspNet

create table Category(
Id int identity (1,1) primary key,
Name nvarchar(50),
);

create table Post(
Id int identity (1,1) primary key,
Title nvarchar(50),
Post nvarchar(2000),
Datetime date,
FK_CategoryId int,
foreign key (FK_CategoryId) references Category(Id) 
);
select * from Category
insert into Category (Name)
values ('Gaming'), 
('Sports')

insert into Post(Title,Post,Datetime,FK_CategoryId)
values ('Test Title','Test Post Content',CURRENT_TIMESTAMP,1)

select * from Post

delete from Post where Id = 5
