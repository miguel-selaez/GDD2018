USE GD1C2018;
GO

--CREATE SCHEMA NPM; 
--GO
print (CONCAT('Creacion de tablas ', CONVERT(VARCHAR, GETDATE(), 114)))

--------------------TABLAS---------------------------------------------
CREATE TABLE NPM.Usuario(
	id_usuario int NOT NULL IDENTITY,
	nombre_usuario nvarchar(255) NOT NULL,
	pass varbinary(256) NOT NULL,
	baja_u bit NOT NULL DEFAULT 1,
	intentos_fallidos int NULL,
	id_persona int NULL,
	PRIMARY KEY(id_usuario)
)

GO 

CREATE TABLE NPM.Reserva(
	id_reserva numeric(18,0) NOT NULL,
	id_usuario_creacion int NOT NULl,
	id_hotel int NOT NULL,
	id_regimen int NOT NULL,
	id_cliente int NOT NULL,
	fecha_creacion datetime NULL,
	fecha_inicio datetime NULL,
	fecha_fin datetime NULL,
	id_estado int NULL,
	PRIMARY KEY(id_reserva)
)

GO

CREATE TABLE NPM.Estadia(
	id_estadia int NOT NULL IDENTITY,
	id_reserva numeric(18,0) NOT NULL,
	id_usuario_ingreso int NOT NULL,
	fecha_ingreso datetime NULL,
	id_usuario_salida int NOT NULL,
	fecha_salida datetime NULL,
	PRIMARY KEY (id_estadia)
)

GO

CREATE TABLE NPM.Habitacion(
	id_habitacion int NOT NULL IDENTITY,
	numero numeric(18,0) NOT NULL,
	id_hotel int NOT NULL,
	piso numeric(18,0) NOT NULL,
	frente nvarchar(50) NOT NULL,
	id_tipo_habitacion numeric(18,0) NOT NULL,
	baja_ha bit NULL,
	PRIMARY KEY(id_habitacion)
)

GO

CREATE TABLE NPM.Tipo_Habitacion(
	id_tipo_habitacion numeric(18,0) NOT NULL, 
	descripcion_th nvarchar(255) NULL, 
	porcentual numeric(18,2) NOT NULL,
	baja_th bit NOT NULL DEFAULT 1,
	PRIMARY KEY(id_tipo_habitacion)
)

GO

CREATE TABLE NPM.Habitacion_Reservada(
	id_habitacion int NOT NULL,
	id_reserva numeric(18,0) NOT NULL,
	PRIMARY KEY(id_reserva, id_habitacion)
)
 
 GO


CREATE TABLE NPM.Cliente(
	id_cliente int NOT NULL IDENTITY,
	id_persona int NULL,
	puntos int NULL,
	baja_cl bit NOT NULL,
	PRIMARY KEY(id_cliente)
)

GO

CREATE TABLE NPM.Persona(
	id_persona int NOT NULL IDENTITY,
	nombre nvarchar(255) NULL,
	apellido nvarchar(255) NULL,
	fecha_nacimiento datetime NULL,
	telefono nvarchar(10) NULL,
	id_tipo_documento int NULL,
	numero_documento numeric(18,0) NOT NULL,
	id_direccion int NULL,
	mail nvarchar(255),
	id_nacionalidad int,
	inconsistente bit NOT NULL,
	PRIMARY KEY(id_persona)
)

GO

CREATE TABLE NPM.Tipo_Documento(
	id_tipo_documento int NOT NULL IDENTITY,
	descripcion_td nvarchar(50),
	baja_td bit NOT NULL,
	PRIMARY KEY(id_tipo_documento)
)

CREATE TABLE NPM.Huesped_x_Estadia(
	id_cliente int NOT NULL,
	id_estadia int NOT NULL,
	PRIMARY KEY(id_cliente, id_estadia)
)

GO

CREATE TABLE NPM.Consumible(
	id_consumible numeric(18,0) NOT NULL,
	descripcion_cb nvarchar(255) NULL,
	precio numeric(18,2) NULL,
	PRIMARY KEY(id_consumible)
)

GO 

CREATE TABLE NPM.Consumo(
	id_consumo int NOT NULL IDENTITY,
	id_estadia int NOT NULL,
	id_consumible numeric(18,0) NULL,
	id_habitacion int NOT NULL,
	id_reserva numeric(18,0) NOT NULL,
	cantidad numeric(18,0) NULL,
	PRIMARY KEY(id_consumo)
)

GO

CREATE TABLE NPM.Item_Factura(
	id_item_factura int NOT NULL IDENTITY,
	id_consumo int NULL,
	leyenda nvarchar(100) NULL,
	subtotal numeric(18,2) NULL,
	id_factura numeric(18,0) NOT NULL,
	PRIMARY KEY(id_item_factura)
)

GO

CREATE TABLE NPM.Factura(
	id_factura numeric(18,0) NOT NULL,
	id_estadia int NOT NULL,
	id_cliente int NOT NULL,	
	dias_alojamiento int NOT NULL,
	dias_faltantes int NULL,
	fecha_facturacion datetime,
	id_tipo_pago int NULL,
	total_factura numeric(18,2) NULL,
	PRIMARY KEY(id_factura)
)

GO 

CREATE TABLE NPM.Tipo_Pago(
	id_tipo_pago int NOT NULL IDENTITY,
	descripcion_tp nvarchar(50) NULL,
	baja_tp bit NOT NULL DEFAULT 1,
	PRIMARY KEY(id_tipo_pago)
)

GO 

CREATE TABLE NPM.Regimen(
	id_regimen int NOT NULL IDENTITY,
	descripcion_r nvarchar(255) NULL,
	precio numeric(18,2) NOT NULL,
	baja_r bit NOT NULL,
	PRIMARY KEY (id_regimen)
)

GO 

CREATE TABLE NPM.Hotel(
	id_hotel int NOT NULL IDENTITY,
	nombre nvarchar(50) NOT NULL,
	mail nvarchar(50) NULL,
	telefono nvarchar(10) NULL,
	id_direccion int NOT NULL,
	estrellas numeric(18,0) NOT NULL,
	fecha_creacion datetime NOT NULL,
	baja_ho bit NOT NULL DEFAULT 1,
	PRIMARY KEY (id_hotel)
)

GO 

CREATE TABLE NPM.Regimen_x_Hotel(
	id_hotel int NOT NULL,
	id_regimen int NOT NULL,
	PRIMARY KEY (id_hotel, id_regimen)
)

GO

CREATE TABLE NPM.Cierre_Temporal(
	id_hotel int NOT NULL IDENTITY,
	motivo_cierre nvarchar(100) NOT NULL,
	fecha_inicio datetime NOT NULL,
	fecha_fin datetime NULL,
	PRIMARY KEY (id_hotel, fecha_inicio)
)

GO

CREATE TABLE NPM.Direccion(
	id_direccion int NOT NULL IDENTITY,
	calle nvarchar(255) NOT NULL,
	nro_calle numeric(18,0) NOT NULL,
	piso numeric(18,0) NULL,
	departamento nvarchar(50) NULL,
	ciudad nvarchar(255) NULL,
	id_pais int NULL,
	PRIMARY KEY(id_direccion)
)

GO
	
CREATE TABLE NPM.Pais(
	id_pais int NOT NULL IDENTITY,
	descripcion_pa nvarchar(50),
	nacionalidad nvarchar(255),
	baja_pa bit NOT NULL DEFAULT 1,
	PRIMARY KEY(id_pais)
)

