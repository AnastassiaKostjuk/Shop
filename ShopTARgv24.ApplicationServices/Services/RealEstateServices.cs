using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Domain;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Data;

namespace ShopTARgv24.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly ShopTARgv24Context _context;


        public RealEstateServices(
            ShopTARgv24Context context
 
        )
        {
            _context = context;

        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid(); // Generate a new GUID for the real estate
            realEstate.Area = dto.Area;
            realEstate.Location = dto.Location;
            realEstate.RoomNr = dto.RoomNr;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;


            await _context.RealEstate.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> DetailAsync(Guid id)
        {
            var result = await _context.RealEstate
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realEstate = await _context.RealEstate
                .FirstOrDefaultAsync(x => x.Id == id);

            if (realEstate != null)
            {
                _context.RealEstate.Remove(realEstate);
                await _context.SaveChangesAsync();
            }

            return realEstate;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate domain = new RealEstate();

            domain.Id = dto.Id ?? Guid.NewGuid();
            domain.Area = dto.Area;
            domain.Location = dto.Location;
            domain.RoomNr = dto.RoomNr;
            domain.BuildingType = dto.BuildingType;
            domain.CreatedAt = dto.CreatedAt ?? DateTime.Now;
            domain.ModifiedAt = DateTime.Now;

            _context.RealEstate.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
