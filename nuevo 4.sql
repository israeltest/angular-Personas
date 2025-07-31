Create database InventarioDB
use InventarioDB

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500),
    Categoria NVARCHAR(50),
    Imagen NVARCHAR(MAX),
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);

CREATE TABLE Transacciones (
    Id INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    TipoTransaccion NVARCHAR(10) NOT NULL CHECK (TipoTransaccion IN ('Compra', 'Venta')),
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    PrecioTotal DECIMAL(18,2) NOT NULL,
    Detalle NVARCHAR(500),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);
select * from Transacciones
select * from Productos


use InventarioDB
-- Registrar transacción
CREATE PROCEDURE sp_RegistrarTransaccion
    @TipoTransaccion NVARCHAR(10),
    @ProductoId INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(18,2),
    @Detalle NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StockActual INT;
    DECLARE @PrecioTotal DECIMAL(18,2);

    -- Obtener stock actual
    SELECT @StockActual = Stock FROM Productos WHERE Id = @ProductoId;

    -- Validar stock para ventas
    IF @TipoTransaccion = 'Venta' AND @StockActual < @Cantidad
    BEGIN
        RAISERROR ('Stock insuficiente para realizar la venta.', 16, 1);
        RETURN;
    END

    -- Calcular precio total
    SET @PrecioTotal = @Cantidad * @PrecioUnitario;

    -- Insertar transacción con PrecioTotal
    INSERT INTO Transacciones (
        TipoTransaccion, ProductoId, Cantidad, PrecioUnitario, PrecioTotal, Detalle
    )
    VALUES (
        @TipoTransaccion, @ProductoId, @Cantidad, @PrecioUnitario, @PrecioTotal, @Detalle
    );

    -- Ajustar stock
    IF @TipoTransaccion = 'Venta'
        UPDATE Productos SET Stock = Stock - @Cantidad WHERE Id = @ProductoId;
    ELSE
        UPDATE Productos SET Stock = Stock + @Cantidad WHERE Id = @ProductoId;
END
GO
-- Historial filtrado
CREATE PROCEDURE sp_ObtenerTransaccionesFiltrado
    @ProductoId INT = NULL,
    @TipoTransaccion NVARCHAR(10) = NULL,
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL
AS
BEGIN
    SELECT T.*, P.Nombre, P.Stock
    FROM Transacciones T
    INNER JOIN Productos P ON T.ProductoId = P.Id
    WHERE (@ProductoId IS NULL OR T.ProductoId = @ProductoId)
      AND (@TipoTransaccion IS NULL OR T.TipoTransaccion = @TipoTransaccion)
      AND (@FechaInicio IS NULL OR T.Fecha >= @FechaInicio)
      AND (@FechaFin IS NULL OR T.Fecha <= @FechaFin);
	  select * from Transacciones
END
GO

create procedure prueba
	@stock INT,
	@estado nvarchar(100)
as 
	Begin
	 select * from Transacciones2
end
go
create table Transacciones (
	Id INT PRIMARY kEY IDENTITY,
	@stock int
	@Destalle nvarchar(100));





use InventarioDB
CREATE PROCEDURE sp_CrearProducto
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(500),
    @Categoria NVARCHAR(50),
    @Imagen NVARCHAR(MAX),
    @Precio DECIMAL(18,2),
    @Stock INT
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Categoria, Imagen, Precio, Stock)
    VALUES (@Nombre, @Descripcion, @Categoria, @Imagen, @Precio, @Stock);
END
GO

CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SELECT * FROM Productos;
END
GO

CREATE PROCEDURE sp_ObtenerProductoPorId
    @Id INT
AS
BEGIN
    SELECT * FROM Productos WHERE Id = @Id;
END
GO

-- Actualizar producto
CREATE PROCEDURE sp_ActualizarProducto
    @Id INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(500),
    @Categoria NVARCHAR(50),
    @Imagen NVARCHAR(MAX),
    @Precio DECIMAL(18,2),
    @Stock INT
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Categoria = @Categoria,
        Imagen = @Imagen,
        Precio = @Precio,
        Stock = @Stock
    WHERE Id = @Id;
END
GO

-- Eliminar producto
CREATE PROCEDURE sp_EliminarProducto
    @Id INT
AS
BEGIN
    DELETE FROM Productos WHERE Id = @Id;
END
GO



--
{
  "nombre": "Tarjeta Sim",
  "descripcion": "Prueba guardado producto",
  "categoria": "Tarjeta",
  "precio": 5.00,
  "stock": 3
}


{
  "tipoTransaccion": "Venta",
  "productoId": 2,
  "cantidad": 2,
  "precioUnitario": 5,
  "detalle": "Venta de producto"
}