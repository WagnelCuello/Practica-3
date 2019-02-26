namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        [Column("Producto")]
        [StringLength(50)]
        public string Producto1 { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public double? Precio { get; set; }

        public int? CantExistencia { get; set; }

        [Required(ErrorMessage = "Por favor suba una imagen")]
        [StringLength(50)]
        public string ImageUrl { get; set; }
    }
}
