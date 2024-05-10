CREATE DATABASE Db_contenedores


CREATE TABLE TIPOS(
 IdTipo int primary key,
 Descripcion varchar(50)
 
 )

 CREATE TABLE TAMANIO(
 IdTamanio int primary key,
 Descripcion int
 )


CREATE TABLE CONTENEDOR (
 IdNumero int primary key,
 Tipo int,
 Tamanio int,
 Peso float,
 tara float,
 FOREIGN KEY (Tipo) REFERENCES TIPOS(IdTipo),
 FOREIGN KEY (Tamanio) REFERENCES TAMANIO(IdTamanio)
 )

 
 