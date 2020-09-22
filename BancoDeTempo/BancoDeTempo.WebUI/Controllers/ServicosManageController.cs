using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BancoDeTempo.Core.Models;
using BancoDeTempo.DataAccess.InMemories;
using BancoDeTempo.Core.ViewModels;

namespace BancoDeTempo.WebUI.Controllers
{
    public class ServicosManageController : Controller
    {
        ServicosRepositorio context;
        CategoriaServicoRepositorio servicoscategories;


        public ServicosManageController()
        {
            context = new ServicosRepositorio();
            servicoscategories = new CategoriaServicoRepositorio();
        }

        // GET: ServicosManage
        public ActionResult Index()
        {
            List<Servicos> servicos = context.Collection().ToList();
            return View(servicos);
        }

        public ActionResult Create()
        {
            ServicosManagerViewModel viewmodel = new ServicosManagerViewModel();

            viewmodel.Servicos = new Servicos();
            viewmodel.Servicoscategories = servicoscategories.Collection();
           
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Servicos servicos)
        {
            if (!ModelState.IsValid)
            {
                return View(servicos);
            }
            else
            {
                context.Insert(servicos);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Servicos servicos = context.Find(Id);

            if(servicos == null)
            {
                return HttpNotFound();
            }
            else {
                ServicosManagerViewModel viewModel = new ServicosManagerViewModel();
                viewModel.Servicos = servicos;
                viewModel.Servicoscategories = servicoscategories.Collection();
                return View(viewModel);
            }
           
        }

        [HttpPost]
        public ActionResult Edit(Servicos servicos, string Id)
        {
            Servicos servicosToEdit = context.Find(Id);

            if (servicosToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(servicos);
                }

                servicosToEdit.titulo = servicos.titulo;
                servicosToEdit.Descrisao = servicos.Descrisao;
                servicosToEdit.Imagem = servicos.Imagem;
                servicosToEdit.Duracao = servicos.Duracao;
                servicosToEdit.Linguagem_partilha = servicos.Linguagem_partilha;
                servicosToEdit.Experiencia_assunto = servicos.Experiencia_assunto;
                servicosToEdit.Condicao_acesso = servicos.Condicao_acesso;
                servicosToEdit.Category = servicos.Category;

                context.Commit();

                return RedirectToAction("Index");
            }
            

        }

        public ActionResult Delete(string Id)
        {
            Servicos servicosToDelete = context.Find(Id);

            if (servicosToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(servicosToDelete);
            }
       }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Servicos servicosToDelete = context.Find(Id);

            if (servicosToDelete == null)
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