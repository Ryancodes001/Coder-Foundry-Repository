using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coder_Foundry_Portfolio.Models;
using Coder_Foundry_Portfolio.Models.CodeFirst;
using System.Net;

namespace Coder_Foundry_Portfolio.Controllers
{
    [RequireHttps]
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Author).Include(c => c.Post);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int? id)
        {
            //ViewBag.AuthorId = new SelectList(db.ApplicationUser, "Id", "FirstName");
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            ViewBag.PostId = id;
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, PostId, Body")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                var postid = db.blogPosts.FirstOrDefault(p => p.Id == comment.PostId);
                return RedirectToAction("Details", "BlogPosts", new { slug = postid.Slug }); //This code connects the comment back to the post its commenting//
            }

            //ViewBag.AuthorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.AuthorId);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AuthorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.AuthorId);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,Body")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                var postid = db.blogPosts.FirstOrDefault(p => p.Id == comment.PostId);
                return RedirectToAction("Details", "BlogPosts", new { slug = postid.Slug });
            }
            //ViewBag.AuthorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", comment.AuthorId);
            //ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Roles = "Admin")]  //One of these authorize roles causes the login after delete attempt to break//
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            BlogPost post = db.blogPosts.Find(comment.PostId);
            db.Comments.Remove(comment);
            db.SaveChanges();
            //return RedirectToAction("Index", "BlogPosts");
            return RedirectToAction("Details", "BlogPosts", new { slug = post.Slug }); //change the path of the delete button//
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
