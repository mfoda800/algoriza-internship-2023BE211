using Vezeeta.Models;
using Vezeeta.Parameter;

namespace Vezeeta.Repository.Interfaces
{
    public interface IDoctorRepo
    {
        int GetDocNum();
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorById(int id);

        Doctor AddDoctor(DoctorParam NewDoctor);

        string DeleteDoctor(int id);

        Doctor EditDoctor(Doctor EditDoctor);

        IEnumerable<Specialization> GetSpecializations();
    }
}
