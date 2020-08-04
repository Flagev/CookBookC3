﻿using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static CookBookASP.Converters.ModelConverter;


namespace CookBookASP.Controllers
{
    public class PurchaseController :  ControllerBase<PurchaseController>
    {
        private readonly RecipeProcessor recipeProcessor;
        private readonly SessionManager<Purchase> sessionManager;
        private readonly IngredientProcessor ingredientProcessor;
        Purchase purchase;

        public PurchaseController(IngredientProcessor ingredientProcessor, RecipeProcessor recipeProcessor,
            SessionManager<Purchase> sessionManager)
        {
            this.recipeProcessor = recipeProcessor;
            this.sessionManager = sessionManager;
            this.ingredientProcessor = ingredientProcessor;
        }

        public ViewResult Index()
        {
            return View(sessionManager.GetItem());
        }

        public ActionResult AddIngredient(int ingredientId)
        {
            var rawIngredient = ingredientProcessor.Get(ingredientId).DTOToViewModel(MapIngredient);
            IngredientWithCountVM ingredient = new IngredientWithCountVM()
            {
                Callories = rawIngredient.Callories,
                Cost = rawIngredient.Cost,
                Description = rawIngredient.Description,
                Id = rawIngredient.Id,
                Name = rawIngredient.Name,
                Unit = rawIngredient.Unit,
                Count = 1
            };

            AddIngredientsToSession(new List<IngredientWithCountVM>() { ingredient });
            return RedirectToAction(nameof(Index));
        }
        public ActionResult AddRecipe(int recipeId)
        {
            List<IngredientWithCountVM> Ingredients = recipeProcessor.GetIngredientsWithCount(recipeId).DTOToViewModelList(MapIngredientWithCount);
            AddIngredientsToSession(Ingredients);
            return RedirectToAction(nameof(Index));
        }
        void AddIngredientsToSession(List<IngredientWithCountVM> ingredients)
        {
            purchase = sessionManager.GetItem();
            foreach (IngredientWithCountVM ingredient in ingredients)
            {
                if (ingredient != null)
                {
                    purchase.AddItem(ingredient, ingredient.Count);
                    sessionManager.SetItem(purchase);
                }
            }
        }


        public RedirectToActionResult RemoveIngredient(int ingredientId)
        {
            IngredientVM Ingredient = ingredientProcessor.Get(ingredientId).DTOToViewModel(MapIngredient);

            if (Ingredient != null)
            {
                purchase = sessionManager.GetItem();
                purchase.RemovePosition(Ingredient);
                sessionManager.SetItem(purchase);
            }
            return RedirectToAction(nameof(Index));
        }
        public RedirectToActionResult RemoveAll()
        {
            sessionManager.SetItem(new Purchase());
            return RedirectToAction(nameof(Index));
        }
    } 
}
