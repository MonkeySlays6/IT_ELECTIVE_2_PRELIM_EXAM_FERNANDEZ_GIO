namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 8: Override vs New
// QuickRecipe inherits from RecipeBase. Your task:
// - The current code uses 'new' keyword to hide the base method
// - Change it to use 'override' keyword instead so proper polymorphism works
// - Add a 'MaxMinutes' property (int) that represents the max time for "quick" recipes
//
// Test: When calling GetRecipeInfo() on a RecipeBase reference
// pointing to a QuickRecipe object, it should call QuickRecipe's version (polymorphism)

public class QuickRecipe : RecipeBase
{
    public int MaxMinutes { get; set; }

    public QuickRecipe() : base()
    {
        MaxMinutes = 30;
    }

    public QuickRecipe(string title, int prepTime, string difficulty, int maxMinutes)
        : base(title, prepTime, difficulty)
    {
        MaxMinutes = maxMinutes;
    }

    // BUG: This uses 'new' instead of 'override' - fix this!
    public override string GetRecipeInfo()
    {
        return $"{base.GetRecipeInfo()} | Quick: Under {MaxMinutes} min";
    }
}
