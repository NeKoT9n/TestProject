using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class DateConverter
    {
        public string DateToString(DateTime date)
        {           
            return date.ToString();
        }

        public DateTime StringToDate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException("text is empty");
            }

            return DateTime.Parse(str);
        }
        
    }
}