using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInary_Academy_DataStructure
{
    class SecondModel
    {
        public Post postById;
        public Comment commentWithMaxLenght;
        public Comment commentWithMaxCountLikes;
        public int countComment;

        public SecondModel()
        {
            postById = new Post();
            commentWithMaxCountLikes = new Comment();
            commentWithMaxLenght = new Comment();
        }

        public override string ToString()
        {
            string s = $"postById: {postById}\n\n" +
                $"commentWithMaxLenght: {commentWithMaxLenght}\n\n" +
                $"commentWithMaxCountLikes: {commentWithMaxCountLikes}\n\n" +
                $"countComment: {countComment}\n";

            return s;
        }
    }
}
