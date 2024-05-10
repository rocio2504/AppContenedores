CREATE PROCEDURE spMostrarContent

AS
BEGIN
    SELECT a.IdNumero AS NÚMERO, b.Descripcion as TIPO , c.Descripcion AS TAMAÑO, round(a.Peso,2) as PESO, ROUND(a.tara,2) AS TARA
 FROM CONTENEDOR as a
 inner join TIPOS as b on a.Tipo = b.IdTipo
 inner join TAMANIO AS c on a.Tamanio = c.IdTamanio
 
END
GO


-- =======================================================
-- Create Stored Procedure 
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Rocío Mamani
-- Create Date: 09/05/2024
-- Description: Insertar Contenedor a la BD
-- =============================================
CREATE PROCEDURE spGuardarContenedor

 @numero int ,
 @tipo varchar(50),
 @tamanio int,
 @peso float,
 @tara float
 
 AS
BEGIN
 
    -- Obtener el IdTipo correspondiente a la descripción proporcionada
DECLARE @idtipo int = ( SELECT IdTipo FROM TIPOS WHERE descripcion = @tipo)
DECLARE @idtamanio int = (SELECT IdTamanio FROM TAMANIO WHERE descripcion = @tamanio)

INSERT INTO CONTENEDOR VALUES (@numero,@idtipo,@idtamanio,@peso,@tara)
 
END
GO

CREATE PROCEDURE spActualizarContenedor
 @numero int ,
 @tipo varchar(50),
 @tamanio int,
 @peso float,
 @tara float
 
 AS
BEGIN
 
DECLARE @idtipo int = ( SELECT IdTipo FROM TIPOS WHERE descripcion = @tipo)
DECLARE @idtamanio int = (SELECT IdTamanio FROM TAMANIO WHERE descripcion = @tamanio)

update CONTENEDOR set IdNumero = @numero,
						  Tipo = @idtipo,
						  Tamanio = @idtamanio,
						  Peso = @peso,
						  tara = @tara
where IdNumero = @numero;
END
GO

ALTER PROCEDURE spLoadData 
@numero int 
AS
BEGIN
 
 SELECT a.IdNumero AS NÚMERO, b.Descripcion as TIPO , c.Descripcion AS TAMAÑO, round(a.Peso,2) as PESO, round(a.tara,2) AS TARA
 FROM CONTENEDOR as a
 inner join TIPOS as b on a.Tipo = b.IdTipo
 inner join TAMANIO AS c on a.Tamanio = c.IdTamanio 
 where a.IdNumero = @numero;
END
GO


CREATE PROCEDURE spEliminarContenedor 
 
 @numero int 
 AS
BEGIN
 
DELETE FROM CONTENEDOR WHERE IdNumero = @numero;
END
GO





CREATE PROCEDURE spCargarTipo

 AS
BEGIN
SELECT * FROM TIPOS
 
END
GO

CREATE PROCEDURE spCargarTamanio

 AS
BEGIN
SELECT * FROM TAMANIO
 
END
GO