using IT_ELECTIVE_2_PRELIM_EXAM.Models;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Services;

// EXERCISE 10: Access Modifiers
// The Kitchen class currently has everything as 'public'.
// Your task: Fix the access modifiers to follow proper encapsulation:
//
// - 'kitchenName' should be private (internal detail)
// - 'headChef' should be private (internal detail)
// - 'mealCount' property should be public (read-only externally)
// - 'meals' list should be private (internal storage)
// - 'AddMeal()' should be public (external API)
// - 'GetMeals()' should be public (external API)
// - 'RemoveMeal()' should be public (external API)
// - 'GetKitchenInfo()' should be public (external API)
// - 'PrepareMeal()' should be protected (only for derived classes)

public class Kitchen
{
    private string kitchenName;
    private string headChef;
    public int mealCount { get; private set; }
    private List<Meal> meals;

    public Kitchen(string name, string chef)
    {
        kitchenName = name;
        headChef = chef;
        meals = new List<Meal>();
        mealCount = 0;
    }

    public void AddMeal(Meal meal)
    {
        meals.Add(meal);
        mealCount++;
    }

    public List<Meal> GetMeals()
    {
        return new List<Meal>(meals);
    }

    public bool RemoveMeal(string mealName)
    {
        var meal = meals.FirstOrDefault(m =>
            m.Name.Equals(mealName, StringComparison.OrdinalIgnoreCase));

        if (meal != null)
        {
            meals.Remove(meal);
            mealCount--;
            return true;
        }
        return false;
    }

    public string GetKitchenInfo()
    {
        return $"Kitchen: {kitchenName} | Chef: {headChef} | Meals: {mealCount}";
    }

    public string PrepareMeal(string mealName)
    {
        return $"Preparing {mealName} in {kitchenName}...";
    }
}
