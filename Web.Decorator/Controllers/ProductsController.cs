﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaseProject.Models;
using Web.Decorator.Models;
using Web.Decorator.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Web.Decorator.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductRepostiory _productRepostiory;

        public ProductsController(IProductRepostiory productRepostiory)
        {
            _productRepostiory = productRepostiory;
        }



        // GET: Products
        public async Task<IActionResult> Index()
        {

            var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

              return View( await _productRepostiory.GetAll(userId));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null  )
            {
                return NotFound();
            }

            var product = await _productRepostiory.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Stock")] Product product)
        {
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                product.UserId = userId;
              await _productRepostiory.Save(product);
            
                
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepostiory.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock,UserId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await _productRepostiory.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepostiory.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var product = await _productRepostiory.GetById(id);

            if (product != null)
            {

                await _productRepostiory.Delete(product);
            }
            
        
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _productRepostiory.GetById(id) != null;
        }
    }
}
