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
    
    public partial class TimeSheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TaskID { get; set; }
        public string Comments { get; set; }
        public System.DateTime From { get; set; }
        public System.DateTime To { get; set; }
        public Nullable<int> Allocation { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
