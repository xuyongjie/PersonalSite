using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYJPersonalSite.Data;
using XYJPersonalSite.Repo;

namespace XYJPersonalSite.ViewComponents
{
    public class BlogTypesViewComponent:ViewComponent
    {
        private readonly BlogTypeRepo _repo;
        public BlogTypesViewComponent(ApplicationDbContext context)
        {
            _repo = new BlogTypeRepo(context);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Types", await _repo.GetAll());
        }
    }
}