GO

CREATE TABLE NPM.Reserva_Modificada(
	id_reserva numeric(18,0) NOT NULL,
	id_usuario int NOT NULL,
	id_hotel int NOT NULL,
	id_regimen int NOT NULL,
	fecha_modificacion datetime NOT NULL,
	fecha_inicio datetime NOT NULL,
	fecha_fin datetime NOT NULL,
	cant_noches int NOT NULL,
	habitaciones int NOT NULL,
	PRIMARY KEY (id_reserva, fecha_modificacion)
)

GO

CREATE TABLE NPM.Reserva_Cancelada(
	id_reserva numeric(18,0) NOT NULL,
	motivo nvarchar(255),
	fecha_cancelacion datetime NOT NULL,
	id_usuario int NOT NULL,
	PRIMARY KEY (id_reserva, fecha_cancelacion)
)

GO

CREATE TABLE NPM.Estado_Reserva(
	id_estado int NOT NULL IDENTITY,
	descripcion_er nvarchar(255) NOT NULL,
	bajar_er bit NOT NULL DEFAULT 1,
	PRIMARY KEY (id_estado)
)

GO

CREATE TABLE NPM.Usuario_x_Hotel(
	id_hotel int NOT NULL,
	id_usuario int NOT NULL,
	PRIMARY KEY(id_hotel, id_usuario)
)

GO

CREATE TABLE NPM.Funcion(
	id_funcion int NOT NULL IDENTITY,
	descripcion_f nvarchar(255) NOT NULL,
	baja_f bit NOT NULL DEFAULT 1,
	PRIMARY KEY(id_funcion)
)

GO

CREATE TABLE NPM.Funciones_x_Rol(
	id_funcion int NOT NULL,
	id_rol int NOT NULL,
	PRIMARY KEY(id_funcion, id_rol)
)

GO

CREATE TABLE NPM.Rol(
	id_rol int NOT NULL IDENTITY,
	descripcion_rl nvarchar(255) NOT NULL,
	baja_rl bit NOT NULL DEFAULT 1,
	PRIMARY KEY(id_rol)
)

GO

CREATE TABLE NPM.Roles_x_Usuario(
	id_usuario int NOT NULL,
	id_rol int NOT NULL,
	PRIMARY KEY(id_usuario, id_rol)
)

GO

print (CONCAT('Creacion de SPs ', CONVERT(VARCHAR, GETDATE(), 114)))

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Direccion')
	DROP PROCEDURE NPM.P_Guardar_Direccion
GO 	

CREATE PROCEDURE NPM.P_Guardar_Direccion  
	@id int,
	@calle nvarchar(255),
	@nro_calle numeric(18,0),
	@piso numeric(18,0),
	@departamento nvarchar(50),
	@ciudad nvarchar(255),
	@id_pais int,
	@id_out int OUTPUT
AS
BEGIN 
	IF @id IS NULL OR @id = 0
	BEGIN 
		INSERT INTO NPM.Direccion (calle, nro_calle, piso, departamento, ciudad, id_pais)
		VALUES (@calle, @nro_calle, @piso, @departamento, @ciudad, @id_pais)

		SELECT @id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE NPM.Direccion 
		SET 
			calle = @calle, 
			nro_calle = @nro_calle,
			piso = @piso,
			departamento = @departamento, 
			ciudad = @ciudad,
			id_pais = @id_pais
		WHERE 
			id_direccion = @id;

		SELECT @id_out = @id;
	END

	RETURN @id_out
END

GO 
--HOTEL
USE GD1C2018;
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Alta_Hotel')
	DROP PROCEDURE NPM.P_Alta_Hotel
GO 	

CREATE PROCEDURE NPM.P_Alta_Hotel  
	@id int,
	@nombre nvarchar(255),
	@mail nvarchar(50),
	@telefono nvarchar(10),
	@id_direccion int,
	@estrellas numeric(18,0),
	@fecha_creacion datetime,
	@baja int,
	@id_out int OUTPUT
AS
BEGIN 
	IF @id IS NULL
	BEGIN 
		INSERT INTO NPM.Hotel (nombre,mail,telefono,id_direccion,estrellas,fecha_creacion,baja_ho)
		VALUES (@nombre,@mail,@telefono,@id_direccion,@estrellas,@fecha_creacion,@baja)

		SELECT @id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE NPM.Hotel 
		SET 
			nombre = @nombre, 
			mail = @mail,
			telefono = @telefono,
			id_direccion = @id_direccion, 
			estrellas = @estrellas,
			fecha_creacion = @fecha_creacion,
			baja_ho = @baja
		WHERE 
			id_hotel = @id;

		SELECT @id_out = @id;
	END

	RETURN @id_out
END

GO
--PERSONA
USE GD1C2018;
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Alta_Persona')
	DROP PROCEDURE NPM.P_Alta_Persona
GO 	

CREATE PROCEDURE NPM.P_Alta_Persona  
	@id int,
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@fecha_nac datetime,
	@telefono nvarchar(10),
	@tipo_doc int,
	@nro_doc numeric(18,0),
	@id_direc int,
	@mail nvarchar(255),
	@nacionalidad int,
	@inconsistente bit,
	@id_out int OUTPUT
AS
BEGIN 
	IF @id IS NULL OR @id = 0
	BEGIN 
		INSERT INTO NPM.Persona(nombre,apellido,fecha_nacimiento,telefono,id_tipo_documento,numero_documento,id_direccion,mail,id_nacionalidad,inconsistente)
		VALUES (@nombre,@apellido,@fecha_nac,@telefono,@tipo_doc,@nro_doc,@id_direc,@mail,@nacionalidad,@inconsistente)

		SELECT @id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE NPM.Persona 
		SET 
			nombre = @nombre, 
			apellido = @apellido,
			fecha_nacimiento = @fecha_nac,
			telefono = @telefono,
			id_tipo_documento = @tipo_doc,
			numero_documento = @nro_doc,
			id_direccion = @id_direc,
			mail = @mail,
			id_nacionalidad = @nacionalidad,
			inconsistente = @inconsistente
		WHERE 
			id_persona = @id;

		SELECT @id_out = @id;
	END

	RETURN @id_out
END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Login')
	DROP PROCEDURE NPM.P_Login
GO 	

CREATE PROCEDURE NPM.P_Login  
	@user nvarchar(255),
	@pass nvarchar(50)
AS
BEGIN 
	DECLARE @pass_enc varbinary(256)
	SELECT @pass_enc = HASHBYTES('SHA2_256', @pass);

	SELECT 
		u.id_usuario,
		u.nombre_usuario,
		'' as pass,
		u.baja_u,
		u.intentos_fallidos,
		p.id_persona,
		p.nombre,
		p.apellido,
		NPM.FX_Mostrar_Fecha(p.fecha_nacimiento) as 'fecha_nacimiento',
		p.telefono,
		p.numero_documento,
		p.mail,
		p.inconsistente,
		t.*,
		d.*,
		pa.*
	FROM
		NPM.Usuario as u
		LEFT JOIN NPM.Persona as p
			ON u.id_persona = p.id_persona
		LEFT JOIN NPM.Direccion as d
			ON p.id_direccion = d.id_direccion
		LEFT JOIN NPM.Tipo_Documento as t
			ON p.id_tipo_documento = t.id_tipo_documento
		LEFT JOIN NPM.Pais as pa
			ON pa.id_pais = d.id_pais
	WHERE
		UPPER(u.nombre_usuario) = UPPER(@user)
		AND u.pass = @pass_enc
		AND u.baja_u = 0
	 	
