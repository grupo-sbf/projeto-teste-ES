using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using teste.Models;

namespace teste.Controllers
{
    public class EnderecoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Enderecoes
        public ActionResult Index()
        {
            ViewBag.Title = "Endereço";
            var enderecoes = db.GetEnderecoes.Include(e => e.pessoa);
            return View(enderecoes.ToList());
        }

        // GET: Enderecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.GetEnderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecoes/Create
        public ActionResult Create(int Id)
        {
            var pessoa = db.Pessoas.ToList().Where(p => p.id == Id);
            ViewBag.pessoaId = new SelectList(pessoa, "Id", "nome");
            return View();
        }

        // POST: Enderecoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bairro,logradouro,numero,pessoaId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                Pessoa pessoa = new Pessoa();

                db.GetEnderecoes.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pessoaId = new SelectList(db.Pessoas, "id", "nome", endereco.pessoaId);
            return RedirectToAction("Index");
        }

        // GET: Enderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.GetEnderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.pessoaId = new SelectList(db.Pessoas, "id", "nome", endereco.pessoaId);
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bairro,logradouro,numero,pessoaId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pessoaId = new SelectList(db.Pessoas, "id", "nome", endereco.pessoaId);
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.GetEnderecoes.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.GetEnderecoes.Find(id);
            db.GetEnderecoes.Remove(endereco);
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
