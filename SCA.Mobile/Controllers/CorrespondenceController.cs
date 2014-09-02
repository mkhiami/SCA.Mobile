
using SCA.Mobile.API.Models;
using SCA.OracleModules.DAL.Services;
using SCA.OracleModules.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SCA.Mobile.API.Controllers
{
    [RoutePrefix("correspondence")]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class CorrespondenceController : ApiController
    {
        public CorrespondenceService service;

        public CorrespondenceController()
        {
            service = new CorrespondenceService();
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<CorrespondenceDTO> Get()
        {
            int userid = 203;
            try
            {
                userid = int.Parse(User.Identity.Name.Replace("sca", ""));
            }
            catch (Exception)
            {

                //  throw;
            }

            List<CorrespondenceDTO> correspondences = service.GetCorrespondencesByFilter(null, userid, "AR", null, null, null, null, null, null, null, null, null, null, null, 1, 100);
            return correspondences;
        }
        [Route("search/{userid?}")]
        [Route("search/{userid?}/{searchvalue?}/{lang=AR}/{status?}/{relatedEntityId?}/{direction?}/{directiontype?}/{sortColumn?}/{sortOrder?}/{pageSize?}/{startIndex?}")]
        [HttpGet]
        public IEnumerable<CorrespondenceDTO> Get(decimal? userid = null, string searchvalue = null, string lang = "AR", string status = null, int? relatedEntityId = null, string direction = null, int? directiontype = null, string sortColumn = "ID", string sortOrder = "DESC", int pageSize = 100, int startIndex = 0)
        {
            if (!userid.HasValue) userid = int.Parse(User.Identity.Name.Replace("sca", ""));
            List<CorrespondenceDTO> correspondenceDTOs = service.GetCorrespondencesByFilter(searchvalue, userid, lang, status, null, relatedEntityId, null, direction, directiontype, null, null, null, sortColumn, sortOrder, startIndex, pageSize);
            List<Correspondence> correspondences = new List<Correspondence>();
            correspondenceDTOs.ForEach(c => correspondences.Add(new Correspondence(c)));
            return correspondences;
        }



        [ResponseType(typeof(Correspondence))]
        [Route("details")]
        [Route("{id}")]
        public IHttpActionResult GetDetailedByID(int id)
        {
            CorrespondenceDTO dto = service.GetCorrespondenceByID(id);

            var correspondence = new Correspondence(dto);
            correspondence.Attachments = new AttachementService().GetAttachementsByEntityID("Correspondences", correspondence.ID);
            correspondence.Related = service.GetRelatedCorrespondences(correspondence.ID);
            List<UserDTO> cusers = service.GetCorrespondenceUsers(correspondence.ID);
            List<User> users = new List<User>();
            cusers.ForEach(u => users.Add(u as User));
            correspondence.Users = users;
            correspondence.CCs = new CorrespondenceCCService().GetCorrespondenceCCs(correspondence.ID, "AR");
            correspondence.Tasks = new TaskService().GetCorrespondenceTasks(int.Parse(correspondence.ResponsibleID.Value.ToString()), "Correspondences", correspondence.ID, null, null, true, null, null, null, "AR", 0, 100);
            return Ok(correspondence);
        }



        [Route("lookups")]
        public object GetLookups()
        {
            //List<RelatedEntityDTO> related= new RelatedEntityService().ge
            List<UserDTO> userDTOs = new UserService().GetUsersByModule(1);
            var users = from u in userDTOs where u.ID != 31 && u.Status=="Active" select new { ID= int.Parse(u.ID.ToString()), Name= u.FullNameAr, SID= u.SubstituteID};
            return  new { users };
        }

    }
}