END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Roles_x_Usuario')
	DROP PROCEDURE NPM.P_Obtener_Roles_x_Usuario
GO 	

CREATE PROCEDURE NPM.P_Obtener_Roles_x_Usuario  
	@id int
AS
BEGIN 
	SELECT 
		R.*
	FROM 
		NPM.Rol as R
		INNER JOIN NPM.Roles_x_Usuario as RU
			ON R.id_rol = RU.id_rol
	WHERE 
		RU.id_usuario = @id
		AND R.baja_rl = 0
	ORDER BY
		R.descripcion_rl

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Hoteles_Asignados')
	DROP PROCEDURE NPM.P_Obtener_Hoteles_Asignados
GO 	

CREATE PROCEDURE NPM.P_Obtener_Hoteles_Asignados  
	@id int
AS
BEGIN 
	SELECT 
		H.id_hotel,
		H.nombre, 
		H.mail,
		H.telefono, 
		H.estrellas,
		CONVERT(varchar(10), H.fecha_creacion, 112) as 'fecha_creacion',
		H.baja_ho,
		D.*,
		pa.*
	FROM 
		NPM.Hotel as H
		INNER JOIN NPM.Usuario_x_Hotel as HU
			ON H.id_hotel = HU.id_hotel
		LEFT JOIN NPM.Direccion as D
			ON D.id_direccion = H.id_direccion
		LEFT JOIN NPM.Pais as pa
			ON pa.id_pais = d.id_pais
	WHERE 
		HU.id_usuario = @id
		AND H.baja_ho = 0
	ORDER BY
		H.Nombre

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Funciones_x_Rol')
	DROP PROCEDURE NPM.P_Obtener_Funciones_x_Rol
GO 	

CREATE PROCEDURE NPM.P_Obtener_Funciones_x_Rol 
	@id int
AS
BEGIN 
	SELECT 
		F.*
	FROM 
		NPM.Funcion as F
		INNER JOIN Funciones_x_Rol as FR
			ON F.id_funcion = FR.id_funcion
	WHERE 
		FR.id_rol = @id
		AND F.baja_f = 0
	ORDER BY
		F.descripcion_f

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Roles')
	DROP PROCEDURE NPM.P_Obtener_Roles
GO 	

CREATE PROCEDURE NPM.P_Obtener_Roles  
	@descripcion nvarchar(255),
	@baja bit
AS
BEGIN 
	SELECT 
		R.*
	FROM 
		NPM.Rol as R
	WHERE
		(R.descripcion_rl like '%'+ @descripcion + '%' OR @descripcion IS NULL)
		AND (R.baja_rl = @baja OR @baja IS NULL)
	ORDER BY
		R.descripcion_rl

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='FX_Mostrar_Fecha')
	DROP FUNCTION NPM.FX_Mostrar_Fecha
GO 	

CREATE FUNCTION NPM.FX_Mostrar_Fecha(@fecha datetime)  
RETURNS varchar(10)   
AS   
BEGIN  
    DECLARE @ret varchar(10); 
	IF (@fecha IS NULL) 
		 RETURN NULL;
	ELSE
		SELECT @ret = CONVERT(varchar(10), @fecha, 112)
    
	RETURN @ret;  
END;
 
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Funciones')
	DROP PROCEDURE NPM.P_Obtener_Funciones
GO 	

CREATE PROCEDURE NPM.P_Obtener_Funciones 
	@baja bit
AS
BEGIN 
	SELECT 
		F.*
	FROM 
		NPM.Funcion as F
	WHERE 
		F.baja_f = @baja
		AND F.descripcion_f <> 'ABM USUARIO'
	ORDER BY
		F.descripcion_f

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Rol')
	DROP PROCEDURE NPM.P_Guardar_Rol
GO 	

CREATE PROCEDURE NPM.P_Guardar_Rol 
	@id int, 
	@descripcion nvarchar(255),
	@baja bit
AS
BEGIN 
	IF @id = 0
	BEGIN 
		INSERT INTO NPM.Rol (descripcion_rl, baja_rl)
		VALUES (@descripcion, @baja)

		SELECT id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		UPDATE NPM.Rol 
		SET 
			descripcion_rl = @descripcion,
			baja_rl = @baja
		WHERE 
			id_rol = @id;

		SELECT id_out = @id;

		DELETE Funciones_x_Rol
		WHERE 
			id_rol = @id;
	END

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Funcion_x_Rol')
	DROP PROCEDURE NPM.P_Guardar_Funcion_x_Rol
GO 	

CREATE PROCEDURE NPM.P_Guardar_Funcion_x_Rol 
	@id_funcion int, 
	@id_rol int
AS
BEGIN 
	INSERT INTO NPM.Funciones_x_Rol(id_funcion, id_rol)
	VALUES (@id_funcion, @id_rol)
END
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Usuarios')
	DROP PROCEDURE NPM.P_Obtener_Usuarios
GO 	

CREATE PROCEDURE NPM.P_Obtener_Usuarios  
	@usuario nvarchar(255),
	@baja bit
AS
BEGIN 
	SELECT 
		u.id_usuario,
		u.nombre_usuario,
		'' as pass,
		u.baja_u,
		u.intentos_fallidos,
		p.id_persona,
		p.nombre,
		p.apellido,
		NPM.FX_Mostrar_Fecha(p.fecha_nacimiento) as 'fecha_nacimiento',
		p.telefono,
		p.numero_documento,
		p.mail,
		p.inconsistente,
		t.*,
		d.*,
		pa.*
	FROM
		NPM.Usuario as u
		LEFT JOIN NPM.Persona as p
			ON u.id_persona = p.id_persona
		LEFT JOIN NPM.Direccion as d
			ON p.id_direccion = d.id_direccion
		LEFT JOIN NPM.Tipo_Documento as t
			ON p.id_tipo_documento = t.id_tipo_documento
		LEFT JOIN NPM.Pais as pa
			ON pa.id_pais = d.id_pais
	WHERE
		(U.nombre_usuario like '%'+ @usuario + '%' OR @usuario IS NULL)
		AND (U.baja_u = @baja OR @baja IS NULL)
	ORDER BY
		U.nombre_usuario

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Hoteles')
	DROP PROCEDURE NPM.P_Obtener_Hoteles
GO 	

CREATE PROCEDURE NPM.P_Obtener_Hoteles  
	@nombre nvarchar(255),
	@baja bit
AS
BEGIN 
	SELECT 
		H.id_hotel,
		H.nombre,
		H.mail,
		H.telefono,
		H.estrellas,
		NPM.FX_Mostrar_Fecha(H.fecha_creacion) as 'fecha_creacion',
		H.baja_ho,
		D.*,
		pa.*
	FROM 
		NPM.Hotel as H
		LEFT JOIN NPM.Direccion as D
			ON H.id_direccion = D.id_direccion
		LEFT JOIN NPM.Pais as pa
			ON pa.id_pais = d.id_pais
	WHERE
		(H.nombre like '%'+ @nombre + '%' OR @nombre IS NULL)
		AND (H.baja_ho = @baja OR @baja IS NULL)
	ORDER BY
		H.nombre

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_TiposDocumento')
	DROP PROCEDURE NPM.P_Obtener_TiposDocumento
GO 	

CREATE PROCEDURE NPM.P_Obtener_TiposDocumento  
	@descripcion nvarchar(255),
	@baja bit
