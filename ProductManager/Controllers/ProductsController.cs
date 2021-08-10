
using ControllerContracts;
using ControllerContracts.DTO;
using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
    public class ProductsController:Controller
    {
        private IProductController _controller;
        private ICategoryController _controllerCategory;

        public ProductsController(IProductController controller, ICategoryController controllerCategory)
        {
            this._controller = controller;
            this._controllerCategory = controllerCategory;
        }

        // GET: Products
        public ActionResult Index()
        {
            ProductViewMapper mapper = new ProductViewMapper();
            var productList = mapper.MapperT2T1(_controller.getProductList());
            return View(productList);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewMapper mapper = new ProductViewMapper();
            ProductModel product = mapper.MapperT2T1(_controller.getProductById(id.Value));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            this.getCategoryListToSelect();
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Stock,Price,Photo,CategoryId")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                ProductViewMapper mapper = new ProductViewMapper();
                ProductDTO dto = mapper.MapperT1T2(product);
                bool saved = _controller.saveProduct(dto);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }

        private void getCategoryListToSelect()
        {
            ViewBag.CategoryId = new SelectList(_controllerCategory.getCategoryList(), "Id", "Name");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewMapper mapper = new ProductViewMapper();
            ProductModel product = mapper.MapperT2T1(_controller.getProductById(id.Value));
            if (product == null)
            {
                return HttpNotFound();
            }
            this.getCategoryListToSelect();
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Stock,Price,Photo,CategoryId")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                ProductViewMapper mapper = new ProductViewMapper();
                ProductDTO dto = mapper.MapperT1T2(product);
                bool saved = _controller.editProduct(dto);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
            }
            this.getCategoryListToSelect();
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewMapper mapper = new ProductViewMapper();
            ProductModel product = mapper.MapperT2T1(_controller.getProductById(id.Value));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool removed = _controller.deleteProduct(id);
            if (!removed)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
