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
    
    public partial class MTTEditorial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MTTEditorial()
        {
            this.MTTLibro = new HashSet<MTTLibro>();
        }
    
        public int CodigoEditorial { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
        public System.DateTime FechaInserto { get; set; }
        public string UsuarioInserto { get; set; }
        public Nullable<System.DateTime> FechaModifico { get; set; }
        public string UsuarioModifico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTTLibro> MTTLibro { get; set; }
    }
}