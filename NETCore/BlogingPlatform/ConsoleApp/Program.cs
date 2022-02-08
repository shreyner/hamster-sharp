// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;

var fileName = "Blog.txt";
var rangeLoadingPosts = (start: 5, end: 13);
using var blogPostsHttpClient = new HttpClient();
var baseHost = new Uri("https://jsonplaceholder.typicode.com/");
var pathPost = new Uri(baseHost, "posts/5");
blogPostsHttpClient.BaseAddress = pathPost;
CancellationTokenSource cancellationToken = new CancellationTokenSource(5000);

Console.WriteLine("Loading Posts ...");

var responses =
    await Task.WhenAll(
        Enumerable
            .Range(rangeLoadingPosts.start, rangeLoadingPosts.end)
            .Select(
                postId => blogPostsHttpClient.GetFromJsonAsync<Post>(postId.ToString(), cancellationToken.Token)
            )
    );

var result = string.Join("\n\n", responses
    .Select(
        (post) => string.Join(
                "\n",
                new List<string> { post.UserId.ToString(), post.Id.ToString(), post.Title, post.Body }
            )
    )
);

Console.WriteLine("Writing Posts to file {0}", fileName);
await File.WriteAllTextAsync($"./{fileName}", result);

class Post
{
    public int Id { get; }
    public int UserId { get; }
    public string Title { get; }
    public string Body { get; }

    public Post(int id, int userId, string title, string body)
    {
        this.Id = id;
        this.UserId = userId;
        this.Title = title;
        this.Body = body;
    }

    public override string ToString()
    {
        return $"Id: {Id}, userId: {UserId}, title: {Title}, body: {Body}";
    }
}