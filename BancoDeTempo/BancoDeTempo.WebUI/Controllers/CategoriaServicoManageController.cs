using BancoDeTempo.Core.Models;
using BancoDeTempo.DataAccess.InMemories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoDeTempo.WebUI.Controllers
{
    public class CategoriaServicoManageController : Controller
    {
        CategoriaServicoRepositorio context;

        public CategoriaServicoManageController()
        {
            context = new CategoriaServicoRepositorio();
        }
        // GET: ServicosManage
        public ActionResult Index()
        {
            List<CategoriaServico> servicoscategories = context.Collection().ToList();
            return View(servicoscategories);
        }

        public ActionResult Create()
        {
            CategoriaServico servicoscategories = new CategoriaServico();
            return View(servicoscategories);
        }

        [HttpPost]
        public ActionResult Create(CategoriaServico servicoscategories)
        {
            if (!ModelState.IsValid)
            {
                return View(servicoscategories);
            }
            else
            {
                context.Insert(servicoscategories);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            CategoriaServico servicoscategories = context.Find(Id);

            if (servicoscategories == null)
            {
                return HttpNotFound();
            }
            else {
                return View(servicoscategories);
            }

        }

        [HttpPost]
        public ActionResult Edit(CategoriaServico servicoscategories, string Id)
        {
            CategoriaServico servicoscategoriesToEdit = context.Find(Id);

            if (servicoscategoriesToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(servicoscategories);
                }

                servicoscategoriesToEdit.Category = servicoscategories.Category;

                context.Commit();

                return RedirectToAction("Index");
            }


        }

        public ActionResult Delete(string Id)
        {
            CategoriaServico servicoscategoriesToDelete = context.Find(Id);

            if (servicoscategoriesToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(servicoscategoriesToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            CategoriaServico servicoscategoriesToDelete = context.Find(Id);

            if (servicoscategoriesToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}