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
    
    public partial class OrganizationalUnit
    {
        public int ID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Type { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> FolderId { get; set; }
    }
}