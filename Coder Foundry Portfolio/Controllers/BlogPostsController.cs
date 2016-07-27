using Coder_Foundry_Portfolio.Models;
using Coder_Foundry_Portfolio.Models.CodeFirst;
using PagedList;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
namespace Coder_Foundry_Portfolio.Controllers
{
    public class BlogPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogPosts
        //[Authorize]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(db.blogPosts.OrderByDescending(p => p.Created).ToPagedList(pageNumber, pageSize )); /*this is where to order the appearence of blog entries in order*/
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost post = db.blogPosts.FirstOrDefault(p => p.Slug == Slug);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
    

        // GET: BlogPosts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created,Updated,Title,Slug,Body,MediaURL,Published")] BlogPost blogPosts, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                //check the file name to make sure its an image
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format.");
            }
            {
                if (ModelState.IsValid)
                {
                    var Slug = StringUtilities.URLFriendly(blogPosts.Title);
                    if(String.IsNullOrWhiteSpace(Slug))
                    {
                          ModelState.AddModelError("Title", "Invalid title.");
                        return View(blogPosts);
                    }

                    if (db.blogPosts.Any(p => p.Slug == Slug))
                    {
                        ModelState.AddModelError("Title", "The title must be unique.");
                        return View(blogPosts);
                    }


                    if (image != null)
                                            {
                        //relative server path
                        var filePath = "/Uploads/";
                        // path on physical drive on server
                        var absPath = Server.MapPath("~" + filePath);
                        // media url for relative path
                        blogPosts.MediaURL = filePath + image.FileName;
                        //save image
                        image.SaveAs(Path.Combine(absPath, image.FileName));
                    }

                    blogPosts.Slug = Slug;
                    blogPosts.Created = DateTimeOffset.Now;
                    db.blogPosts.Add(blogPosts);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            
               return View(blogPosts);
        }

        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.blogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Updated,Title,Slug,Body,MediaURL,Published")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                var Slug = StringUtilities.URLFriendly(blogPost.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(blogPost);
                }

                if (db.blogPosts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(blogPost);
                }

                blogPost.Slug = Slug;
                blogPost.Updated = DateTimeOffset.Now;
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.blogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.blogPosts.Find(id);
            db.blogPosts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
