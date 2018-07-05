using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInary_Academy_DataStructure
{
    class FirstModel
    {
        public User userById;
        public Post lastPost;
        public int countCommentsLastPost;
        public int countTaskNotDone;
        public Post mostPopularPostByLenght;
        public Post mostPopularPostByLikes;

        public FirstModel()
        {
            userById = new User();
            lastPost = new Post();
            mostPopularPostByLenght = new Post();
            mostPopularPostByLikes = new Post();
        }

        public override string ToString()
        {
            string s = $"User: {userById}\n\n";
            if (lastPost.id == 0)
                s += $"lastPost: - \n\n";
            else s += $"lastPost: {lastPost}\n\n";

            s += $"countCommentsLastPost: {countCommentsLastPost}\n\n" +
                $"countTaskNotDone: {countTaskNotDone}\n\n";

            if (mostPopularPostByLenght.id == 0)
                s += $"mostPopularPostByLenght: - \n\n";
            else s += $"mostPopularPostByLenght: {mostPopularPostByLenght}\n\n";

            if (mostPopularPostByLikes.id == 0)
                s += $"mostPopularPostByLikes: -\n\n";
            else s += $"mostPopularPostByLikes: {mostPopularPostByLikes}\n\n";
            return s;
        }
    }
}
