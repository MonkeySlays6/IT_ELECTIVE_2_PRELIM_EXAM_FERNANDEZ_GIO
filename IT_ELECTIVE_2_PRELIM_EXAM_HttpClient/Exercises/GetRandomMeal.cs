using System.Net;
namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 1: GET Random Meal
// TheMealDB API: https://themealdb.com/api/json/v1/1/random.php
//
// Your task:
// 1. Use the HttpClient to send a GET request to the URL above
 // 2. Read the response as a string
// 3. Assert that the status code is 200 OK
// 4. Assert that the response body is not null or empty
//
// Hint: Use await client.GetAsync(url) then check response.StatusCode
// Hint: Use await response.Content.ReadAsStringAsync() to get the body

public static class GetRandomMeal
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/random.php";

        HttpResponseMessage response = await client.GetAsync(url);

        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK, but got {response.StatusCode}");
        }

        if (string.IsNullOrEmpty(responseBody))
        {
            throw new Exception("Response body is null or empty");
        }
    }
}
