using CoWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Spaces
{
    public class Space:AggregateRoot<Guid>
    {
        public string Name { get;private set; }
        public int BaseCapacity { get; private set;  }
        public decimal BaseDailyPrice {  get; private set; }
        public WorkHours WorkHours { get; private set; }
        private readonly List<DailySpaceSetting> _dailySettings= new List<DailySpaceSetting>();
        public IReadOnlyCollection<DailySpaceSetting> DailySettings => _dailySettings.AsReadOnly();
        private Space() { }
        public Space(string name,int baseCapacity,decimal baseDailyPrice,WorkHours workHours)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name is requied");
            if (baseCapacity <= 0) throw new ArgumentException("capacity must be greater than zero");
            if (baseDailyPrice <= 0) throw new ArgumentException("Price must be greater than zero");
            Id= Guid.NewGuid();
            Name= name;
            BaseCapacity= baseCapacity;
            WorkHours= workHours;
            BaseDailyPrice= baseDailyPrice;

        }
        private DailySpaceSetting GetOrCreateDailySetting(DateOnly date)
        {
            var setting = _dailySettings.FirstOrDefault(x => x.Date == date);
            if (setting == null)
            {
                setting=new DailySpaceSetting(date);
                _dailySettings.Add(setting);
            }
            return setting;
        }
        public void Reserve(DateOnly date)
        {
            var setting=GetOrCreateDailySetting(date);
            setting.ReserveSeat(BaseCapacity);
        }
        public void ChangeDailyCapacity(DateOnly date,int capacity)
        {
            var setting= GetOrCreateDailySetting(date);
            setting.ChangeCapacity(capacity);
        }
        public void ChangeDailyPrice(DateOnly date, decimal price)
        {
            var setting= GetOrCreateDailySetting(date); 
            setting.ChangePrice(price);
        }
        public void CloseDay(DateOnly date)
        {
            var setting = GetOrCreateDailySetting(date);
            setting.Close();
        }
        public decimal GetPriceFor(DateOnly date)
        {
            var setting=_dailySettings.FirstOrDefault(x=>x.Date == date);
            return setting?.GetEffectivePrice(BaseDailyPrice)??BaseDailyPrice;
        }

    }
}
