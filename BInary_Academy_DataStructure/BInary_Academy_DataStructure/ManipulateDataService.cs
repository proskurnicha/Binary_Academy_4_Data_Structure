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
            int sum = 0;
            User user = users.Find(x => x.id == id);
            if (user != null)
                user.posts.ForEach(post => sum += post.comments.Count);

            return sum;
        }

        public List<Comment> GetCommentsByUserId(int id)
        {
            List<Comment> commentsWithLenghtLess50 = new List<Comment>();

            User user = users.Find(x => x.id == id);
            if (user != null)
                user.posts.ForEach(post => post.comments.ForEach(
                        comment => { if (comment.body.Length < 50) commentsWithLenghtLess50.Add(comment); }
                    ));

            return commentsWithLenghtLess50;
        }

        public List<Todo> GetDoneTodosByUserId(int id)
        {
            List<Todo> result = new List<Todo>();
            User user = users.Find(x => x.id == id);
            if (user != null)
                user.todos.ForEach(todo =>
                {
                    if (todo.isComplete)
                    {
                        result.Add(new Todo() { id = todo.id, name = todo.name, isComplete = todo.isComplete });
                    }
                });

            return result;
        }

        public List<User> GetOrderedListOfUsers()
        {
            List<User> orderedUsers = users.OrderBy(user => user.name).ToList();
            orderedUsers.ForEach(user => user.todos = user.todos.OrderByDescending(todo => todo.name.Length).ToList());

            return orderedUsers;
        }

        public FirstModel GetInfoAboutUserById(int id)
        {
            FirstModel firstModel = new FirstModel();
            firstModel.userById = users.Find(user => user.id == id);

            if (firstModel.userById != null)
            {
                firstModel.userById.posts.ForEach(post => { if (firstModel.lastPost.createdAt < post.createdAt) { firstModel.lastPost = post; } });

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

            users.ForEach(user =>
            {
                if (user.posts.FirstOrDefault(post => post.id == id) != null)
                    secondModel.postById = user.posts.Find(post => post.id == id);
            });

            if(secondModel.postById != null)
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
