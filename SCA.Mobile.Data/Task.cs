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
    
    public partial class Task
    {
        public Task()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> AssignedById { get; set; }
        public Nullable<int> AssignedToId { get; set; }
        public int ActivityId { get; set; }
        public Nullable<int> ParentTaskId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<System.DateTime> DueBy { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public byte[] Modified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> ResultId { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual TaskCategory TaskCategory { get; set; }
        public virtual TaskResult TaskResult { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Task Tasks1 { get; set; }
        public virtual Task Task1 { get; set; }
        public virtual TaskType TaskType { get; set; }
    }
}
