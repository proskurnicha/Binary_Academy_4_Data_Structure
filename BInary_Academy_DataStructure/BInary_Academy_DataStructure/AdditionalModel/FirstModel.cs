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
            string s = $"User: {userById}\n\n" +
                $"lastPost: {lastPost}\n\n" +
                $"countCommentsLastPost: {countCommentsLastPost}\n\n" +
                $"countTaskNotDone: {countTaskNotDone}\n\n" +
                $"mostPopularPostByLenght: {mostPopularPostByLenght}\n\n" +
                $"mostPopularPostByLikes: {mostPopularPostByLikes}\n\n";
            return s;
        }
    }
}