AS
BEGIN 
	SELECT 
		T.*
	FROM 
		NPM.Tipo_Documento as T
	WHERE
		(T.descripcion_td like '%'+ @descripcion + '%' OR @descripcion IS NULL)
		AND (T.baja_td = @baja OR @baja IS NULL)
	ORDER BY
		T.descripcion_td

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Usuario')
	DROP PROCEDURE NPM.P_Guardar_Usuario
GO 	

CREATE PROCEDURE NPM.P_Guardar_Usuario 
	@id int, 
	@nombre_usuario nvarchar(255),
	@pass nvarchar(50),
	@baja bit, 
	@id_persona int,
	@id_out int out
AS
BEGIN 
	IF @id = 0
	BEGIN 
		INSERT INTO NPM.Usuario(nombre_usuario, pass, baja_u, intentos_fallidos, id_persona)
		VALUES (@nombre_usuario, HASHBYTES('SHA2_256', @pass), @baja, 0, @id_persona)

		SELECT @id_out = @@IDENTITY
	END 
	ELSE 
	BEGIN 
		IF @pass IS NULL
		BEGIN
			UPDATE NPM.Usuario
			SET 
				nombre_usuario = @nombre_usuario,
				baja_u = @baja,
				id_persona = @id_persona
			WHERE 
				 id_usuario = @id;
		END 
		ELSE
		BEGIN
			UPDATE NPM.Usuario
			SET 
				nombre_usuario = @nombre_usuario,
				pass = HASHBYTES('SHA2_256', @pass),
				baja_u = @baja,
				id_persona = @id_persona
			WHERE 
				 id_usuario = @id;
		END

		SELECT @id_out = @id;

		DELETE NPM.Usuario_x_Hotel
		WHERE 
			id_usuario = @id;

		DELETE NPM.Roles_x_Usuario
		WHERE 
			id_usuario = @id;

		RETURN @id_out;
	END

END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Rol_x_Usuario')
	DROP PROCEDURE NPM.P_Guardar_Rol_x_Usuario
GO 	

CREATE PROCEDURE NPM.P_Guardar_Rol_x_Usuario 
	@id_usuario int, 
	@id_rol int
AS
BEGIN 
	INSERT INTO NPM.Roles_x_Usuario(id_usuario, id_rol)
	VALUES (@id_usuario, @id_rol)
END
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Guardar_Usuario_x_Hotel')
	DROP PROCEDURE NPM.P_Guardar_Usuario_x_Hotel
GO 	

CREATE PROCEDURE NPM.P_Guardar_Usuario_x_Hotel 
	@id_usuario int,
	@id_hotel int	
AS
BEGIN 
	INSERT INTO NPM.Usuario_x_Hotel(id_hotel, id_usuario)
	VALUES (@id_hotel, @id_usuario)
END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Tipos_Habitacion_x_Hotel')
	DROP PROCEDURE NPM.P_Obtener_Tipos_Habitacion_x_Hotel
GO 	

CREATE PROCEDURE NPM.P_Obtener_Tipos_Habitacion_x_Hotel  
	@id_hotel int
AS
BEGIN 
	SELECT 
		DISTINCT
		T.*
	FROM 
		NPM.Tipo_Habitacion as T
		INNER JOIN NPM.Habitacion as Ha
			ON Ha.id_tipo_habitacion = T.id_tipo_habitacion
		INNER JOIN NPM.Hotel as Ho
			ON Ho.id_hotel = Ha.id_hotel			
	WHERE
		Ho.id_hotel = @id_hotel
		AND T.baja_th = 0
	ORDER BY
		T.descripcion_th	
END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Habitaciones_x_Pedido')
	DROP PROCEDURE NPM.P_Obtener_Habitaciones_x_Pedido
GO 	

CREATE PROCEDURE NPM.P_Obtener_Habitaciones_x_Pedido  
	@id_hotel int,
	@id_tipo_habitacion decimal,
	@fecha_actual datetime,
	@desde datetime, 
	@hasta datetime
AS
BEGIN 
	SELECT 
		Ha.*,
		TH.*
	FROM 
		Habitacion as Ha
		INNER JOIN NPM.Tipo_Habitacion as TH
			ON Ha.id_tipo_habitacion = TH.id_tipo_habitacion
	WHERE 
		Ha.id_hotel = @id_hotel
		AND Ha.id_tipo_habitacion = @id_tipo_habitacion
		AND Ha.baja_ha = 0
		AND id_habitacion NOT IN (
			SELECT 
				DISTINCT 
				HR.id_habitacion
			FROM 
				NPM.Reserva as R
				INNER JOIN NPM.Habitacion_Reservada as HR	
					ON HR.id_reserva = R.id_reserva
			WHERE
				R.id_hotel = 3
				AND R.fecha_inicio >= @fecha_actual 
				AND
				(
					(R.fecha_inicio <= @desde AND R.fecha_fin >= @desde)
					OR  
					(R.fecha_inicio <= @hasta AND R.fecha_fin >= @hasta)
				)				
		)
	ORDER BY Ha.numero
END

GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name='P_Obtener_Regimenes_x_Hotel')
	DROP PROCEDURE NPM.P_Obtener_Regimenes_x_Hotel
GO 	

CREATE PROCEDURE NPM.P_Obtener_Regimenes_x_Hotel  
	@id_hotel int
AS
BEGIN 
	SELECT 
		Re.*
	FROM 
		NPM.Regimen as Re
		INNER JOIN NPM.Regimen_x_Hotel as RH
			ON Re.id_regimen = RH.id_regimen			
	WHERE
		RH.id_hotel = @id_hotel
		AND Re.baja_r = 0
	ORDER BY
		Re.descripcion_r	
END

GO


GO
print (CONCAT('INSERTS ', CONVERT(VARCHAR, GETDATE(), 114)))
---------------------------------- INSERTS ------------------------------
BEGIN TRY
BEGIN TRANSACTION
-- ROLES
INSERT INTO NPM.Rol VALUES 
('ADMINISTRADOR',0),
('RECEPCIONISTA',0),
('GUEST',0)

-- FUNCIONES
INSERT INTO NPM.Funcion VALUES 
('ABM ROL', 0),
('ABM USUARIO',0),
('ABM CLIENTE',0),
('ABM HOTEL',0),
('ABM HABITACION',0),
('ABM REGIMEN',0),
('ABM RESERVA',0),
('REGISTRAR ESTADIA',0),
('REGISTRAR CONSUMOS',0),
('LISTADO ESTADISTICO',0)

-- USUARIO
DECLARE @id_persona_usuario int 
DECLARE @id_persona_gen int 

EXEC NPM.P_Alta_Persona 
	null,
	'Administrador General',
	null,
	null,
	null,
	null,
	1,
	null,
	null,
	null,
	0,
	@id_persona_usuario OUTPUT

EXEC NPM.P_Alta_Persona 
	null,
	'Usuario Generico',
	null,
	null,
	null,
	null,
	1,
	null,
	null,
	null,
	0,
	@id_persona_gen OUTPUT

INSERT INTO NPM.Usuario VALUES
('admin', HASHBYTES('SHA2_256', CONVERT(nvarchar(50), 'w23e')), 0, 0, @id_persona_usuario),
('generico', HASHBYTES('SHA2_256', CONVERT(nvarchar(50), 'gen123*')), 0, 0, @id_persona_gen)
 
 select * from NPM.Usuario
-- FUNCIONES X ROL
INSERT INTO NPM.Funciones_x_Rol (id_rol, id_funcion) VALUES 
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(2, 3),
(2, 7),
(2, 8),
(2, 9),
(3,7)

