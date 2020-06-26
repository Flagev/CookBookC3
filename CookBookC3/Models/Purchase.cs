﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class Purchase
    {
        public List<PurchasePosition> Positions = new List<PurchasePosition>();

        public virtual void AddItem(IngredientUIO ingredient, int quantity)
        {
            PurchasePosition ingredientPosition = Positions
                .Where(x => x.Ingredient.Name == ingredient.Name)
                .FirstOrDefault();
            
            if (ingredientPosition == null)
            {
                Positions.Add(new PurchasePosition
                {
                    Ingredient = ingredient,
                    Quantity = quantity
                });
            }
            else
            {
                ingredientPosition.Quantity += quantity;
            }
        }

        public virtual void RemovePosition(IngredientUIO selectedIngredient) =>
            Positions.RemoveAll(l => l.Ingredient.Name ==
                selectedIngredient.Name);

        public virtual decimal ComputeTotalValue() =>
            Positions.Sum(x => x.Ingredient.Cost * x.Quantity);

        public virtual void Clear() => Positions.Clear();

    }


}
