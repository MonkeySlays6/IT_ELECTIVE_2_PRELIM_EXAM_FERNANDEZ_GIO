using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts
//
// Your task:
// 1. Create a JSON body string: { "title": "Great Pasta!", "body": "Loved this recipe", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a POST request to the URL
// 4. Assert status code is 201 Created
// 5. Parse the response JSON and assert it contains an "id" field
//
// Hint: Use await client.PostAsync(url, content)
// Hint: Use new StringContent(json, Encoding.UTF8, "application/json")

public static class CreateReview
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";

        string json = @"{
            ""title"": ""Great Pasta!"",
            ""body"": ""Loved this recipe"",
            ""userId"": 1
        }";

        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(url, content);

        if (response.StatusCode != HttpStatusCode.Created)
        {
            throw new Exception($"Expected status code 201 Created, but got {response.StatusCode}");
        }

        string responseBody = await response.Content.ReadAsStringAsync();

        using JsonDocument document = JsonDocument.Parse(responseBody);

        if (!document.RootElement.TryGetProperty("id", out JsonElement id) ||
            id.ValueKind == JsonValueKind.Null)
        {
            throw new Exception("Response does not contain a valid 'id' field.");
        }
    }
}