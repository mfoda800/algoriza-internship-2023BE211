using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.Repository.Implementation;
using Vezeeta.Repository.Interfaces;

namespace Vezeeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingApi : ControllerBase
    {
        private readonly ISettingRepo _settingRepo;

        public SettingApi(ISettingRepo settingRepo)
        {
            _settingRepo = settingRepo;
        }

        [HttpPost("BookSetting")]
        public IActionResult AddSetting(SettingParam NewSetting)
        {
            var TheNewSetting = _settingRepo.AddSetting(NewSetting);
            if (TheNewSetting != null)
            {
                return Ok(new { message = "success", data = TheNewSetting, status = HttpStatusCode.Created });
            }
            return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });
        }

        [HttpPost("UpdateSetting")]
        public IActionResult EditSetting(Setting UpdateSetting)
        {
            var TheupdateSetting = _settingRepo.UpdateSetting(UpdateSetting);
            if (TheupdateSetting != null)
            {
                return Ok(new { message = "success", data = UpdateSetting, status = HttpStatusCode.OK });
            }
            return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });
        }
        [HttpGet("GetSettings")]
        public IActionResult GetAllSettings()
        {
            var Settings = _settingRepo.GetSettings();
            if (Settings != null)
            {
                return Ok(new { message = "success", data = Settings, status = Ok() });
            }

            return Ok(new { message = "No Settings Found", data = Settings, status = NoContent() });
        }

        [HttpDelete("DeleteSetting/{id}")]
        public IActionResult DeleteTheSetting(int id)
        {
            var SettingDel = _settingRepo.DeleteSetting(id);
            if (SettingDel == "Success")
            {
                return Ok(new { message = "success", data = "", status = Ok() });
            }

            else if (SettingDel == "NotFound")
            {
                return Ok(new { message = "Setting Not Found", data = "", status = NotFound() });
            }
            else
            {
                return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });
            }
        }

        [HttpPost("AddPrescription")]
        public IActionResult Prescription(SettingParam AddPrescription)
        {
            var TheAddPrescription = _settingRepo.AddPrescription(AddPrescription);
            if (TheAddPrescription != null)
            {
                return Ok(new { message = "success", data = TheAddPrescription, status = Ok() });
            }

            return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });
        }

   }
}
