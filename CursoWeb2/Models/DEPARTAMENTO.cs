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
    
    public partial class DEPARTAMENTO
    {
        public DEPARTAMENTO()
        {
            this.UBICACIONs = new HashSet<UBICACION>();
        }
    
        public string IdDepartamento { get; set; }
        public string Descripcion_Departamento { get; set; }
    
        public virtual ICollection<UBICACION> UBICACIONs { get; set; }
    }
}
