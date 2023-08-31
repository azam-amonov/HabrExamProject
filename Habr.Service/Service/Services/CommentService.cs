using System.Linq.Expressions;
using Habr.Service.DataAccses.Constans;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Service.Extentions;
using Habr.Service.Service.Interfaces;

namespace Habr.Service.Service.Services;

public class CommentService : ICommentService
{
    private readonly string _commentDataPath = Constant.CommentDataFile;

    public CommentService()
    {
        var source = File.ReadAllTextAsync(_commentDataPath);
        if (string.IsNullOrEmpty(source.ToString()))
            File.WriteAllTextAsync(_commentDataPath, "[]");
    }
    
    public Task<IQueryable<Comment>> GetAsync(Expression<Func<Comment>> expression)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Comment> CreateAsync(Comment comment)
    {
        var comments = await _commentDataPath.ReadJsonFromFileAsync<List<Comment>>();

        comments.Add(comment);
        await comments.WriteToFileFromJsonAsync(_commentDataPath);

        return comment;
    }

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        var comments = await _commentDataPath.ReadJsonFromFileAsync<List<Comment>>();
        var commentToUpdate = comments.FirstOrDefault(c => c.Id == comment.Id);
        
        if(commentToUpdate is null)
            throw new ArgumentNullException( $"Comment with this {comment} is not available");
        
        commentToUpdate.Content = comment.Content;
        commentToUpdate.UpdatedTime = DateTime.Now;
        
        return commentToUpdate;
    }

    public async Task<Comment> DeleteAsync(int  id)
    {
        var comments = await _commentDataPath.ReadJsonFromFileAsync<List<Comment>>();
        var commentToDelete = comments.FirstOrDefault(c => c.Id == id);
        
        if (commentToDelete is null)
            throw new ArgumentNullException($"Comment with this {id} is not available to delete");
       
        comments.Remove(commentToDelete);
        await comments.WriteToFileFromJsonAsync(_commentDataPath);
        
        return commentToDelete;
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        var comments = await _commentDataPath.ReadJsonFromFileAsync<List<Comment>>();
        var comment = comments.FirstOrDefault(c => c.Id == id);
        
        if(comment is null)
            throw new ArgumentNullException($"Comment with this {id} is not available to get");
        
        return comment;
    }

    public async Task<List<Comment>> GetByUserId(int userId)
    {
        var comments = await _commentDataPath.ReadJsonFromFileAsync<List<Comment>>();
        var userComment = comments.Any(c => c.UserId == userId);

        if (!userComment)
            throw new ArgumentException($"There is no comment with this userId");

        var userComments = comments.Where(c => c.UserId == userId);
        return userComments.ToList();
    }

    public async Task<List<Comment>> GetByPostIdAsync(int postId)
    {
        var comments = await _commentDataPath.ReadJsonFromFileAsync<List<Comment>>();
        var postComment = comments.Any(c => c.PostId == postId);

        if (!postComment)
            throw new ArgumentException($"There is not comment with this {postId}");

        var postComments = comments.Where(c => c.PostId == postId).ToList();
        return postComments;
    }
}