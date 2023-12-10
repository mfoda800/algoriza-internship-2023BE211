using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.Repository.Implementation;
using Vezeeta.Repository.Interfaces;

namespace Vezeeta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsAPI : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;
        public DoctorsAPI(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        [HttpGet("GetDoctors")]
        public IActionResult GetAllDoctors() 
        {
            var Doctors = _doctorRepo.GetDoctors();
            if (Doctors != null)
            {
                return Ok(new {message="success",data=Doctors,status=Ok()});
            }

            return Ok(new { message = "No Doctors Found", data = Doctors, status = NoContent() }) ;
        }

        [HttpGet("GetDoctorById/{id}")]
        public IActionResult GetDocById(int Id)
        {
            var TheDoctor = _doctorRepo.GetDoctorById(Id);
            if (TheDoctor != null)
            {
                return Ok(new { message = "success", data = TheDoctor, status = Ok() });
            }

            return Ok(new { message = "Doctor Not Found", data = TheDoctor, status = NotFound() });
        }

        [HttpPost("AddNewDoctor")]
        public IActionResult AddDoctor(DoctorParam NewDoctor)
        {
            var NewDoc = _doctorRepo.AddDoctor(NewDoctor);
            if (NewDoc != null)
            {
                return Ok(new { message = "success", data = NewDoc, status = HttpStatusCode.Created});
            }

            return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });

        }

        [HttpDelete("DeleteDoctor/{id}")]
        public IActionResult DeleteDoc(int id)
        {
            var DocDel=_doctorRepo.DeleteDoctor(id);
            if (DocDel == "Success")
            {
                return Ok(new { message = "success", data = "", status = Ok() });
            }

            else if(DocDel == "NotFound")
            {
                return Ok(new { message = "Doctor Not Found", data = "", status = NotFound() });
            }
            else
            {
                return Ok(new { message = "Some Thing Goes Wrong Please Try again", data = "", status = BadRequest() });
            }
        }

        [HttpPost("EditDoctor")]
        public IActionResult EditTheDoctor(Doctor TheEditDoctor)
        {
            var DoctorEdited = _doctorRepo.EditDoctor(TheEditDoctor);
            if (DoctorEdited != null)
            {
                return Ok(new { message = "success", data = DoctorEdited, status = HttpStatusCode.OK });
            }

            return Ok(new { message = "Some Thing Goes Wrong Or Doctor Not Found Please Try again", data = "", status = NotFound() });


        }

        [HttpGet("GetSpecializations")]
        public IActionResult GetAllSpecializations()
        {
            var Specializations=_doctorRepo.GetSpecializations();
            if (Specializations != null)
            {
                return Ok(new { message = "success", data = Specializations, status = Ok() });
            }

            return Ok(new { message = "No Specializations Found", data = Specializations, status = NoContent() });
        }

    }
    }

