using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XYJPersonalSite.Data;
using XYJPersonalSite.Models.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using XYJPersonalSite.Models;
using XYJPersonalSite.Repo;
using XYJPersonalSite.Models.BusinessViewModels;

namespace XYJPersonalSite.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ApplicationDbContext _context;

        private readonly BlogsRepo _repo;

        public BlogsController(ApplicationDbContext context,
                    UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
        {
            _repo = new BlogsRepo(context);
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        // GET: Blogs
        public async Task<IActionResult> Index(string searchString,string typeName,string tagName)
        {
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                ViewBag.Title = "Search result for \"" + searchString + "\"";
                return View(await _repo.Search(searchString));

            }
            if(!string.IsNullOrWhiteSpace(typeName))
            {
                ViewBag.Title = "Articles in " + typeName;
                return View("Index", await _repo.GetListBy(b => b.TypeName == typeName));
            }
            if(!string.IsNullOrWhiteSpace(tagName))
            {
                ViewBag.Title = "Articles in " + tagName;
                return View("Index", await _repo.GetByTag(tagName));
            }
            ViewBag.Title = "All articles";
            return View(await _repo.GetAll());
        }

        //[AllowAnonymous]
        //// GET: Blogs
        //public async Task<IActionResult> GetByType(string typeName)
        //{
        //    ViewBag.Title = "Articles in " + typeName;
        //    return View("Index", await _repo.GetListBy(b => b.TypeName == typeName));
        //}

        //[AllowAnonymous]
        //// GET: Blogs
        //public async Task<IActionResult> GetByTag(string tagName)
        //{
        //    ViewBag.Title = "Articles in " + tagName;
        //    return View("Index", await _repo.GetByTag(tagName));
        //}

        [AllowAnonymous]
        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var blog = await _repo.GetBlogDetail(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
        // GET: Blogs/Create
        public IActionResult Create()
        {
            ViewBag.BlogTypes = new SelectList(new BlogTypeRepo(_context).GetAll().Result, "TypeName", "TypeDesc");
            ViewBag.Tags = "";
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Blog,Tags,Blog.Summary,Blog.Title,Blog.Content,Blog.TypeName")] BlogDetailDTO blogDetail)
        {
            blogDetail.Blog.Id = Guid.NewGuid().ToString();
            blogDetail.Blog.CreateTime = DateTime.Now;
            blogDetail.Blog.ModifyTime = DateTime.Now;
            blogDetail.Blog.LikeCount = 0;
            blogDetail.Blog.ReadCount = 0;
            blogDetail.Blog.PostUserId = _userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                await _repo.Add(blogDetail.Blog);
                if (!string.IsNullOrEmpty(blogDetail.Tags))
                {
                    var tags = blogDetail.Tags.Split(new char[] { ',' });
                    TagsRepo tagsRepo = new TagsRepo(_context);
                    BlogTagRepo blogTagRepo = new BlogTagRepo(_context);
                    foreach (var item in tags)
                    {
                        if (await tagsRepo.GetByKey(item.Trim()) == null)
                        {
                            await tagsRepo.Add(new Tag(item.Trim()));
                        }
                        BlogTag bt = new BlogTag(blogDetail.Blog.Id, item.Trim());
                        await blogTagRepo.Add(bt);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blogDetail);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var blogDetail = await _repo.GetBlogDetail(id);
            var blogtypes = await new BlogTypeRepo(_context).GetAll();
            ViewBag.BlogTypes = new SelectList(blogtypes, "TypeName", "TypeDesc", blogDetail.Blog.BlogType);
            if (blogDetail == null)
            {
                return NotFound();
            }
            return View(blogDetail);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Blog,Tags,Blog.Id,Blog.LikeCount,Blog.PostUserId,Blog.ReadCount,Blog.Summary,Blog.Title,Blog.Content,Blog.TypeName")] BlogDetailDTO blogDetail)
        {
            if (id != blogDetail.Blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Edit(blogDetail.Blog);
                    if (!string.IsNullOrEmpty(blogDetail.Tags))
                    {
                        var tags = blogDetail.Tags.Split(new char[] { ',' });
                        TagsRepo tagsRepo = new TagsRepo(_context);
                        BlogTagRepo blogTagRepo = new BlogTagRepo(_context);
                        var query = from bt in _context.BlogTags where bt.BlogId ==id select bt;
                       
                        await blogTagRepo.DeleteBySQL("delete from blogtags where blogid='" + id+"'");
                        foreach (var item in tags)
                        {
                            if (await tagsRepo.GetByKey(item.Trim()) == null)
                            {
                                await tagsRepo.Add(new Tag(item.Trim()));
                            }
                            BlogTag bt = new BlogTag(blogDetail.Blog.Id, item.Trim());
                            await blogTagRepo.Add(bt);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blogDetail.Blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PostUserId"] = new SelectList(_context.Users, "Id", "Id", blogDetail.Blog.PostUserId);
            return View(blogDetail);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var blog = await _context.Blogs.SingleOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogExists(string id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }

    }
}
