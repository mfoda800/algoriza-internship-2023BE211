using Vezeeta.Models;
using Vezeeta.Parameter;
using Vezeeta.ViewModel;

namespace Vezeeta.Repository.Interfaces
{
    public interface ISettingRepo
    {
        IEnumerable<RequestsNum> GetSettingsNum();
        IEnumerable<Setting> GetSettings();
        Setting AddSetting(SettingParam NewSetting);
        Setting UpdateSetting(Setting UpdateSetting);
        string DeleteSetting(int id);
        Setting AddPrescription(SettingParam Prescription);

    }
}
