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
    
    public partial class RUTComment
    {
        public int IdComment { get; set; }
        public Nullable<int> IdUser { get; set; }
        public string Content { get; set; }
        public string UsuarioInserto { get; set; }
        public Nullable<System.DateTime> FechaInserto { get; set; }
        public string UsuarioModifico { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public Nullable<bool> Eliminado { get; set; }
    
        public virtual RUTUser RUTUser { get; set; }
    }
}
