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
    public class PatientsApi : ControllerBase
    {
        private readonly IpatientRep _patientRepo;
        public PatientsApi(IpatientRep patientRepo) 
        { 
        this._patientRepo = patientRepo;
        }

        [HttpGet("GetPatients")]
        public IActionResult GetAllPatients()
        {
            var patients = _patientRepo.GetPatients();
            if (patients != null)
            {
                return Ok(new { message = "success", data = patients, status = Ok() });
            }

            return Ok(new { message = "No Doctors Found", data = patients, status = NoContent() });
        }

        [HttpGet("GetpatientById/{id}")]
        public IActionResult GetpatientByID(int Id)
        {
            var Thepatient = _patientRepo.GetPatientById(Id);
            if (Thepatient != null)
            {
                return Ok(new { message = "success", data = Thepatient, status = Ok() });
            }

            return Ok(new { message = "Doctor Not Found", data = Thepatient, status = NotFound() });
        }

        [HttpPost("AddNewpatient")]
        public IActionResult Addpatient(PatientParam Newpatient)
        {
            var TheNewNewpatient = _patientRepo.AddPatient(Newpatient);
            if (TheNewNewpatient != null)
            {
                return Ok(new { message = "success", data = TheNewNewpatient, status = HttpStatusCode.Created });
            }

            return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });

        }

        [HttpDelete("Deletepatient/{id}")]
        public IActionResult DeleteThepatient(int id)
        {
            var patientDel = _patientRepo.DeletePatient(id);
            if (patientDel == "Success")
            {
                return Ok(new { message = "success", data = "", status = Ok() });
            }

            else if (patientDel == "NotFound")
            {
                return Ok(new { message = "Doctor Not Found", data = "", status = NotFound() });
            }
            else
            {
                return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });
            }
        }

        [HttpPost("Editpatient")]
        public IActionResult EditThepatient(Patient TheEditpatient)
        {
            var patientEdited = _patientRepo.EditPatient(TheEditpatient);
            if (patientEdited != null)
            {
                return Ok(new { message = "success", data = patientEdited, status = HttpStatusCode.OK });
            }

            return Ok(new { message = "Some Thing Goes Wrong Or Doctor Not Found Please Try again", data = "", status = NotFound() });

        }

    }
}
