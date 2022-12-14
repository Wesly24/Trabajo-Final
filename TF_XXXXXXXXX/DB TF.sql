USE [master]
GO
/****** Object:  Database [Usuarios]    Script Date: 26/06/2022 10:54:55 ******/
CREATE DATABASE [Usuarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Usuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.RIXI\MSSQL\DATA\Usuarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Usuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.RIXI\MSSQL\DATA\Usuarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Usuarios] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Usuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Usuarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Usuarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Usuarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Usuarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Usuarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [Usuarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Usuarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Usuarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Usuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Usuarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Usuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Usuarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Usuarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Usuarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Usuarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Usuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Usuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Usuarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Usuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Usuarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Usuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Usuarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Usuarios] SET RECOVERY FULL 
GO
ALTER DATABASE [Usuarios] SET  MULTI_USER 
GO
ALTER DATABASE [Usuarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Usuarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Usuarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Usuarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Usuarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Usuarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Usuarios', N'ON'
GO
ALTER DATABASE [Usuarios] SET QUERY_STORE = OFF
GO
USE [Usuarios]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombresapellidos] [varchar](150) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[Telefono] [varchar](9) NOT NULL,
	[Correo] [varchar](200) NULL,
	[Distrito] [varchar](50) NOT NULL,
	[Situacionlaboral] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[L1] [varchar](200) NULL,
	[L2] [varchar](200) NULL,
	[L3] [varchar](200) NULL,
	[L4] [varchar](200) NULL,
	[C1] [varchar](50) NULL,
	[C2] [varchar](50) NULL,
	[C3] [varchar](50) NULL,
	[C4] [varchar](50) NULL,
	[Foto] [image] NULL,
	[Valoracion] [int] NULL,
	[P1] [int] NULL,
	[P2] [int] NULL,
	[P3] [int] NULL,
	[Link] [varchar](200) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_busqcar]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_busqcar](@valor varchar(50))
as begin select * from Empleados where Descripcion LIKE '%'+@valor+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_busqtest]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_busqtest](@valor varchar(50))
as begin select * from Empleados where DNI LIKE '%'+@valor+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_distrit]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_distrit](@Distrito varchar(50))
as begin select * from Empleados where Distrito=@Distrito
end
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_eliminar] (@Codigo int)
as begin delete from Empleados where Codigo=@Codigo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_insertar](
@Nombresapellidos varchar(150), 
@DNI varchar(8),
@Telefono varchar(9),
@Correo varchar(200),
@Distrito varchar(50),
@Situacionlaboral varchar(50),
@Descripcion varchar(200),
@L1 varchar(200),
@L2 varchar(200),
@L3 varchar(200),
@L4 varchar(200),
@C1 varchar(50),
@C2 varchar(50),
@C3 varchar(50),
@C4 varchar(50),
@Foto image,
@Valoracion int,
@P1 int,
@P2 int,
@P3 int,
@Link varchar(200)
)
as
begin
insert into 
Empleados(Nombresapellidos,
DNI,
Telefono,
Correo,
Distrito,
Situacionlaboral,
Descripcion,
L1,
L2,
L3,
L4,
C1,
C2,
C3,
C4,
Foto,
Valoracion,
P1,
P2,
P3,
Link)
values(@Nombresapellidos ,
@DNI ,
@Telefono,
@Correo,
@Distrito,
@Situacionlaboral ,
@Descripcion,
@L1,
@L2 ,
@L3,
@L4,
@C1,
@C2,
@C3,
@C4 ,
@Foto,
@Valoracion,
@P1,
@P2,
@P3,
@Link)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listar] as begin
select Codigo,Nombresapellidos,
DNI,
Telefono,
Correo,
Distrito,
Situacionlaboral,
Descripcion,
L1,
L2,
L3,
L4,
C1,
C2,
C3,
C4,
Foto,
Valoracion,
P1,
P2,
P3,
Link
from Empleados
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listarpunt]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_listarpunt] as begin
select Codigo,Nombresapellidos,
DNI,
Telefono,
Correo,
Distrito,
Situacionlaboral,
Descripcion,
L1,
L2,
L3,
L4,
C1,
C2,
C3,
C4,
Foto,
Valoracion,
P1,
P2,
P3,
Link
from Empleados order by Valoracion desc
end
GO
/****** Object:  StoredProcedure [dbo].[sp_modificar]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_modificar] (
@Nombresapellidos varchar(150), 
@DNI varchar(8),
@Telefono varchar(9),
@Correo varchar(200),
@Distrito varchar(50),
@Situacionlaboral varchar(50),@Codigo int)
as begin update Empleados set 
Nombresapellidos=@Nombresapellidos , 
DNI=@DNI ,
Telefono=@Telefono ,
Correo=@Correo ,
Distrito=@Distrito ,
Situacionlaboral=@Situacionlaboral where Codigo=@Codigo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_puntuar]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_puntuar](@Codigo int,@Valoracion int) as begin
UPDATE Empleados SET Valoracion=@Valoracion WHERE Codigo=@Codigo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_verft]    Script Date: 26/06/2022 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_verft](@Codigo int) as begin
select Foto from Empleados where Codigo=@Codigo
end
GO
USE [master]
GO
ALTER DATABASE [Usuarios] SET  READ_WRITE 
GO
