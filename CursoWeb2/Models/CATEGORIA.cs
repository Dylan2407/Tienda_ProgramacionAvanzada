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
    
    public partial class CATEGORIA
    {
        public CATEGORIA()
        {
            this.PRODUCTOes = new HashSet<PRODUCTO>();
        }
    
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual ICollection<PRODUCTO> PRODUCTOes { get; set; }
    }
}
