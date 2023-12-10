using System;

namespace Assets.Scripts.Data
{
    public interface IDateConverter
    {
        public string DateToString(DateTime date);
        public DateTime StringToDate(string str);
    }
}