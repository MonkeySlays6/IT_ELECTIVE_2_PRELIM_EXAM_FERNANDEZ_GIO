namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 1: Encapsulation - Private Fields
// The fields below are public. Your task:
// - Make all fields PRIVATE
// - Create public Properties with getters and setters
// - The property names should match the field names (PascalCase)
//
// Currently, the properties below are STUBS that return wrong values.
// Fix them to properly wrap the private fields.

public class Meal
{
    private string name;
    private string category;
    private string area;
    private string instructions;
    private string thumbnail;
    private string tags;

    // EXERCISE 1: Fix these stub properties to properly get/set from private fields
    // After fixing, make the fields above PRIVATE
    public string Name { get => name; set => name = value; }
    public string Category { get => category; set => category = value; }
    public string Area { get => area; set => area = value; }

    public Meal()
    {
        name = "";
        category = "";
        area = "";
        instructions = "";
        thumbnail = "";
        tags = "";
    }

    public Meal(string name, string category, string area)
    {
        this.name = name;
        this.category = category;
        this.area = area;
        this.instructions = "";
        this.thumbnail = "";
        this.tags = "";
    }

    public override string ToString()
    {
        return $"Meal: {Name} | Category: {Category} | Area: {Area}";
    }
}
