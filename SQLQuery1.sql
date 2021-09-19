create database studentscorelite;

use studentscorelite;

create table Tests(
	id int primary key identity(1,1),
	name varchar(45),
	course varchar(45),
);

create table Students(
	id int primary key identity(1,1),
	name varchar(45)
);

create table Scores(
	id int primary key identity(1,1),
	grade decimal,
	idTest int foreign key references Tests(id),
	idStudent int foreign key references Students(id)
);