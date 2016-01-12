using ProjectPrioritizationApp.Models;
using ProjectPrioritizationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectPrioritizationApp.Controllers
{
    public partial class scoresController : Controller
    {
        private ppaContext db = new ppaContext();

        // GET: score
        public virtual ActionResult Index()
        {
            ViewBag.Criteria = db.criteria
                .OrderBy(s => s.CriterionName)
                .ToList();

            var scoreViewModel = new List<ScoreViewModel>();

            var projects = db.projects.ToList();

            foreach (var project in projects)
            {
                float total = 0;
                foreach (var score in project.scores)
                {
                    total += score.Rate * score.criterion.Weight;
                }

                var model = new ScoreViewModel
                {
                    HasBRD = project.HasBRD,
                    ProjectDescription = project.Description,
                    ProjectId = project.Id,
                    ProjectName = project.ProjectName,
                    Score = total
                };

                scoreViewModel.Add(model);
            }

            var viewModel = scoreViewModel.OrderByDescending(s => s.HasBRD)
                .ThenByDescending(s => s.Score).ToList();

            return View(viewModel);
        }

        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            project project = db.projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            var criteria = db.criteria.OrderBy(s => s.CriterionName).ToList();

            ViewBag.Criteria = db.criteria
                .OrderBy(s => s.CriterionName)
                .ToList();

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(project model)
        {
            if (ModelState.IsValid)
            {
                var scores = db.scores
                    .Where(s => s.ProjectId == model.Id)
                    .ToList();
                db.scores.RemoveRange(scores);
                db.scores.AddRange(model.scores);

                model.scores = null;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}