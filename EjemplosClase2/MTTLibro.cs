//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjemplosClase2
{
    using System;
    using System.Collections.Generic;
    
    public partial class MTTLibro
    {
        public int CodigoLibro { get; set; }
        public int CodigoEditorial { get; set; }
        public string Titulo { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
        public System.DateTime FechaInserto { get; set; }
        public string UsuarioInserto { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public string UsuarioModifico { get; set; }
    
        public virtual MTTEditorial MTTEditorial { get; set; }
    }
}
