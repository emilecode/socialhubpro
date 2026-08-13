namespace Socialhub.API.Entities;
public class Post
{
    public Guid Id {get;set;}
    public string Content {get;set;} = string.Empty;
          
    public DateTime CreatedAt {get;set;} = DateTime.Now; 
}    