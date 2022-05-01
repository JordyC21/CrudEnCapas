create database BarDb

go

use BarDb

go

select *from Producto

create table Producto (
Id int identity (1,1) primary key,
Nombre varchar (100),
Descripcion varchar (100),
Precio float,
Cantidad int,
Estado int
)

go

drop table Producto


insert into Producto values 
 ('Cubata','Guaraná',0.90, 40, 1),
 ('Chamaco','250 ml',3.00, 50, 1),
 ('Agua','mineral',1.5, 100, 1),
 ('Powerade','Limón',1.50, 40, 1),
 ('Tequila','250 ml',45.00, 0, 0);

 go


--------------------------------------------
--ESTOS SON LOS PROCEDIMIENTOS ALMACENADOS-- 
--------------------------------------------

----------MOSTRAR-----------
create proc MostrarProductos
as
select *from Producto
go

exec MostrarProductos

--------INSERTAR------------
create proc InsetarProductos
@nomprod varchar (100),
@descripcion varchar (100),
@precio float,
@cantidad int,
@estado int
as
insert into Producto values (@nomprod,@descripcion,@precio,@cantidad,@estado)

go

exec InsetarProductos 'Pepsi','250 ml',45.00, 0, 0

-------ELIMINAR-------------
create proc EliminarProductos
@idprod int
as
delete from Producto where Id=@idprod
go

Exec EliminarProductos 7

-------EDITAR--------------
create proc EditarProductos
@idproducto varchar (100),
@nomprod varchar (100),
@descripcion varchar (100),
@precio float,
@cantidad int,
@estado int
as
update Producto set Nombre=@nomprod, Descripcion = @descripcion, Precio = @precio, Cantidad = @cantidad, Estado = @estado
where Id = @idproducto
go

exec EditarProductos 6, 'Cocacola','250 ml',45.00, 0, 0



Id int identity (1,1) primary key,
Nombre varchar (100),
Descripcion varchar (100),
Precio float,
Cantidad int,
Estado int