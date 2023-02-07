namespace TaxiManager.Data.Models
{
    using System;

    using TaxiManager.Data.Common.Models;
    using TaxiManager.Data.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string CarId { get; set; }

        public virtual Car Car { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
