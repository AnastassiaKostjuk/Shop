using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv24.Core.Dto;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Data;
using ShopTARgv24.Models.RealEstate;

namespace ShopTARgv24.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopTARgv24Context _context;
        private readonly IRealEstateServices _realEstateServices;
        

        public RealEstateController
        (
            ShopTARgv24Context context,
            IRealEstateServices realEstateServices
            
        )
        {
            _context = context;
            _realEstateServices = realEstateServices;
            
        }

        // INDEX
        public IActionResult Index()
        {
            var result = _context.RealEstate
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Area = x.Area,
                    Location = x.Location,
                    RoomNr = x.RoomNr,
                    BuildingType = x.BuildingType
                });

            return View(result);
        }

        // CREATE (GET)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            RealEstateCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto
            {
                Id = vm.Id,
                Area = vm.Area,
                Location = vm.Location,
                RoomNr = vm.RoomNr,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _realEstateServices.Create(dto);

            return RedirectToAction(nameof(Index));
        }

        // DELETE (GET)
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstateServices.DetailAsync(id);

            if (realEstate == null)
                return NotFound();

           

            var vm = new RealEstateDeleteViewModel
            {
                Id = realEstate.Id,
                Area = realEstate.Area,
                Location = realEstate.Location,
                RoomNr = realEstate.RoomNr,
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt,
            };

            return View(vm);
        }

        // DELETE (POST)
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstate = await _realEstateServices.Delete(id);

            if (realEstate != null)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        // UPDATE (GET)
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstateServices.DetailAsync(id);

            if (realEstate == null)
                return NotFound();

            
            var vm = new RealEstateCreateUpdateViewModel
            {
                Id = realEstate.Id,
                Area = realEstate.Area,
                Location = realEstate.Location,
                RoomNr = realEstate.RoomNr,
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt
            };

            return View("CreateUpdate", vm);
        }

        // UPDATE (POST)
        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto
            {
                Id = vm.Id,
                Area = vm.Area,
                Location = vm.Location,
                RoomNr = vm.RoomNr,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt     
            };

            var result = await _realEstateServices.Update(dto);

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.DetailAsync(id);

            if (realEstate == null)
                return NotFound();

            var vm = new RealEstateDetailsViewModel
            {
                Id = realEstate.Id,
                Area = realEstate.Area,
                Location = realEstate.Location,
                RoomNr = realEstate.RoomNr,
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt
            };


            return View(vm);
        }

        // REMOVE IMAGE
    }
}
