﻿namespace DAL1.Model;

public class CommentLikes : Base
{
    public int UserId {get; set;}
    public int BookId { get; set; }
    public int LikeId { get; set; }
}