-- ROLES X USUARIO
INSERT INTO NPM.Roles_x_Usuario (id_usuario, id_rol) VALUES (1, 1)
INSERT INTO NPM.Roles_x_Usuario (id_usuario, id_rol) VALUES (2, 3)

--PAIS
INSERT INTO NPM.Pais VALUES ('ARGENTINA','ARGENTINO',0)

--TIPO_DOCUMENTO
INSERT NPM.Tipo_Documento VALUES ('DNI',0) 
INSERT NPM.Tipo_Documento VALUES ('PASAPORTE',0) 

-- ESTADO RESERVA
INSERT NPM.Estado_Reserva VALUES 
('CORRECTA', 0),
('MODIFICADA', 0),
('CANCELADA POR RECEPCION', 0),
('CANCELADA POR CLIENTE', 0),
('CANCELADA POR NO-SHOW', 0),
('CON INGRESO', 0)

-- REGIMEN
INSERT INTO NPM.Regimen
SELECT DISTINCT Regimen_Descripcion,Regimen_Precio,0 FROM gd_esquema.Maestra


-- TIPO DE HABITACION
INSERT INTO NPM.Tipo_Habitacion
SELECT 
	DISTINCT
	Habitacion_Tipo_Codigo,
	Habitacion_Tipo_Descripcion,
	Habitacion_Tipo_Porcentual,
	0 
FROM gd_esquema.Maestra
order by Habitacion_Tipo_Codigo asc

-- CONSUMIBLE
INSERT INTO NPM.Consumible
SELECT DISTINCT Consumible_Codigo,Consumible_Descripcion,Consumible_Precio FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL
ORDER BY Consumible_Codigo ASC

-- TIPOS DE PAGO
INSERT INTO NPM.Tipo_Pago VALUES 
('EFECTIVO',0),
('TARJETA DE CREDITO',0);

print (CONCAT('INSERT CLIENTE PERSONA ', CONVERT(VARCHAR, GETDATE(), 114)))

-- CLIENTE - PERSONA - DIRECCION ---------------------------------------
-- #Clientes
CREATE TABLE #Clientes(
	Cliente_Pasaporte_Nro numeric(18,0), 
	Cliente_Apellido nvarchar(100),  
	Cliente_Nombre nvarchar(100), 
	Cliente_Fecha_Nac datetime, 
	Cliente_Mail nvarchar(200), 
	CLiente_Dom_Calle nvarchar(200), 
	Cliente_Nro_Calle numeric(18,0), 
	Cliente_Piso numeric(18,0), 
	Cliente_Depto nvarchar(10), 
	Cliente_Nacionalidad nvarchar(200)
)

INSERT INTO #Clientes
SELECT  
	m1.Cliente_Pasaporte_Nro, 
	m1.Cliente_Apellido,  
	m1.Cliente_Nombre, 
	m1.Cliente_Fecha_Nac, 
	m1.Cliente_Mail, 
	m1.CLiente_Dom_Calle, 
	m1.Cliente_Nro_Calle, 
	m1.Cliente_Piso, 
	m1.Cliente_Depto, 
	m1.Cliente_Nacionalidad
FROM gd_esquema.Maestra m1
GROUP BY
	m1.Cliente_Pasaporte_Nro, 
	m1.Cliente_Apellido,  
	m1.Cliente_Nombre, 
	m1.Cliente_Fecha_Nac, 
	m1.Cliente_Mail, 
	m1.CLiente_Dom_Calle, 
	m1.Cliente_Nro_Calle, 
	m1.Cliente_Piso, 
	m1.Cliente_Depto, 
	m1.Cliente_Nacionalidad

-- INSERT PERSONA
INSERT INTO NPM.Persona
SELECT  
	Cliente_Nombre,
	Cliente_Apellido,
	Cliente_Fecha_Nac,
	null,
	null,
	Cliente_Pasaporte_Nro,
	null,
	Cliente_Mail,
	(SELECT TOP 1 id_pais FROM NPM.Pais WHERE nacionalidad = Cliente_Nacionalidad),
	0
FROM #Clientes
GROUP BY
	Cliente_Nombre,
	Cliente_Apellido,
	Cliente_Fecha_Nac,
	Cliente_Pasaporte_Nro,
	Cliente_Mail,
	Cliente_Nacionalidad


UPDATE NPM.Persona 
SET inconsistente = 1
WHERE 
	numero_documento IN (
		SELECT numero_documento
		FROM NPM.Persona
		GROUP BY numero_documento
		HAVING COUNT(*) > 1
	)

UPDATE NPM.Persona 
SET inconsistente = 1
WHERE 
	mail IN (
		SELECT mail FROM NPM.Persona
		GROUP BY mail
		HAVING COUNT(*) > 1
	)

--INSERT DOMICILIOS
INSERT INTO NPM.Direccion
SELECT 
	Cliente_Dom_Calle,
	Cliente_Nro_Calle,
	Cliente_Piso,
	Cliente_Depto,
	null,
	null
FROM #Clientes

SELECT 
	P.id_persona, 
	D.id_direccion
INTO #Persona_Dir
FROM NPM.Persona as P
	INNER JOIN #Clientes as C
		ON P.nombre = Cliente_Nombre
		AND P.apellido = Cliente_Apellido
		AND P.fecha_nacimiento = Cliente_Fecha_Nac
		AND P.numero_documento = Cliente_Pasaporte_Nro
		AND P.mail = Cliente_Mail
	INNER JOIN NPM.Direccion as D 
		ON D.calle = C.Cliente_Dom_Calle 
		AND	D.nro_calle = C.Cliente_Nro_Calle 
		AND D.piso = C.Cliente_Piso
		AND	D.departamento = C.Cliente_Depto

UPDATE P 
SET P.id_direccion = D.id_direccion
FROM NPM.Persona as P
	INNER JOIN #Persona_Dir as D
		ON P.id_persona = D.id_persona


INSERT INTO NPM.Cliente
SELECT 
	P.id_persona,
	0, 
	0
FROM 
	NPM.Persona as P

DROP TABLE #Clientes
DROP TABLE #Persona_Dir

print (CONCAT('INSERT HOTEL DIRECCION ', CONVERT(VARCHAR, GETDATE(), 114)))
---- HOTEL - DIRECCION --------------------------------------
CREATE TABLE #hotel(
	id_hotel int identity,
	id_dir int,
	calle nvarchar(255),
	nro_calle numeric(18,0),
	ciudad nvarchar(255),
	estrella numeric(18,0),
)
INSERT INTO #hotel
SELECT 
	DISTINCT '',
	Hotel_Calle,
	Hotel_Nro_Calle,
	Hotel_Ciudad,
	Hotel_CantEstrella 
FROM gd_esquema.Maestra


insert into NPM.Direccion
select calle,nro_calle,NULL,NULL,ciudad,(select TOP 1 id_pais from NPM.Pais) from #hotel

UPDATE #hotel SET id_dir = d.id_direccion
from #hotel h
join NPM.Direccion d on d.calle = h.calle and
					 d.nro_calle = h.nro_calle and
					 d.ciudad = h.ciudad

INSERT INTO NPM.Hotel
SELECT 
	CONCAT('Hotel ', calle ,' ' , nro_calle),
	NULL,
	NULL,
	id_dir,
	estrella,
	CONVERT(DATETIME, '20180601', 112),
	0 
FROM #hotel

DROP TABLE #hotel

INSERT INTO NPM.Usuario_x_Hotel
SELECT id_hotel, 1
FROM NPM.Hotel

