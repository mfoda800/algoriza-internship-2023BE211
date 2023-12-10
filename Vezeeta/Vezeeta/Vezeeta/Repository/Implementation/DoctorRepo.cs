using System.Text;
using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.Repository.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Vezeeta.Repository.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
     // private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv;
        private readonly VezeetaContext _VezeetaContext;
        public DoctorRepo(VezeetaContext vezeetaContext)
        {
            _VezeetaContext = vezeetaContext;
            //Microsoft.AspNetCore.Hosting.IHostingEnvironment ev
            //hostingEnv = ev;    
        }

        public Doctor AddDoctor(DoctorParam NewDoctor)
        {
            try
            {
                Doctor NewDoc = new Doctor();
                int Id = 0;
                if (_VezeetaContext.Doctors.Any())
                {
                    Id = _VezeetaContext.Doctors.Max(x => x.Id);
                }

                Id++;
                NewDoc.Id = Id;
                NewDoc.FirstName = NewDoctor.FirstName;
                NewDoc.LastName = NewDoctor.LastName;
                NewDoc.Email = NewDoctor.Email;
                NewDoc.Phone = NewDoctor.Phone;
                NewDoc.SpecializeId = NewDoctor.SpecializeId;
                NewDoc.Gender = NewDoctor.Gender;
                NewDoc.DateOfBirth = NewDoctor.DateOfBirth;

                if (NewDoctor.Image != null)
                {
                    //byte[] bytes = Convert.FromBase64String(NewDoctor.Image);

                    //string FilePath = Path.Combine(hostingEnv.WebRootPath, "Images");

                    //if (!Directory.Exists(FilePath))
                    //    Directory.CreateDirectory(FilePath);

                    //var fileName = bytes;

                    //var filePath = Path.Combine(FilePath, NewDoctor.Image);

                    //using (FileStream fs = System.IO.File.Create(filePath))
                    //{
                    //    NewDoctor.Image.CopyTo(fs);
                    //}

                    NewDoc.Image = NewDoctor.Image;
                }

                _VezeetaContext.Doctors.Add(NewDoc);
                _VezeetaContext.SaveChanges();

                return NewDoc;
            }
            catch (Exception)
            {

                return null;
            }
            
           
        }

        public string DeleteDoctor(int id)
        {
            try
            {
                var TheDoctorDel = _VezeetaContext.Doctors.Find(id);
                if (TheDoctorDel != null)
                { 
                   _VezeetaContext.Doctors.Remove(TheDoctorDel);
                   _VezeetaContext.SaveChanges();
                    return "Success";
                }
                return "NotFound";
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Doctor EditDoctor(Doctor EditDoctor)
        {
            try
            {
                var TheEditDoctor = _VezeetaContext.Doctors.Find(EditDoctor.Id);
                if (TheEditDoctor != null)
                {
                    TheEditDoctor.FirstName= EditDoctor.FirstName;
                    TheEditDoctor.LastName= EditDoctor.LastName;
                    TheEditDoctor.Email = EditDoctor.Email; 
                    TheEditDoctor.Phone= EditDoctor.Phone;
                    TheEditDoctor.SpecializeId= EditDoctor.SpecializeId;
                    TheEditDoctor.Gender= EditDoctor.Gender;
                    TheEditDoctor.DateOfBirth= EditDoctor.DateOfBirth;
                    TheEditDoctor.Image= EditDoctor.Image;
                    _VezeetaContext.SaveChanges();

                    return TheEditDoctor;
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public Doctor GetDoctorById(int id)
        {
                var TheDoctor = _VezeetaContext.Doctors.Find(id);
                return TheDoctor;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            if (_VezeetaContext.Doctors.Any())
            {
                var Doctors = _VezeetaContext.Doctors.ToList();

                return Doctors;
            }

            return null;
           
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            try
            {
                if (_VezeetaContext.Specializations.Any())
                {
                    var Specializations = _VezeetaContext.Specializations.ToList();
                    return Specializations;
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        int IDoctorRepo.GetDocNum()
        {

            var DocNum = _VezeetaContext.Doctors.Count();
            return DocNum;

        }

    }
}
