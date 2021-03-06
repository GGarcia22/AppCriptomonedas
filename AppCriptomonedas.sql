USE [AppCryptoBD]
GO
/****** Object:  Table [dbo].[CuentaBtc]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaBtc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[saldo] [decimal](18, 0) NULL,
	[UUID] [nvarchar](50) NULL,
	[idUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaDolares]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaDolares](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nCuenta] [nvarchar](50) NULL,
	[saldo] [decimal](18, 0) NULL,
	[idUsuario] [int] NULL,
	[CBU] [nvarchar](50) NULL,
	[alias] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuentaPesos]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaPesos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nCuenta] [nvarchar](50) NULL,
	[saldo] [decimal](18, 0) NULL,
	[idUsuario] [int] NULL,
	[CBU] [nvarchar](50) NULL,
	[alias] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NULL,
	[cuentaOrigen] [nvarchar](50) NULL,
	[cuentaDestino] [nvarchar](50) NULL,
	[tipoDeMovimiento] [nvarchar](50) NULL,
	[monto] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NULL,
	[contraseña] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CuentaBtc]  WITH CHECK ADD  CONSTRAINT [FK_CuentaCripto_ToTable] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[CuentaBtc] CHECK CONSTRAINT [FK_CuentaCripto_ToTable]
GO
ALTER TABLE [dbo].[CuentaDolares]  WITH CHECK ADD  CONSTRAINT [FK_CuentaDolares_ToTable] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[CuentaDolares] CHECK CONSTRAINT [FK_CuentaDolares_ToTable]
GO
ALTER TABLE [dbo].[CuentaPesos]  WITH CHECK ADD  CONSTRAINT [FK_CuentaPesos_ToTable] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[CuentaPesos] CHECK CONSTRAINT [FK_CuentaPesos_ToTable]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Table_ToTable] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Table_ToTable]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarMontoCuenta]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ActualizarMontoCuenta](
@IdCuenta int,
@tipoCuenta nvarchar(50),
@saldo decimal(18,0)
)
as
begin
    declare @pesos nvarchar(50) = 'pesos';
	declare @dolares nvarchar(50) = 'dolares';
	declare @btc nvarchar(50) = 'btc';
    if (@tipoCuenta = @pesos)
	update CuentaPesos set saldo = @saldo where Id = @IdCuenta; 
	else if (@tipoCuenta = @dolares)
	update CuentaDolares set saldo = @saldo where Id = @IdCuenta; 
	else if (@tipoCuenta = @btc)
	update CuentaBtc set saldo = @saldo where Id = @IdCuenta; 
end
GO
/****** Object:  StoredProcedure [dbo].[ListarMovimientos]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListarMovimientos](
@IdUsuario int)
as
begin
    select*from Movimiento where idUsuario =@IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCuentaBtc]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerCuentaBtc](
@numCuenta nvarchar(50)
)
as
begin
    select*from CuentaBtc where UUID =@numCuenta
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCuentaCriptosDe]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ObtenerCuentaCriptosDe](
@IdUsuario int)
as
begin
    select*from CuentaCripto where idUsuario =@IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCuentaDolares]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerCuentaDolares](
@numCuenta nvarchar(50)
)
as
begin
    select*from CuentaDolares where CBU =@numCuenta
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCuentaDolaresDe]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerCuentaDolaresDe](
@IdUsuario int)
as
begin
    select*from CuentaDolares where idUsuario =@IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCuentaPesos]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerCuentaPesos](
@numCuenta nvarchar(50)
)
as
begin
    select*from CuentaPesos where CBU =@numCuenta
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCuentaPesosDe]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerCuentaPesosDe](
@IdUsuario int)
as
begin
    select*from CuentaPesos where idUsuario =@IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ObtenerUsuario](
@IdUsuario int)
as
begin
    select*from Usuario where Id =@IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[RestarMontoCuenta]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RestarMontoCuenta](
@numCuenta nvarchar(50),
@tipoCuenta nvarchar(50),
@monto decimal(18,0)
)
as
begin
    declare @pesos nvarchar(50) = 'PESO';
	declare @dolares nvarchar(50) = 'DOLAR';
	declare @btc nvarchar(50) = 'BITCOIN';
	declare @saldoPesos decimal(18,0) = (select saldo from CuentaPesos where CBU = @numCuenta or alias = @numCuenta)
	declare @saldoDolares decimal(18,0) = (select saldo from CuentaDolares where CBU = @numCuenta or alias = @numCuenta)
	declare @saldoBtc decimal(18,0) = (select saldo from CuentaBtc where UUID = @numCuenta)
    if (@tipoCuenta = @pesos) and (@saldoPesos >= @monto)
	update CuentaPesos set saldo =- @monto where CBU = @numCuenta or alias = @numCuenta; 
	else if (@tipoCuenta = @dolares) and (@saldoDolares >= @monto)
	update CuentaDolares set saldo =- @monto where CBU = @numCuenta or alias = @numCuenta; 
	else if (@tipoCuenta = @btc) and (@saldoBtc >= @monto)
	update CuentaBtc set saldo =- @monto where UUID = @numCuenta; 
end
GO
/****** Object:  StoredProcedure [dbo].[SumarMontoCuenta]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SumarMontoCuenta](
@numCuenta nvarchar(50),
@tipoCuenta nvarchar(50),
@monto decimal(18,0)
)
as
begin
    declare @pesos nvarchar(50) = 'PESO';
	declare @dolares nvarchar(50) = 'DOLAR';
	declare @btc nvarchar(50) = 'BITCOIN';
    if (@tipoCuenta = @pesos)
	update CuentaPesos set saldo =+ @monto where CBU = @numCuenta or alias = @numCuenta; 
	else if (@tipoCuenta = @dolares)
	update CuentaDolares set saldo =+ @monto where CBU = @numCuenta or alias = @numCuenta; 
	else if (@tipoCuenta = @btc)
	update CuentaBtc set saldo =+ @monto where UUID = @numCuenta; 
end
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 9/6/2022 18:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ValidarUsuario](
@User nvarchar(50),
@Pass nvarchar(50)
)
as
begin
    select*from Usuario where usuario=@User and contraseña=@Pass
end
GO
