using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYJPersonalSite.Data;

namespace XYJPersonalSite.ViewComponents
{
    public class TagsViewComponent:ViewComponent
    {
        private readonly TagsRepo _repo;
        public TagsViewComponent(ApplicationDbContext context)
        {
            _repo = new TagsRepo(context);
        }

        public async Task<IViewComponentResult> InvokeAsync(int topCount)
        {
            return View("TopTag",await _repo.GetTop(topCount));
        }
    }
}
