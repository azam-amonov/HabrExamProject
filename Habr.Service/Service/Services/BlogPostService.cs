using System.Linq.Expressions;
using Habr.Service.DataAccses.Constans;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Service.Extentions;
using Habr.Service.Service.Interfaces;

namespace Habr.Service.Service.Services;

public class BlogPostService : IBlogPostService
{
    private readonly string _blogPostDataPath = Constant.PostDataFile;
    
    public BlogPostService()
    {
        var source = File.ReadAllTextAsync(_blogPostDataPath);
        if(string.IsNullOrEmpty(source.ToString()));
            File.WriteAllTextAsync(_blogPostDataPath, "[]");
    }
    
    public IQueryable<BlogPost> GetAsync(Expression<Func<BlogPost>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<BlogPost> CreateAsync(BlogPost blogPost)
    {
        var blogPosts = await _blogPostDataPath.ReadJsonFromFileAsync<List<BlogPost>>();
        
        blogPosts.Add(blogPost);
        await blogPosts.WriteToFileFromJsonAsync(_blogPostDataPath);
        
        return blogPost;
    }

    public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
    {
        var blogPosts = await _blogPostDataPath.ReadJsonFromFileAsync<List<BlogPost>>();
        var blogPostToUpdate = blogPosts.FirstOrDefault(p => p.Id == blogPost.Id);
        
        if(blogPostToUpdate is null)
            throw new ArgumentNullException(nameof(blogPostToUpdate), "This article is not published!");

        blogPostToUpdate.Title = blogPost.Title;
        blogPostToUpdate.Content = blogPost.Content;
        blogPostToUpdate.UpdatedTime = DateTime.Now;

        await blogPosts.WriteToFileFromJsonAsync(_blogPostDataPath);
        return blogPost;
    }

    public async Task<BlogPost> DeleteAsync(BlogPost blogPost)
    {
        var blogPosts = await _blogPostDataPath.ReadJsonFromFileAsync<List<BlogPost>>();
        var blogPostToDelete = blogPosts.FirstOrDefault(p => p.Id == blogPost.Id);
        
        if(blogPostToDelete is null)
            throw new ArgumentNullException(nameof(blogPostToDelete), "This article is not published!");
        
        blogPosts.Remove(blogPostToDelete);
        await blogPosts.WriteToFileFromJsonAsync(_blogPostDataPath);
        return blogPostToDelete;
    }

    public async Task<BlogPost> GetByIdAsync(int id)
    {
        var blogPosts = await _blogPostDataPath.ReadJsonFromFileAsync<List<BlogPost>>();
        var existingBlogPost = blogPosts.FirstOrDefault(p => p.Id == id);
        
        if(existingBlogPost is null)
            throw new ArgumentNullException(nameof(existingBlogPost), "This article is not published!");

        return existingBlogPost;
    }

    public async Task<List<BlogPost>> GetByUserIdAsync(int id) 
    {
        var blogPosts = await _blogPostDataPath.ReadJsonFromFileAsync<List<BlogPost>>();
        var userPosts = blogPosts.Any(p => p.UserId == id);

        if (!userPosts)
            throw new ArgumentException("The is no any blog post by this user id");

        return blogPosts.Where(p => p.UserId == id).ToList();
    }

    public async Task<List<BlogPost>> GetAllAsync()
    {
        var blogPosts = await _blogPostDataPath.ReadJsonFromFileAsync<List<BlogPost>>();
        
        if (blogPosts.Count == 0)
            throw new ArgumentException("The is no any blog post");
        
        return blogPosts;
    }
}