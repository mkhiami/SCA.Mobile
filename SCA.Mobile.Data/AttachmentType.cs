//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCA.Mobile.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AttachmentType
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    
        public virtual Attachment Attachment { get; set; }
    }
}
