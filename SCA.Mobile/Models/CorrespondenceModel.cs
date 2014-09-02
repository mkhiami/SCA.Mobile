using SCA.OracleModules.Common;
using SCA.OracleModules.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCA.Mobile.API.Models
{
    public class Correspondence : CorrespondenceDTO
    {

        public string AssignedTo { get; set; }
        public string AssignedToAr { get; set; }
        public bool? Confidential { get; set; }
        public string CorrespondenceType { get; set; }
        public DateTime? DateArchived { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateSent { get; set; }
        public string DDescription { get; set; }
        public string Description { get; set; }
        public Direction? Direction { get; set; }
        public string DTitle { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Internal { get; set; }
        public LanguageEnum Language { get; set; }
        public string MessageType { get; set; }
        public decimal? MessageTypeID { get; set; }
        public decimal? ObjectID { get; set; }
        public string OUCode { get; set; }
        public Priority? Priority { get; set; }
        public string ReferenceNumber { get; set; }
        public string RelatedEntity { get; set; }
        public string RelatedEntityDescription { get; set; }
        public decimal? RelatedEntityID { get; set; }
        public string RelatedEntityType { get; set; }
        public decimal? RelatedEntityTypeID { get; set; }
        public decimal? ResponsibleID { get; set; }
        public string ResponsibleUser { get; set; }
        public string SentToUserFullName { get; set; }
        public decimal? SentToUserId { get; set; }
        public string Serial { get; set; }
        public string TaskSummary { get; set; }
        public decimal? TypeID { get; set; }

        public List<TaskDTO> Tasks { get; set; }
        public List<AttachementDTO> Attachments { get; set; }
        public List<CorrespondenceCCDTO> CCs { get; set; }
        public List<CorrespondenceDTO> Related { get; set; }
        public List<User> Users { get; set; }
        public Correspondence()
        {
            Tasks = new List<TaskDTO>();
            Users = new List<User>();
            Tasks = new List<TaskDTO>();
            Attachments = new List<AttachementDTO>();
        }
        public Correspondence(CorrespondenceDTO dto)
        {
            this.AssignedTo = dto.AssignedTo;
            this.AssignedToAr = dto.AssignedToAr;
            this.Comments = dto.Comments;
            this.Confidential = dto.Confidential;
            this.CorrespondenceType = dto.CorrespondenceType;
            this.Created = dto.Created;
            this.CreatedBy = dto.CreatedBy;
            this.DateArchived = dto.DateArchived;

            this.DateCompleted = dto.DateCompleted;
            this.DateReceived = dto.DateReceived;
            this.DateSent = dto.DateSent;
            this.DDescription = dto.DDescription;
            this.Description = dto.Description;
            this.Direction = dto.Direction;
            this.DTitle = dto.DTitle;
            this.DueDate = dto.DueDate;
            this.ID = dto.ID;
            this.Internal = dto.Internal;
            this.Language = dto.Language;
            this.MessageType = dto.MessageType;
            this.MessageTypeID = dto.MessageTypeID;
            this.Modified = dto.Modified;
            this.ModifiedBy = dto.ModifiedBy;
            this.ObjectID = dto.ObjectID;
            this.Priority = dto.Priority;
            this.ReferenceNumber = dto.ReferenceNumber;
            this.RelatedEntity = dto.RelatedEntity;
            this.RelatedEntityDescription = dto.RelatedEntityDescription;
            this.RelatedEntityID = dto.RelatedEntityTypeID;
            this.ResponsibleID = dto.ResponsibleID;
            this.ResponsibleUser = dto.ResponsibleUser;
            this.SentToUserFullName = dto.SentToUserFullName;
            this.SentToUserId = dto.SentToUserId;
            this.Status = dto.Status;
            this.TaskSummary = dto.TaskSummary;
            this.Title = dto.Title;
            this.TypeID = dto.TypeID;

        }
    }

    public class User : UserDTO
    {
        public List<User> Subordinates { get; set; }
        public User Manager { get; set; }
        public User(UserDTO dto)
        {
            this.Abbreviation = dto.Abbreviation;
            this.AbbreviationAr = dto.AbbreviationAr;
            this.Comments = dto.Comments;
            this.Created = dto.Created;
            this.CreatedBy = dto.CreatedBy;
            this.DepartmentID = dto.DepartmentID;
            this.DeprtmentFolderId = dto.DeprtmentFolderId;
            this.DivisionID = dto.DivisionID;
            this.Email = dto.Email;
            this.FirstName = dto.FirstName;
            this.FirstNameAr = dto.FirstName;
            this.FullName = dto.FullName;
            this.FullNameAr = dto.FullNameAr;
            this.FullNameS = dto.FullNameS;
            this.Grade = dto.Grade;
            this.GradeDesc = dto.GradeDesc;
            this.GradeDescAr = dto.GradeDescAr;
            this.ID = dto.ID;
            this.JobDescription = dto.JobDescription;
            this.JobDescriptionAr = dto.JobDescriptionAr;
            this.JobTitle = dto.JobTitle;
            this.JobTitleAr = dto.JobTitleAr;
            this.Language = dto.Language;
            this.LastName = dto.LastName;
            this.LastNameAr = dto.LastNameAr;
            this.ManagerID = dto.ManagerID;
            this.Nationality = dto.Nationality;
            this.SectionID = dto.SectionID;
            this.Status = dto.Status;
            this.SubstituteID = dto.SubstituteID;
            this.UserName = dto.UserName;
        }
    }

    public class Task : TaskDTO
    {
        public User AssignedTo { get; set; }
        public User AssignedBy { get; set; }
        public Correspondence Correspondence { get; set; }

        public Task(TaskDTO dto)
        {
            this.AssignedByFullName = dto.AssignedByFullName;
            this.AssignedToFullName = dto.AssignedToFullName;
            this.Comments = dto.Comments;
            this.CompletedDate = dto.CompletedDate;
            this.Created = dto.Created;
            this.CreatedBy = dto.CreatedBy;
            this.Description = dto.Description;
            this.DueDate = dto.DueDate;
            this.ID = dto.ID;
            this.Title = dto.Title;
            this.TaskTypeID = dto.TaskTypeID;
            this.Status = dto.Status;
            this.ServiceID = dto.ServiceID;
            this.RelatedEntityID = dto.RelatedEntityID;
            this.RelatedEntity = dto.RelatedEntity;
            this.Priority = dto.Priority;
            this.PreviousTaskId = dto.PreviousTaskId;

        }

    }

    public class Attachment : AttachementDTO
    {
        public Correspondence Correspondence { get; set; }
        public Attachment(AttachementDTO dto)
        {
            this.AddedBy = dto.AddedBy;
            this.ArchiveID = dto.ArchiveID;
            this.Comments = dto.Comments;
            this.Created = dto.Created;
            this.CreatedBy = dto.CreatedBy;
            this.DateArchived = dto.DateArchived;
            this.FileLocation = dto.FileLocation;
            this.FileName = dto.FileName;
            this.FileTypeId = dto.FileTypeId;
            this.ID = dto.ID;
            this.Modified = dto.Modified;
            this.ModifiedBy = dto.ModifiedBy;
            this.RelatedEntity = dto.RelatedEntity;
            this.RelatedEntityID = dto.RelatedEntityID;
            this.Status = dto.Status;
            this.Title = dto.Title;

        }

    }
}