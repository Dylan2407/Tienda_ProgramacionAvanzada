//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursoWeb2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UBICACION
    {
        public int IdUbicacion { get; set; }
        public string IdProvincia { get; set; }
        public string IdDepartamento { get; set; }
        public string IdDistrito { get; set; }
        public string Direccion_Exacta { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        public virtual DISTRITO DISTRITO { get; set; }
        public virtual PROVINCIA PROVINCIA { get; set; }
    }
}
