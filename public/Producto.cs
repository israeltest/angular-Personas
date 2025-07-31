﻿namespace ApiProductos.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public string? Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