-- HABITACION
CREATE TABLE #Habitacion(
	hab_numero numeric(18,0),
	hab_id_hotel int,
	hab_piso numeric(18,0),
	hab_frente nvarchar(50),
	hab_tipo_habitacion numeric(18,0),
	hab_ciudad nvarchar(255),
	hab_calle nvarchar(255),
	hab_nro_calle numeric(18,0)
)
INSERT INTO #Habitacion
SELECT DISTINCT Habitacion_Numero,'',Habitacion_Piso,Habitacion_Frente,Habitacion_Tipo_Codigo,Hotel_Ciudad,Hotel_Calle,Hotel_Nro_Calle 
FROM gd_esquema.Maestra

UPDATE #Habitacion SET hab_id_hotel = h.id_hotel
FROM NPM.Hotel h
JOIN NPM.Direccion d ON h.id_direccion = d.id_direccion
JOIN #Habitacion hab ON  d.calle = hab.hab_calle AND
					     d.nro_calle = hab.hab_nro_calle AND
					     d.ciudad = hab.hab_ciudad

INSERT INTO NPM.Habitacion
SELECT hab_numero,hab_id_hotel,hab_piso,hab_frente,hab_tipo_habitacion,1 FROM #Habitacion

DROP TABLE #Habitacion

-- REGIMEN X HOTEL 
CREATE TABLE #RegXHotel(
	id_hotel int,
	id_regimen int,
	reg_descripcion nvarchar(255),
	reg_precio numeric(18,2),
	hot_calle nvarchar(255),
	hot_nro_calle numeric(18,0),
	hot_ciudad nvarchar(255),
)
INSERT INTO #RegXHotel
SELECT 
	DISTINCT 
	'',
	'',
	Regimen_Descripcion,
	Regimen_Precio,
	Hotel_Calle,
	Hotel_Nro_Calle,
	Hotel_Ciudad 
FROM
	gd_esquema.Maestra

UPDATE #RegXHotel 
SET id_hotel = h.id_hotel 
FROM NPM.Hotel h
INNER JOIN NPM.Direccion d 
	ON h.id_direccion = d.id_direccion
INNER JOIN #RegXHotel rh 
	ON  d.calle = rh.hot_calle 
	AND	d.nro_calle = rh.hot_nro_calle 
	AND	d.ciudad = rh.hot_ciudad

UPDATE #RegXHotel 
SET id_regimen = r.id_regimen 
FROM NPM.Regimen r
JOIN #RegXHotel rh ON r.descripcion_r = rh.reg_descripcion AND
					  r.precio = rh.reg_precio 

INSERT INTO NPM.Regimen_x_Hotel
SELECT id_hotel,id_regimen FROM #RegXHotel

DROP TABLE #RegXHotel

-- RESERVA - HABITACION x RESERVA 
print (CONCAT('INSERT RESERVA - HABITACION ', CONVERT(VARCHAR, GETDATE(), 114)))
CREATE TABLE #Reserva(
	r_Codigo numeric(18,0) PRIMARY KEY,
	r_id_usuario int,
	r_Calle nvarchar(255),
	r_Nro_Calle numeric(18,0),
	r_Ciudad nvarchar(255),
	r_Descripcion nvarchar(255),
	r_Mail nvarchar(255),
	r_Pasaporte_Nro numeric(18,0),
	r_fec_creacion datetime,
	r_fec_inicio datetime,
	r_fec_fin datetime,
	r_estado int,	
	r_id_hotel int,
	r_id_regimen int,
	r_id_cliente int,
)
INSERT INTO #Reserva
SELECT DISTINCT
	Reserva_Codigo,
	(SELECT TOP 1 id_usuario FROM NPM.Usuario),
	Hotel_Calle,
	Hotel_Nro_Calle,
	Hotel_Ciudad,
	Regimen_Descripcion,
	Cliente_Mail,
	Cliente_Pasaporte_Nro,
	'',
	Reserva_Fecha_Inicio,
	dateadd(day,Reserva_Cant_Noches,Reserva_Fecha_Inicio),
	1,
	'',
	'',
	''	
FROM gd_esquema.Maestra
ORDER BY Reserva_Codigo

UPDATE #Reserva 
SET r_id_hotel = h.id_hotel 
FROM NPM.Hotel h
JOIN NPM.Direccion d ON h.id_direccion = d.id_direccion
JOIN #Reserva r ON  d.calle = r.r_Calle AND
					d.nro_calle = r.r_Nro_Calle AND
					d.ciudad = r.r_Ciudad


UPDATE #Reserva SET r_id_regimen = rg.id_regimen
FROM NPM.Regimen rg
JOIN #Reserva rs ON rg.descripcion_r = rs.r_Descripcion

SELECT 
	R.r_Codigo,
	MIN(P.id_persona) as 'id_persona'
INTO #Reserva_Per
FROM 
	#RESERVA as R 
	INNER JOIN NPM.Persona as P
		ON P.mail = R.r_Mail
		AND P.numero_documento = R.r_Pasaporte_Nro
GROUP BY
	R.r_Codigo

UPDATE R
SET r_id_cliente = C.id_cliente
FROM 
	#RESERVA as R 
	INNER JOIN #Reserva_Per as P
		ON R.r_Codigo = P.r_Codigo
	INNER JOIN NPM.Cliente as C
		ON P.id_persona = c.id_persona
		
INSERT INTO NPM.Reserva
SELECT 
	r_Codigo,
	r_id_usuario,
	r_id_hotel,
	r_id_regimen,
	r_id_cliente,
	r_fec_creacion,
	r_fec_inicio,
	r_fec_fin,
	r_estado 
FROM #Reserva

DROP TABLE #Reserva
DROP TABLE #Reserva_Per

print (CONCAT('INSERT ESTADIA ', CONVERT(VARCHAR, GETDATE(), 114)))
-- ESTADIA - ESTADIA X CLIENTE
--Estadia
SELECT DISTINCT
	Reserva_Codigo id_reserva,
	1 id_usuario_ingreso,
	Estadia_Fecha_Inicio fecha_ingreso,
	1 id_usuario_salida,
	DATEADD(dd,Estadia_Cant_Noches,Estadia_Fecha_Inicio) fecha_salida
INTO #Estadia
FROM gd_esquema.Maestra WHERE Estadia_Cant_Noches IS NOT NULL AND Estadia_Fecha_Inicio IS NOT NULL AND Item_Factura_Cantidad IS NULL AND Consumible_Codigo IS NULL AND Factura_Nro IS NULL

INSERT INTO NPM.Estadia 
SELECT * FROM #Estadia

--Huesped_x_Estadia
INSERT INTO NPM.Huesped_x_Estadia
SELECT DISTINCT 
	id_cliente,
	id_estadia
FROM gd_esquema.Maestra INNER JOIN NPM.Persona p ON p.mail = Cliente_Mail AND p.numero_documento = Cliente_Pasaporte_Nro INNER JOIN NPM.Cliente c ON c.id_persona = p.id_persona 
	 INNER JOIN NPM.Estadia ON id_reserva = Reserva_Codigo
WHERE Estadia_Cant_Noches IS NOT NULL AND Estadia_Fecha_Inicio IS NOT NULL AND Item_Factura_Cantidad IS NULL AND Consumible_Codigo IS NULL AND Factura_Nro IS NULL

DROP TABLE #Estadia
-- CONSUMOS (ESTADIA X HOTEL X CONSUMIBLE) - ITEM FACTURA - FACTURA

