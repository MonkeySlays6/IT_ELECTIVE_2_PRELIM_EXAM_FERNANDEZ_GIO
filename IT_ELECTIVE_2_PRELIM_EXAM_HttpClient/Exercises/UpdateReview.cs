using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 7: PUT Update Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
//
// Your task:
// 1. Create a JSON body: { "id": 1, "title": "Updated Review", "body": "Even better than before!", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a PUT request to update post with ID 1
// 4. Assert status code is 200 OK
// 5. Parse the response JSON and assert the title is "Updated Review"
//
// Hint: Use await client.PutAsync(url, content)

public static class UpdateReview
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        string json = @"{
            ""id"": 1,
            ""title"": ""Updated Review"",
            ""body"": ""Even better than before!"",
            ""userId"": 1
        }";

        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PutAsync(url, content);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK, but got {response.StatusCode}");
        }

        string responseBody = await response.Content.ReadAsStringAsync();

        using JsonDocument document = JsonDocument.Parse(responseBody);

        string? title = document.RootElement.GetProperty("title").GetString();

        if (title != "Updated Review")
        {
            throw new Exception($"Expected title 'Updated Review', but got '{title}'.");
        }
    }
}
