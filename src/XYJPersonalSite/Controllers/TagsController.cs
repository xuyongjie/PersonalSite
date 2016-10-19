using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Data;
using XYJPersonalSite.Models.BusinessModels;
using XYJPersonalSite.Repo;

namespace XYJPersonalSite.Controllers
{
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TagsRepo _repo;
        public TagsController(ApplicationDbContext context)
        {
            _context = context; 
            _repo=new TagsRepo(_context);   
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            return PartialView(await _repo.GetTop(10));
        }

        private bool TagExists(string id)
        {
            return _context.Tags.Any(e => e.TagName == id);
        }
    }
}
