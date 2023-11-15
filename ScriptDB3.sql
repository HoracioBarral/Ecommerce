select * from Roles
select * from Usuarios
ALTER TABLE Usuarios
ADD Pass VARCHAR(50);

ALTER TABLE Usuarios
DROP COLUMN Clave;

insert into Roles values ('1'),('2')


