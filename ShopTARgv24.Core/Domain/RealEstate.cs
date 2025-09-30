namespace ShopTARgv24.Core.Domain
{
    public class RealEstate
    {
        public Guid Id { get; set; }
        
        public string? Area { get; set; }

        public string? Location { get; set; }

        public int? RoomNr { get; set; }

        public string? BuildingType { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? CreatedAt { get; set; }


    }
}
