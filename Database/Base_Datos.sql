-- ============================================
-- PROYECTO TEMA 3 - BASE DE DATOS SQL SERVER
-- ============================================

-- Crear Base de Datos
CREATE DATABASE ProyectoTema3;
GO

USE ProyectoTema3;
GO

-- ============================================
-- TABLA DE USUARIOS
-- ============================================
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contraseña VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    NombreCompleto VARCHAR(100) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);
GO

-- ============================================
-- TABLA DE ARTICULOS
-- ============================================
CREATE TABLE Articulos (
    IdArticulo INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(500),
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Categoria VARCHAR(50),
    Imagen VARCHAR(255),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaActualizacion DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);
GO

-- ============================================
-- INSERTAR DATOS DE PRUEBA
-- ============================================

-- Usuario de prueba (Contraseña: 123456)
INSERT INTO Usuarios (NombreUsuario, Contraseña, Email, NombreCompleto)
VALUES ('admin', '123456', 'admin@ejemplo.com', 'Administrador');
GO

-- Artículos de ejemplo
INSERT INTO Articulos (Nombre, Descripcion, Precio, Stock, Categoria)
VALUES 
('Laptop Dell', 'Laptop de última generación', 1200.00, 5, 'Electrónica'),
('Mouse Inalámbrico', 'Mouse con conexión USB inalámbrica', 25.50, 15, 'Accesorios'),
('Teclado Mecánico', 'Teclado para gaming RGB', 89.99, 8, 'Accesorios'),
('Monitor 24"', 'Monitor Full HD para oficina', 199.99, 3, 'Electrónica'),
('Cable USB-C', 'Cable de carga rápida', 12.99, 20, 'Cables');
GO

-- ============================================
-- VISTAS (OPCIONAL)
-- ============================================

-- Vista para listar artículos activos
CREATE VIEW vw_ArticulosActivos AS
SELECT IdArticulo, Nombre, Descripcion, Precio, Stock, Categoria, FechaCreacion
FROM Articulos
WHERE Activo = 1
ORDER BY FechaCreacion DESC;
GO
