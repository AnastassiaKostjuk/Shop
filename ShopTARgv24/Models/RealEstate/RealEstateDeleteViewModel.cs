using System;
using System.Collections.Generic;

namespace ShopTARgv24.Models.RealEstate
{
    public class RealEstateDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string? Area { get; set; }

        public string? Location { get; set; }

        public int? RoomNr { get; set; }

        public string? BuildingType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}
