﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInary_Academy_DataStructure
{
    class Comment
    {
        public int id;
        public DateTime createdAt;
        public string body;
        public int userId;
        public int postId;
        public int likes;

        public Comment()
        {
            body = "";
        }

        public override string ToString()
        {
            return $"Id: {id.ToString()}    Body: {body.ToString()}  Body.Lenght: {body.Length}     Likes: {likes}";
        }
    }
}
