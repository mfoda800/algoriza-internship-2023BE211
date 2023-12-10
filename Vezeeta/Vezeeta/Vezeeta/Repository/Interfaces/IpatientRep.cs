using Vezeeta.Models;
using Vezeeta.Parameter;

namespace Vezeeta.Repository.Interfaces
{
    public interface IpatientRep
    {
        int GetPatientsNum();
        IEnumerable<Patient> GetPatients();
        Patient GetPatientById(int id);

        Patient AddPatient(PatientParam NewPatient);

        string DeletePatient(int id);

        Patient EditPatient(Patient EditPatient);
    }
}
