using System.Net;
using System.Text.Json;
namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://themealdb.com/api/json/v1/1/categories.php
//
// Your task:
// 1. Use the HttpClient to fetch all meal categories
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "categories" array has more than 0 items
//
// Response format: { "categories": [{ "strCategory": "Beef", ... }, ...] }
public static class GetCategories
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/categories.php";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK, but got {response.StatusCode}");
        }


        string responseBody = await response.Content.ReadAsStringAsync();


        JsonDocument document = JsonDocument.Parse(responseBody);


        JsonElement categories = document.RootElement.GetProperty("categories");

        if (categories.GetArrayLength() <= 0)
        {
            throw new Exception("Expected one or more categories, but none were found.");
        }
    }
}
