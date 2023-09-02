using Habr.Service.Domain.Commons;
using Habr.Service.Domain.Entities.BlogPosts;
using Habr.Service.Domain.Entities.Comments;
using Habr.Service.Domain.Entities.User;

namespace Habr.Service.DataAccses.Constans;

public static class Constant
{
    public static string GenericFilePath<T>(T item) where T: Auditable
    {
        var currentDirectory = Directory.GetCurrentDirectory(); 
        var parentDirectory = Directory.GetParent(currentDirectory).Parent.Parent.ToString();
        string typeName = String.Empty;
        
        if(typeof(T) == typeof(User)) typeName = "User";
        if(typeof(T) == typeof(BlogPost)) typeName = "BlogPost";
        if(typeof(T) == typeof(Comment)) typeName = "Comment";
      
        var myFileInProjectDirectory = Path.Combine(parentDirectory,"DataAccess","Files", $"{typeName}DataFile.txt");
        
        return myFileInProjectDirectory;
    }
    
    
}