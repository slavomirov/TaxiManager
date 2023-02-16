namespace TaxiManager.Web.Infrastructure
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MinimumAge : ValidationAttribute
    {
        private int minimumAge;

        public MinimumAge(int minimumAge)
        {
            this.minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(this.minimumAge) <= DateTime.Now;
            }

            return false;
        }
    }
}
