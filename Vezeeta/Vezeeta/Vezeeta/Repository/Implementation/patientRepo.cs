using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.Repository.Interfaces;

namespace Vezeeta.Repository.Implementation
{
    public class patientRepo : IpatientRep
    {
        private readonly VezeetaContext _VezeetaContext;
        public patientRepo(VezeetaContext vezeetaContext)
        {
            _VezeetaContext = vezeetaContext;
        }

        public Patient AddPatient(PatientParam NewPatient)
        {
            try
            {
                Patient TheNewPatient = new Patient();
                int Id = 0;
                if (_VezeetaContext.Patients.Any())
                {
                    Id = _VezeetaContext.Patients.Max(x => x.Id);
                }

                Id++;
                TheNewPatient.Id = Id;
                TheNewPatient.FirstName = NewPatient.FirstName;
                TheNewPatient.LastName = NewPatient.LastName;
                TheNewPatient.Email = NewPatient.Email;
                TheNewPatient.Phone = NewPatient.Phone;
                TheNewPatient.Gender = NewPatient.Gender;
                TheNewPatient.DateOfBirth = NewPatient.DateOfBirth;

                if (NewPatient.Image != null)
                {
                    TheNewPatient.Image = NewPatient.Image;
                }

                _VezeetaContext.Patients.Add(TheNewPatient);
                _VezeetaContext.SaveChanges();

                return TheNewPatient;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string DeletePatient(int id)
        {
            try
            {
                var ThePatientDel = _VezeetaContext.Patients.Find(id);
                if (ThePatientDel != null)
                {
                    _VezeetaContext.Patients.Remove(ThePatientDel);
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

        public Patient EditPatient(Patient EditPatient)
        {
            try
            {
                var TheEditPatient = _VezeetaContext.Patients.Find(EditPatient.Id);
                if (TheEditPatient != null)
                {
                    TheEditPatient.FirstName = EditPatient.FirstName;
                    TheEditPatient.LastName = EditPatient.LastName;
                    TheEditPatient.Email = EditPatient.Email;
                    TheEditPatient.Phone = EditPatient.Phone;
                    TheEditPatient.Gender = EditPatient.Gender;
                    TheEditPatient.DateOfBirth = EditPatient.DateOfBirth;
                    TheEditPatient.Image = EditPatient.Image;
                    _VezeetaContext.SaveChanges();

                    return TheEditPatient;
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Patient GetPatientById(int id)
        {
            var ThePatient = _VezeetaContext.Patients.Find(id);
            return ThePatient;
        }

        public IEnumerable<Patient> GetPatients()
        {
            if (_VezeetaContext.Patients.Any())
            {
                var Patients = _VezeetaContext.Patients.ToList();

                return Patients;
            }

            return null;
        }

        public int GetPatientsNum()
        {

                var PatientsNum = _VezeetaContext.Patients.Count();
                return PatientsNum;
             
        }
    }
}
