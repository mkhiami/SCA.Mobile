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
    
    public partial class User
    {
        public User()
        {
            this.Activities = new HashSet<Activity>();
            this.Comments = new HashSet<Comment>();
            this.Tasks = new HashSet<Task>();
            this.Tasks1 = new HashSet<Task>();
        }
    
        public int ID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public Nullable<int> SubstituteId { get; set; }
        public Nullable<int> DelegateId { get; set; }
        public string DivisionCode { get; set; }
        public string DepartmentCode { get; set; }
        public string SectionCode { get; set; }
        public string JobTitleEn { get; set; }
        public string JobTitleAr { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Language { get; set; }
        public string PIN { get; set; }
        public string ImageURL { get; set; }
        public string SignatureURL { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> LastRefresh { get; set; }
    
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Task> Tasks1 { get; set; }
    }
}