--CREATE TABLE #Consumible_Reserva(
--		cr_id_estadia int,
--		cr_consumible numeric(18,0),
--		cr_id_habitacion int,
--		cr_numero_habitacion numeric(18,0),
--		cr_reserva numeric(18,0),
--		cr_item_monto numeric(18,2),
--		cr_item_cantidad numeric(18,0),
--		cr_factura numeric(18,0)
--	)
--INSERT INTO #Consumible_Reserva
--SELECT DISTINCT '',Consumible_Codigo,'',Habitacion_Numero,Reserva_Codigo,
--Item_Factura_Monto,Item_Factura_Cantidad,Factura_Nro 
--FROM gd_esquema.Maestra
--WHERE Consumible_Codigo IS NOT NULL

--UPDATE #Consumible_Reserva SET cr_id_estadia = e.id_estadia
--FROM #Consumible_Reserva cr
--JOIN NPM.Estadia e ON e.id_reserva = cr.cr_reserva 


--UPDATE #Consumible_Reserva SET cr_id_habitacion = h.id_habitacion
--FROM NPM.Habitacion h
--JOIN NPM.Hotel hot ON hot.id_hotel = h.id_hotel
--JOIN #Consumible_Reserva cr ON h.numero = cr.cr_numero_habitacion

--INSERT INTO NPM.Consumo
--SELECT cr_id_estadia,cr_consumible,cr_id_habitacion,cr_reserva,cr_item_monto FROM #Consumible_Reserva


--INSERT INTO NPM.Item_Factura
--SELECT DISTINCT c.id_consumo,'',cr_item_cantidad,'',cr.cr_factura
--FROM #Consumible_Reserva cr 
--JOIN NPM.Consumo c ON c.id_consumible = cr_consumible 

--DROP TABLE #Consumible_Reserva

COMMIT 

END TRY
BEGIN CATCH
	SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage;  
	ROLLBACK
END CATCH
GO

print (CONCAT('Relaciones ', CONVERT(VARCHAR, GETDATE(), 114)))
---------------RELACIONES ------------------

-- CIERRE TEMPORAL
ALTER TABLE [NPM].[Cierre_Temporal]  WITH CHECK ADD  CONSTRAINT [FK_Cierre_Temporal_Hotel] FOREIGN KEY([id_hotel])
REFERENCES [NPM].[Hotel] ([id_hotel])
GO

ALTER TABLE [NPM].[Cierre_Temporal] CHECK CONSTRAINT [FK_Cierre_Temporal_Hotel]
GO

-- CLIENTE 
ALTER TABLE [NPM].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona] FOREIGN KEY([id_persona])
REFERENCES [NPM].[Persona] ([id_persona])
GO

ALTER TABLE [NPM].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona]
GO

-- CONSUMO
ALTER TABLE [NPM].[Consumo]  WITH CHECK ADD  CONSTRAINT [FK_Consumo_Consumible] FOREIGN KEY([id_consumible])
REFERENCES [NPM].[Consumible] ([id_consumible])
GO

ALTER TABLE [NPM].[Consumo] CHECK CONSTRAINT [FK_Consumo_Consumible]
GO

ALTER TABLE [NPM].[Consumo]  WITH CHECK ADD  CONSTRAINT [FK_Consumo_Estadia] FOREIGN KEY([id_estadia])
REFERENCES [NPM].[Estadia] ([id_estadia])
GO

ALTER TABLE [NPM].[Consumo] CHECK CONSTRAINT [FK_Consumo_Estadia]
GO

ALTER TABLE [NPM].[Consumo]  WITH CHECK ADD  CONSTRAINT [FK_Consumo_Habitacion_Reservada] FOREIGN KEY([id_reserva], [id_habitacion])
REFERENCES [NPM].[Habitacion_Reservada] ([id_reserva], [id_habitacion])
GO

ALTER TABLE [NPM].[Consumo] CHECK CONSTRAINT [FK_Consumo_Habitacion_Reservada]
GO

-- DIRECCION
ALTER TABLE [NPM].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Pais] FOREIGN KEY([id_pais])
REFERENCES [NPM].[Pais] ([id_pais])
GO

ALTER TABLE [NPM].[Direccion] CHECK CONSTRAINT [FK_Direccion_Pais]
GO

-- ESTADIA
ALTER TABLE [NPM].[Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Estadia_Reserva] FOREIGN KEY([id_reserva])
REFERENCES [NPM].[Reserva] ([id_reserva])
GO

ALTER TABLE [NPM].[Estadia] CHECK CONSTRAINT [FK_Estadia_Reserva]
GO

ALTER TABLE [NPM].[Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Estadia_Usuario] FOREIGN KEY([id_usuario_salida])
REFERENCES [NPM].[Usuario] ([id_usuario])
GO

ALTER TABLE [NPM].[Estadia] CHECK CONSTRAINT [FK_Estadia_Usuario]
GO

ALTER TABLE [NPM].[Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Estadia_Usuario1] FOREIGN KEY([id_usuario_ingreso])
REFERENCES [NPM].[Usuario] ([id_usuario])
GO

ALTER TABLE [NPM].[Estadia] CHECK CONSTRAINT [FK_Estadia_Usuario1]
GO

-- FACTURA
ALTER TABLE [NPM].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [NPM].[Cliente] ([id_cliente])
GO

ALTER TABLE [NPM].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO

ALTER TABLE [NPM].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Tipo_Pago] FOREIGN KEY([id_tipo_pago])
REFERENCES [NPM].[Tipo_Pago] ([id_tipo_pago])
GO

ALTER TABLE [NPM].[Factura] CHECK CONSTRAINT [FK_Factura_Tipo_Pago]
GO

ALTER TABLE [NPM].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Estadia] FOREIGN KEY([id_estadia])
REFERENCES [NPM].[Estadia] ([id_estadia])
GO

ALTER TABLE [NPM].[Factura] CHECK CONSTRAINT [FK_Factura_Estadia]
GO


-- FUNCIONES X ROL
ALTER TABLE [NPM].[Funciones_x_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_x_Rol_Funcion] FOREIGN KEY([id_funcion])
REFERENCES [NPM].[Funcion] ([id_funcion])
GO

ALTER TABLE [NPM].[Funciones_x_Rol] CHECK CONSTRAINT [FK_Funciones_x_Rol_Funcion]
GO

ALTER TABLE [NPM].[Funciones_x_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_x_Rol_Rol] FOREIGN KEY([id_rol])
REFERENCES [NPM].[Rol] ([id_rol])
GO

ALTER TABLE [NPM].[Funciones_x_Rol] CHECK CONSTRAINT [FK_Funciones_x_Rol_Rol]
GO

-- HABITACION
ALTER TABLE [NPM].[Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Tipo_Habitacion] FOREIGN KEY([id_tipo_habitacion])
REFERENCES [NPM].[Tipo_Habitacion] ([id_tipo_habitacion])
GO

ALTER TABLE [NPM].[Habitacion] CHECK CONSTRAINT [FK_Habitacion_Tipo_Habitacion]
GO

ALTER TABLE [NPM].[Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Hotel] FOREIGN KEY([id_hotel])
REFERENCES [NPM].[Hotel] ([id_hotel])
GO

ALTER TABLE [NPM].[Habitacion] CHECK CONSTRAINT [FK_Habitacion_Hotel]
GO

-- HABITACION RESERVADA
ALTER TABLE [NPM].[Habitacion_Reservada]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Reservada_Habitacion] FOREIGN KEY([id_habitacion])
REFERENCES [NPM].[Habitacion] ([id_habitacion])
GO

