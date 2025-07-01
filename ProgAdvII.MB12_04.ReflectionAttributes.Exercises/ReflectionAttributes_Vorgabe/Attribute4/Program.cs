using System;
using System.Collections.Generic;
using System.Reflection;

namespace Attribute4 {



    public class Test {

        static void Main() {

        }
    }
    
    public class AbbreviationAttribute : Attribute
    {
        public AbbreviationAttribute(string abbreviation)
        {
            
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        [Abbreviation("+ListIngredients()")]
        public void ListIngredients()
        {
            foreach(var ingredient in Ingredients)
            {
                Console.WriteLine($"You need {ingredient.Amount.Amount} {ingredient.Amount.MeasuringUnit} of {ingredient.FoodItem.Name}");
            }
            DunnoMan("");
        }
        [Abbreviation("-DunnoMan(name)")]
        private void DunnoMan(string name)
        {

        }
    }
    public class Ingredient {
        public FoodItem FoodItem { get; set; }
        public IngredientAmount Amount { get; set; }
    }
    public class IngredientAmount
    {
        public float Amount { get; set; }
        public string MeasuringUnit { get; set; }
    }
    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
}