//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agenda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Deparment
    {
        public Deparment()
        {
            this.PhoneExts = new HashSet<PhoneExt>();
        }
    
        public int Id { get; set; }

        [Display(Name="Departamento")]
        public string Name { get; set; }
    
        public virtual ICollection<PhoneExt> PhoneExts { get; set; }
    }
}
