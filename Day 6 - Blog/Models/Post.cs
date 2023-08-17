using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Models;

public class Post{  

    public Post(){
        Comments = new HashSet<Comment>();
    }

    public int PostId {get; set;}

    public string Title {get; set;} = "";

    public string Content {get; set;} = "";

    public DateTime createdAt {get;}

    public virtual ICollection<Comment> Comments {get; set;}
}