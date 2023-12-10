using Vezeeta.Models;
using Vezeeta.Repository.Interfaces;
using Vezeeta.ViewModel;
using Vezeeta.Enum;
using Vezeeta.Parameter;

namespace Vezeeta.Repository.Implementation
{
    public class SettingRepo : ISettingRepo
    {
        private readonly VezeetaContext _VezeetaContext;
        public SettingRepo(VezeetaContext vezeetaContext)
        {
            _VezeetaContext = vezeetaContext;
        }

        public Setting AddPrescription(SettingParam Prescription)
        {
            try
            {

                var ThePrescription = _VezeetaContext.Settings.FirstOrDefault(x=>x.DoctorId== Prescription.DoctorId && x.PatientId== Prescription.PatientId && x.Status == (int)SettingsStatus.Pending);
                if (ThePrescription != null)
                {
                    ThePrescription.Prescription = Prescription.Prescription;
                    ThePrescription.Status = (int?)SettingsStatus.Completed;
                    _VezeetaContext.SaveChanges();
                    return ThePrescription;
                }

                return null;

            }
               
            catch (Exception)
            {

                return null;
            }

            }

        public Setting AddSetting(SettingParam NewSetting)
        {
            try
            {
                Setting TheNewSetting = new Setting();

                int Id = 0;
                if (_VezeetaContext.Settings.Any())
                {
                    Id = _VezeetaContext.Settings.Max(x=>x.Id);
                }

                Id++;
                TheNewSetting.Id= Id;
                TheNewSetting.DoctorId = NewSetting.DoctorId;
                TheNewSetting.PatientId= NewSetting.PatientId;
                TheNewSetting.Date= NewSetting.Date;
                TheNewSetting.Price = NewSetting.Price;

                if (!string.IsNullOrEmpty(NewSetting.DiscoundCode))
                {
                    TheNewSetting.DiscoundCode = NewSetting.DiscoundCode;

                    if (_VezeetaContext.DiscoundTypes.Any(x=>x.DiscoundCode==NewSetting.DiscoundCode))
                    {
                        var TheDiscound = _VezeetaContext.DiscoundTypes.FirstOrDefault(x=>x.DiscoundCode==NewSetting.DiscoundCode);
                        if (TheDiscound != null)
                        {
                            if (TheDiscound.IsActive==true)
                            {
                                decimal OriginalPrice= (decimal)NewSetting.Price;
                                decimal Percent = (decimal)TheDiscound.DiscoundPercent;
                                decimal TheFinalPrice = (OriginalPrice * Percent)/100;
                                TheNewSetting.FinalPrice = TheFinalPrice;
                            }
                            else
                            {
                                TheNewSetting.FinalPrice = NewSetting.Price;
                            }
                        }
                        else
                        {
                            TheNewSetting.FinalPrice = NewSetting.Price;
                        }
                    }
                    else
                    {
                        TheNewSetting.FinalPrice = NewSetting.Price;
                    }
                }
                else
                {
                    TheNewSetting.FinalPrice = NewSetting.Price;
                }

                TheNewSetting.Status = (int?)SettingsStatus.Pending;

                _VezeetaContext.Settings.Add(TheNewSetting);
                _VezeetaContext.SaveChanges();

                return TheNewSetting;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string DeleteSetting(int id)
        {
            try
            {
                var TheSettingDel = _VezeetaContext.Settings.Find(id);
                if (TheSettingDel != null)
                {
                    _VezeetaContext.Settings.Remove(TheSettingDel);
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

        public IEnumerable<Setting> GetSettings()
        {
            if (_VezeetaContext.Settings.Any())
            {
                var Settings = _VezeetaContext.Settings.ToList();

                return Settings;
            }

            return null;
        }

        public IEnumerable<RequestsNum> GetSettingsNum()
        {
            if (_VezeetaContext.Patients.Any())
            {

                int PendingRequests = _VezeetaContext.Settings.Where(x => x.Status == (int)SettingsStatus.Pending).Count();
                int CompletedRequests = _VezeetaContext.Settings.Where(x => x.Status == (int)SettingsStatus.Completed).Count();
                int CancelledRequests = _VezeetaContext.Settings.Where(x => x.Status == (int)SettingsStatus.Cancelled).Count();

                var Requests = new List<RequestsNum>();

                var PendingRequest = new RequestsNum();
                PendingRequest.Status = "Pending";
                PendingRequest.RequestsCount = PendingRequests;
                Requests.Add(PendingRequest);

                var CompletedRequest = new RequestsNum();
                CompletedRequest.Status = "Completed";
                CompletedRequest.RequestsCount = CompletedRequests;
                Requests.Add(CompletedRequest);

                var CancelledRequest = new RequestsNum();
                CancelledRequest.Status = "Cancelled";
                CancelledRequest.RequestsCount = CancelledRequests;
                Requests.Add(CancelledRequest);

                return Requests;
            }
            return null;
        }

        public Setting UpdateSetting(Setting UpdateSetting)
        {
            try
            {
                var TheUpdateSetting = _VezeetaContext.Settings.Find(UpdateSetting.Id);
                if (TheUpdateSetting != null)
                {
                    TheUpdateSetting.DoctorId = UpdateSetting.DoctorId;
                    TheUpdateSetting.PatientId = UpdateSetting.PatientId;
                    TheUpdateSetting.Date = UpdateSetting.Date;
                    TheUpdateSetting.Price = UpdateSetting.Price;

                    if (!string.IsNullOrEmpty(UpdateSetting.DiscoundCode))
                    {
                        TheUpdateSetting.DiscoundCode = UpdateSetting.DiscoundCode;

                        if (_VezeetaContext.DiscoundTypes.Any(x => x.DiscoundCode == UpdateSetting.DiscoundCode))
                        {
                            var TheDiscound = _VezeetaContext.DiscoundTypes.FirstOrDefault(x => x.DiscoundCode == UpdateSetting.DiscoundCode);
                            if (TheDiscound != null)
                            {
                                if (TheDiscound.IsActive == true)
                                {
                                    decimal OriginalPrice = (decimal)UpdateSetting.Price;
                                    decimal Percent = (decimal)TheDiscound.DiscoundPercent;
                                    decimal TheFinalPrice = (OriginalPrice * Percent) / 100;
                                    TheUpdateSetting.FinalPrice = TheFinalPrice;
                                }
                                else
                                {
                                    TheUpdateSetting.FinalPrice = UpdateSetting.Price;
                                }
                            }
                            else
                            {
                                TheUpdateSetting.FinalPrice = UpdateSetting.Price;
                            }
                        }
                        else
                        {
                            TheUpdateSetting.FinalPrice = UpdateSetting.Price;
                        }
                    }
                    else
                    {
                        TheUpdateSetting.FinalPrice = UpdateSetting.Price;
                    }

                    TheUpdateSetting.Status = UpdateSetting.Status;
                    _VezeetaContext.SaveChanges();

                    return TheUpdateSetting;
                }

                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