ALTER TABLE [NPM].[Habitacion_Reservada] CHECK CONSTRAINT [FK_Habitacion_Reservada_Habitacion]
GO

ALTER TABLE [NPM].[Habitacion_Reservada]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Reservada_Reserva] FOREIGN KEY([id_reserva])
REFERENCES [NPM].[Reserva] ([id_reserva])
GO

ALTER TABLE [NPM].[Habitacion_Reservada] CHECK CONSTRAINT [FK_Habitacion_Reservada_Reserva]
GO

-- HOTEL
ALTER TABLE [NPM].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_Direccion] FOREIGN KEY([id_direccion])
REFERENCES [NPM].[Direccion] ([id_direccion])
GO

ALTER TABLE [NPM].[Hotel] CHECK CONSTRAINT [FK_Hotel_Direccion]
GO

-- HUESPED X ESTADIA
ALTER TABLE [NPM].[Huesped_x_Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Huesped_x_Estadia_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [NPM].[Cliente] ([id_cliente])
GO

ALTER TABLE [NPM].[Huesped_x_Estadia] CHECK CONSTRAINT [FK_Huesped_x_Estadia_Cliente]
GO

ALTER TABLE [NPM].[Huesped_x_Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Huesped_x_Estadia_Estadia] FOREIGN KEY([id_estadia])
REFERENCES [NPM].[Estadia] ([id_estadia])
GO

ALTER TABLE [NPM].[Huesped_x_Estadia] CHECK CONSTRAINT [FK_Huesped_x_Estadia_Estadia]
GO

-- ITEM FACTURA
ALTER TABLE [NPM].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Consumo] FOREIGN KEY([id_consumo])
REFERENCES [NPM].[Consumo] ([id_consumo])
GO

ALTER TABLE [NPM].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Consumo]
GO

ALTER TABLE [NPM].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura] FOREIGN KEY([id_factura])
REFERENCES [NPM].[Factura] ([id_factura])
GO

ALTER TABLE [NPM].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura]
GO

-- PERSONA
ALTER TABLE [NPM].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Direccion] FOREIGN KEY([id_direccion])
REFERENCES [NPM].[Direccion] ([id_direccion])
GO

ALTER TABLE [NPM].[Persona] CHECK CONSTRAINT [FK_Persona_Direccion]
GO

ALTER TABLE [NPM].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Pais] FOREIGN KEY([id_nacionalidad])
REFERENCES [NPM].[Pais] ([id_pais])
GO

ALTER TABLE [NPM].[Persona] CHECK CONSTRAINT [FK_Persona_Pais]
GO

ALTER TABLE [NPM].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Tipo_Documento] FOREIGN KEY([id_tipo_documento])
REFERENCES [NPM].[Tipo_Documento] ([id_tipo_documento])
GO

ALTER TABLE [NPM].[Persona] CHECK CONSTRAINT [FK_Persona_Tipo_Documento]
GO

-- REGIMEN X HOTEL
ALTER TABLE [NPM].[Regimen_x_Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Regimen_x_Hotel_Hotel] FOREIGN KEY([id_hotel])
REFERENCES [NPM].[Hotel] ([id_hotel])
GO

ALTER TABLE [NPM].[Regimen_x_Hotel] CHECK CONSTRAINT [FK_Regimen_x_Hotel_Hotel]
GO

ALTER TABLE [NPM].[Regimen_x_Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Regimen_x_Hotel_Regimen] FOREIGN KEY([id_regimen])
REFERENCES [NPM].[Regimen] ([id_regimen])
GO

ALTER TABLE [NPM].[Regimen_x_Hotel] CHECK CONSTRAINT [FK_Regimen_x_Hotel_Regimen]
GO

-- RESERVA
ALTER TABLE [NPM].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [NPM].[Cliente] ([id_cliente])
GO

ALTER TABLE [NPM].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cliente]
GO

ALTER TABLE [NPM].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Estado_Reserva] FOREIGN KEY([id_estado])
REFERENCES [NPM].[Estado_Reserva] ([id_estado])
GO

ALTER TABLE [NPM].[Reserva] CHECK CONSTRAINT [FK_Reserva_Estado_Reserva]
GO

ALTER TABLE [NPM].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Regimen_x_Hotel] FOREIGN KEY([id_hotel], [id_regimen])
REFERENCES [NPM].[Regimen_x_Hotel] ([id_hotel], [id_regimen])
GO

ALTER TABLE [NPM].[Reserva] CHECK CONSTRAINT [FK_Reserva_Regimen_x_Hotel]
GO

ALTER TABLE [NPM].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([id_usuario_creacion])
REFERENCES [NPM].[Usuario] ([id_usuario])
GO

ALTER TABLE [NPM].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO


-- RESERVA CANCELADA
ALTER TABLE [NPM].[Reserva_Cancelada]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cancelada_Reserva] FOREIGN KEY([id_reserva])
REFERENCES [NPM].[Reserva] ([id_reserva])
GO

ALTER TABLE [NPM].[Reserva_Cancelada] CHECK CONSTRAINT [FK_Reserva_Cancelada_Reserva]
GO

ALTER TABLE [NPM].[Reserva_Cancelada]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cancelada_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [NPM].[Usuario] ([id_usuario])
GO

ALTER TABLE [NPM].[Reserva_Cancelada] CHECK CONSTRAINT [FK_Reserva_Cancelada_Usuario]
GO

-- RESERVA MODIFICADA
ALTER TABLE [NPM].[Reserva_Modificada]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Modificada_Reserva] FOREIGN KEY([id_reserva])
REFERENCES [NPM].[Reserva] ([id_reserva])
GO

ALTER TABLE [NPM].[Reserva_Modificada] CHECK CONSTRAINT [FK_Reserva_Modificada_Reserva]
GO

-- ROLES X USUARIO
ALTER TABLE [NPM].[Roles_x_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Roles_x_Usuario_Rol] FOREIGN KEY([id_rol])
REFERENCES [NPM].[Rol] ([id_rol])
GO

ALTER TABLE [NPM].[Roles_x_Usuario] CHECK CONSTRAINT [FK_Roles_x_Usuario_Rol]
GO

ALTER TABLE [NPM].[Roles_x_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Roles_x_Usuario_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [NPM].[Usuario] ([id_usuario])
GO

ALTER TABLE [NPM].[Roles_x_Usuario] CHECK CONSTRAINT [FK_Roles_x_Usuario_Usuario]
GO

-- USUARIO 
ALTER TABLE [NPM].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([id_persona])
REFERENCES [NPM].[Persona] ([id_persona])
GO

ALTER TABLE [NPM].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO

-- USUARIO X HOTEL
ALTER TABLE [NPM].[Usuario_x_Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_x_Hotel_Hotel] FOREIGN KEY([id_hotel])
REFERENCES [NPM].[Hotel] ([id_hotel])
GO

ALTER TABLE [NPM].[Usuario_x_Hotel] CHECK CONSTRAINT [FK_Usuario_x_Hotel_Hotel]
GO

ALTER TABLE [NPM].[Usuario_x_Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_x_Hotel_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [NPM].[Usuario] ([id_usuario])
GO

ALTER TABLE [NPM].[Usuario_x_Hotel] CHECK CONSTRAINT [FK_Usuario_x_Hotel_Usuario]
GO

print (CONCAT('Fin del Script Inicial', CONVERT(VARCHAR, GETDATE(), 114)))