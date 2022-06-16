using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VIATECH.Domain;
using VIATECH.Domain.Entities;

namespace VIATECH.Controllers
{
    public class ServiceItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ServiceItems
        public async Task<IActionResult> Index()
        {

              return _context.ServiceItems != null ? 
                          View(await _context.ServiceItems.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.ServiceItems'  is null.");
        }

        private bool ServiceItemExists(Guid? id)
        {
          return (_context.ServiceItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
