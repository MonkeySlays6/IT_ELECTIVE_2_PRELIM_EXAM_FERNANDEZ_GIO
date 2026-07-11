using IT_ELECTIVE_2_PRELIM_EXAM.Models;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Services;

// EXERCISE 5: Constructor Chaining
// RecipeBook has one constructor. Your task:
// - Add a second constructor that accepts only (string name)
// - That constructor should chain to the existing 2-parameter constructor
//   using ': this(name, 10)' as the default capacity
//
// EXERCISE 6: Method Overloads
// The Search(string term) method searches by name only.
// Your task:
// - Add an overload: Search(string term, string category)
//   that filters by both name AND category
// - Add an overload: Search(int maxPrepTime)
//   that returns all meals with PrepTimeMinutes <= maxPrepTime

public class RecipeBook
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    private List<Meal> meals;

    public RecipeBook(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        meals = new List<Meal>();
    }

    // EXERCISE 5: Add constructor that accepts only (string name)
    // and chains to the above with default capacity 10
    // Currently this stub doesn't chain - fix it!
    public RecipeBook(string name) : this(name, 10)
    {
    }

    public void AddMeal(Meal meal)
    {
        if (meals.Count < Capacity)
        {
            meals.Add(meal);
        }
    }

    public List<Meal> Search(string term)
    {
        return meals.Where(m =>
            m.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // EXERCISE 6: Add overload Search(string term, string category)
    // Currently this stub returns empty - fix it!
    public List<Meal> Search(string term, string category)
    {
        return meals.Where(m =>
            m.Name.Contains(term, StringComparison.OrdinalIgnoreCase) &&
            m.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // EXERCISE 6: Add overload Search(int maxPrepTime)
    // Currently this stub returns empty - fix it!
    public List<Meal> Search(int maxPrepTime)
    {
        return meals.Where(m => m.PrepTimeMinutes <= maxPrepTime).ToList();
    }

    public int GetMealCount()
    {
        return meals.Count;
    }

    public List<Meal> GetAllMeals()
    {
        return new List<Meal>(meals);
    }
}
