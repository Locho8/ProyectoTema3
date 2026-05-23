# Proyecto Tema 3 - MVC C# con SQL Server

## Descripción
Proyecto Web MVC en C# con autenticación de usuarios, gestión de artículos (CRUD) y base de datos SQL Server.

## Características
✅ Autenticación de Login
✅ Registro de productos/artículos
✅ Listado de artículos
✅ Editar artículos
✅ Eliminar artículos
✅ Diseño responsivo (Azul y Blanco)

## Requisitos
- Visual Studio 2019+
- .NET Framework 4.7.2+
- SQL Server 2019+

## Instalación

### 1. Crear la Base de Datos
1. Abre SQL Server Management Studio
2. Ejecuta el script `Base_Datos.sql` ubicado en la carpeta `Database/`
3. Esto creará la BD "ProyectoTema3" con las tablas necesarias

### 2. Configurar la conexión
1. Abre `Web.config`
2. Modifica la cadena de conexión con tu servidor:
```xml
<add name="ProyectoTema3Conexion" connectionString="Server=TU_SERVIDOR;Database=ProyectoTema3;User Id=sa;Password=TU_PASSWORD;" providerName="System.Data.SqlClient" />
```

### 3. Ejecutar el proyecto
1. Abre la solución en Visual Studio
2. Presiona F5 o Ctrl+F5
3. El sitio se abrirá en http://localhost

## Credenciales de prueba
- **Usuario:** admin
- **Contraseña:** 123456

## Estructura del Proyecto
```
ProyectoTema3/
├── Models/
│   ├── Usuario.cs
│   ├── Articulo.cs
│   └── LoginViewModel.cs
├── Controllers/
│   ├── HomeController.cs
│   ├── LoginController.cs
│   └── ArticulosController.cs
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _LoginLayout.cshtml
│   ├── Login/
│   │   └── Index.cshtml
│   ├── Articulos/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   └── Home/
│       └── Index.cshtml
├── Content/
│   ├── styles.css
│   └── images/
├── Database/
│   └── Base_Datos.sql
└── Web.config
```

## Autor
Locho8
