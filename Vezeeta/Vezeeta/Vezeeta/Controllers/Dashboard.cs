using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.Repository.Interfaces;
using Vezeeta.TokenModel.JWTRepository.Interfaces;

namespace Vezeeta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Dashboard : ControllerBase
    {
        private readonly IJWTManager _IJWTManager;

        private readonly IDoctorRepo _DoctorRepo;
        private readonly IpatientRep _IpatientRep;
        private readonly ISettingRepo _ISettingsRepo;
        public Dashboard(IDoctorRepo DoctorRepo , IJWTManager jWTManager,IpatientRep ipatientRep, ISettingRepo isettingsRepo)
        {
            _DoctorRepo = DoctorRepo;    
            _IJWTManager = jWTManager;  
            _IpatientRep = ipatientRep;
            _ISettingsRepo = isettingsRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(Login usersdata)
        {
            var UserAuth = _IJWTManager.Authenticate(usersdata);

            return Ok(UserAuth);
        }

        [HttpGet("GetDoctorsNum")]
        public IActionResult NumOfDoctors()
        {
            var DocNum = _DoctorRepo.GetDocNum();
            return Ok(DocNum);
        }


        [HttpGet("GetPatientsNum")]
        public IActionResult NumOfPatients()
        {
            var PatientsNum = _IpatientRep.GetPatientsNum();
            return Ok(PatientsNum);
        }


        [HttpGet("GetRequestsNum")]
        public IActionResult NumOfRequests()
        {
            var RequestsNum = _ISettingsRepo.GetSettingsNum();
            if (RequestsNum != null )
            {
                return Ok(RequestsNum);
            }
            return Ok(0);
        }


    }
}
