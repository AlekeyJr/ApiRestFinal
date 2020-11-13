using System;
using System.ComponentModel.DataAnnotations;
namespace pr_web_api_empresa.Models{
    public class Productos{
        [Key]
        public int idProducto{get;set;}
        
        public string producto{get;set;}

        public Int16 idMarca{get;set;}

        public string Descripcion {get;set;}

        public Decimal precio_costo{get;set;}

        public Decimal precio_venta{get;set;}

        public int existencia{get;set;}

        public string fecha_ingreso{get;set;}

    }
}