// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;

var fileName = "Blog.txt";
var rangeLoadingPosts = (start: 5, end: 13);
var blogPostsHttpClient = new HttpClient();
var baseHost = new Uri("https://jsonplaceholder.typicode.com/");
var pathPost = new Uri(baseHost, "posts/5");
blogPostsHttpClient.BaseAddress = pathPost;

Console.WriteLine("Loading Posts ...");

var responses =
    await Task.WhenAll(
        Enumerable
            .Range(rangeLoadingPosts.start, rangeLoadingPosts.end)
            .Select(
                postId => blogPostsHttpClient.GetFromJsonAsync<Post>(postId.ToString())
            )
    );

var result = string.Join("\n\n", responses
    .Select(
        (post) => string.Join(
                "\n",
                new List<string> { post.userId.ToString(), post.id.ToString(), post.title, post.body }
            )
    )
);

Console.WriteLine("Writing Posts to file {0}", fileName);
await File.WriteAllTextAsync($"./{fileName}", result);

class Post
{
    public int id { get; }
    public int userId { get; }
    public string title { get; }
    public string body { get; }

    public Post(int id, int userId, string title, string body)
    {
        this.id = id;
        this.userId = userId;
        this.title = title;
        this.body = body;
    }

    public override string ToString()
    {
        return $"Id: {id}, userId: {userId}, title: {title}, body: {body}";
    }
}