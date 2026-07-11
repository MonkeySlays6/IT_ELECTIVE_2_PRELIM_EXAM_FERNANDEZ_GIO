using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".
//
// Your task:
// 1. Use the HttpClient to fetch meals starting with letter "a"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and get the "meals" array
// 4. Assert the array has more than 0 items
// 5. Loop through each meal and print its name (strMeal)
//
// Response format:
// {
//   "meals": [
//     { "idMeal": "52772", "strMeal": "Arrabiata", ... },
//     { "idMeal": "52781", "strMeal": "Ayam Percik", ... },
//     ...
//   ]
// }

public static class DeserializeMeals
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK, but got {response.StatusCode}");
        }

        string responseBody = await response.Content.ReadAsStringAsync();

        using JsonDocument document = JsonDocument.Parse(responseBody);

        JsonElement meals = document.RootElement.GetProperty("meals");

        if (meals.ValueKind == JsonValueKind.Null || meals.GetArrayLength() <= 0)
        {
            throw new Exception("Expected one or more meals, but none were found.");
        }

        foreach (JsonElement meal in meals.EnumerateArray())
        {
            Console.WriteLine(meal.GetProperty("strMeal").GetString());
        }
    }
}