using IT_ELECTIVE_2_PRELIM_EXAM.Interfaces;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 7: Inheritance - Derived Class
// MealRecipe inherits from RecipeBase. Your task:
// - Make sure Category and Area properties properly store values
// - Create constructors that call the base constructor using ': base(...)'
// - Override GetRecipeInfo() to include Category and Area
//
// EXERCISE 9: Interfaces
// MealRecipe should also implement IRecipeSearchable (see Interfaces/)
// - Uncomment ", IRecipeSearchable" from the class declaration
// - Implement the SearchCriteria property (return the Title)
// - Implement the MatchesSearch(string searchTerm) method (check if searchTerm is in Title, case-insensitive)

public class MealRecipe : RecipeBase, IRecipeSearchable
{
    // EXERCISE 7: These properties need to be wired up properly
    // Currently they're stubs that don't store values correctly
    public string Category { get; set; } = "";
    public string Area { get; set; } = "";

    public MealRecipe() : base()
    {
    }

    public MealRecipe(string title, int prepTime, string difficulty)
    : base(title, prepTime, difficulty)
    {
    }

    // EXERCISE 7: Create a constructor that also accepts category and area
    // and chains to the base constructor: base(title, prepTime, difficulty)
    public MealRecipe(string title, int prepTime, string difficulty, string category, string area)
    : base(title, prepTime, difficulty)
    {
        Category = category;
        Area = area;
    }
    public override string GetRecipeInfo()
    {
        // EXERCISE 7: Override to include Category and Area in the output
        return $"{base.GetRecipeInfo()} | Category: {Category} | Area: {Area}";
    }

    // EXERCISE 9: Implement IRecipeSearchable interface methods here
    public string SearchCriteria => Title;

    public bool MatchesSearch(string searchTerm)
    {
        return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }
}
