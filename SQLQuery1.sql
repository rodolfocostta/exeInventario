create database exeInventario
use exeInventario

create table Cad_Clientes (
ID_Cli int identity primary key not null,
Nome_Cli varchar(max),
Telelfone_Cli varchar(30),
Email_Cli varchar(max));

select *from Cad_Clientes

create table Cad_Maquinas (
ID_Maq int identity primary key,
Modelo_Maq varchar(max),
Peças_Maq varchar(max));

select * from Cad_Maquinas

create table Inventario (
ID_Inv int identity primary key,
ID_Cli int,
Nome_Cli varchar (Max),
ID_Maq int,
Modelo_Maq varchar(max),
Quantidade int,
Valor real );

select *from Inventario
