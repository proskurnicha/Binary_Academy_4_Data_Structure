using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInary_Academy_DataStructure
{
    class ManipulateDataService
    {
        ParseService service;
        public List<User> users;

        public ManipulateDataService()
        {
            service = new ParseService();
            users = service.users;
        }

        public int GetCountCommentsByUserId(int id)
        {
            return users.Where(x => x.id == id).SelectMany(user => user.posts).Sum(post => post.comments.Count);
        }

        public List<Comment> GetCommentsByUserId(int id)
        {
            return users.Where(user => user.id == id).SelectMany(user => user.posts).SelectMany(post => post.comments).Where(comment => comment.body.Length < 50).ToList();
        }

        public List<Todo> GetDoneTodosByUserId(int id)
        {
            return users.Where(user => user.id == id).SelectMany(user => user.todos).Where(todo => todo.isComplete == true).ToList();
        }

        public List<User> GetOrderedListOfUsers()
        {
            return users.OrderBy(user => user.name).Select(user => new User() { id = user.id, name = user.name, todos = user.todos.OrderByDescending(todo => todo.name.Length).ToList() }).ToList();
        }

        public FirstModel GetInfoAboutUserById(int id)
        {
            FirstModel firstModel = new FirstModel();
            firstModel.userById = users.Find(user => user.id == id);

            if (firstModel.userById != null)
            {
                firstModel.userById.posts.ForEach(post => { if (firstModel.lastPost.createdAt < post.createdAt) { firstModel.lastPost = post; } });

                if (firstModel.lastPost.comments != null)
                    firstModel.countCommentsLastPost = firstModel.lastPost.comments.Count;

                firstModel.countTaskNotDone = firstModel.userById.todos.Where(todo => !todo.isComplete).Count();


                int countComment = 0;

                firstModel.userById.posts.ForEach(post =>
                {
                    int currentCountComment = post.comments.Where(comment => comment.body.Length > 80).Count();
                    if (countComment < currentCountComment)
                    {
                        firstModel.mostPopularPostByLenght = post;
                        countComment = currentCountComment;
                    }
                });

                firstModel.userById.posts.ForEach(post => { if (firstModel.mostPopularPostByLikes.likes < post.likes) { firstModel.mostPopularPostByLikes = post; } });

            }

            return firstModel;
        }

        public SecondModel GetInfoAboutPostById(int id)
        {
            SecondModel secondModel = new SecondModel();
            //users.FirstOrDefault(user => user.id == id);
            users.ForEach(user =>
            {
                if (user.posts.FirstOrDefault(post => post.id == id) != null)
                    secondModel.postById = user.posts.Find(post => post.id == id);
            });

            if (secondModel.postById != null)
            {
                secondModel.postById.comments.ForEach(comment =>
                {
                    if (secondModel.commentWithMaxLenght.body.Length < comment.body.Length)
                        secondModel.commentWithMaxLenght = comment;
                });

                secondModel.postById.comments.ForEach(comment =>
                {
                    if (secondModel.commentWithMaxCountLikes.likes < comment.likes)
                        secondModel.commentWithMaxCountLikes = comment;
                });

                secondModel.postById.comments.ForEach(comment =>
                {
                    if (comment.likes == 0 || comment.body.Length < 80)
                        secondModel.countComment++;
                });
            }

            return secondModel;
        }
    }
}
