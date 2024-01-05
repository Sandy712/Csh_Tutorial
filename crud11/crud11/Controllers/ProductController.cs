using crud11.DAL;
using crud11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud11.Controllers
{
    public class ProductController : Controller
    {
        Product_DAL _prod = new Product_DAL();


        // GET: Product
        public ActionResult Index()
        {
            var productList = _prod.GetAllProducts();

            if (productList.Count == 0)
            {
                TempData["infomessage"] = "Currently products not avaiable in the database";
            }

            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var product = _prod.GetAllProductByID(id).FirstOrDefault();

                if (product == null)
                {
                    TempData["infomessage"] = "product not available" + id.ToString();
                    return RedirectToAction("Index");

                }
                return View(product);
            }
            catch (Exception ex)
            {

                TempData["Errormessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            bool IsInserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = _prod.InsertProduct(product);

                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Product details saved successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the product details";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message; return View();
            }

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var products = _prod.GetAllProductByID(id).FirstOrDefault();

            if (products == null)
            {
                TempData["infomessage"] = "Product not availabl with id" + id.ToString();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // POST: Product/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool Isupdated = _prod.UpdateProduct(product);

                    if (Isupdated)
                    {
                        TempData["SuccessMessage"] = "Product details updated successfully..!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to update the product details";

                    }
                }
                return RedirectToAction("Index");

                // TODO: Add update logic here
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var product = _prod.GetAllProductByID(id).FirstOrDefault();

                if (product == null)
                {
                    TempData["infomessage"] = "Product not availabl with id" + id.ToString();

                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                string result = _prod.DeleteProduct(id);

                if (result.Contains("deleted"))
                {
                    TempData["SuccessMeassage"] = result;
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}