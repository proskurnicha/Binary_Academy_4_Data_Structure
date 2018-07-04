using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInary_Academy_DataStructure
{
    class Menu
    {
        ManipulateDataService manipulateData;

        public Menu()
        {
            manipulateData = new ManipulateDataService();
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите операцию:\n" +
                "1 - Получить количество комментов под постами конкретного пользователя (по айди)\n" +
                "2 - Получить список комментов под постами конкретного пользователя (по айди), где body коммента < 50 символов\n" +
                "3 - Получить список (id, name) из списка todos которые выполнены для конкретного пользователя (по айди)\n" +
                "4 - Получить список пользователей по алфавиту (по возрастанию) с отсортированными todo items по длине name (по убыванию)\n" +
                "5 - Получить информацию о пользователе по айди\n" +
                "6 - Получить информацию о посте по айди\n" +
                "7 - Выйти\n");

                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        {
                            //recomended id = 11
                            Console.WriteLine("Введите aйди пользователя: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            int count = manipulateData.GetCountCommentsByUserId(id);
                            Console.WriteLine($"Количество комментариев: {count}");
                            Stop();
                        }
                        break;
                    case 2:
                        {
                            //recomended id = 46
                            Console.WriteLine("Введите aйди пользователя: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            List<Comment> comments = manipulateData.GetCommentsByUserId(id);
                            if(comments.Count == 0)
                                Console.WriteLine("No comments");
                            else comments.ForEach(comment => Console.WriteLine(comment));
                            Stop();
                        }
                        break;
                    case 3:
                        {
                            //recomended id = 4
                            Console.WriteLine("Введите aйди пользователя: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            List<Todo> todos = manipulateData.GetDoneTodosByUserId(id);
                            if (todos.Count == 0)
                                Console.WriteLine("No todos");
                            else
                                todos.ForEach(todo => Console.WriteLine(todo));
                            Stop();
                        }
                        break;
                    case 4:
                        {
                            List<User> users = manipulateData.GetOrderedListOfUsers();

                            users.ForEach(user => Console.WriteLine(user.Show()));
                            Stop();
                        }
                        break;
                    case 5:
                        {
                            //recomended id = 12
                            Console.WriteLine("Введите aйди пользователя: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            FirstModel firstModel = manipulateData.GetInfoAboutUserById(id);
                            Console.WriteLine(firstModel);
                            Stop();
                        }
                        break;
                    case 6:
                        {
                            //recomended id = 48
                            Console.WriteLine("Введите aйди поста: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            SecondModel secondModel = manipulateData.GetInfoAboutPostById(id);
                            Console.WriteLine(secondModel);
                            Stop();
                        }
                        break;
                    case 7:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        break;
                }
            }


        }

        private void Stop()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
