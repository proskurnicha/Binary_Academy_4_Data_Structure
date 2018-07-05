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
            string s = $"postById: {postById}\n\n";

            if (commentWithMaxLenght.id == 0)
                s += $"commentWithMaxLenght: - \n\n";
            else s += $"commentWithMaxLenght: {commentWithMaxLenght}\n\n";

            if (commentWithMaxCountLikes.id == 0)
                s += $"commentWithMaxCountLikes: - \n\n";
            else s += $"commentWithMaxCountLikes: {commentWithMaxCountLikes}\n\n";
            s += $"countComment: {countComment}\n";

            return s;
        }
    }
}
