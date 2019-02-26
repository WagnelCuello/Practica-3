namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(30)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(30)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La Direccion es requerida")]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "Debe de ingresar un mail valido")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(15)]
        public string Movil { get; set; }

        [Required(ErrorMessage = "Por favor suba una imagen")]
        [StringLength(50)]
        public string ImageUrl { get; set; }
    }
}
