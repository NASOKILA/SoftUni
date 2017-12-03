    namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Data.Models;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreatePostCommand : ICommand
    {

        //Vzimame si i kategoriite zashtoto shte ni trqbvat pri suzdavaneto
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public CreatePostCommand(IPostService IPostService, ICategoryService ICategoryService)
        {
            this.postService = IPostService;
            this.categoryService = ICategoryService;
        }

        public string Excecute(params string[] args)
        {

            string categoryName = args[0];
            string title = args[1];
            string content = args[2];
            
            //vzimame si kategoriata
            Category category = categoryService.ByName(categoryName);

            //ako kategoriqta ne sushtestvuva trqbva da q suzdadem
            if (category == null)
            {
                Console.WriteLine($"Category {categoryName} created.");
                category = categoryService.Create(categoryName);
            }
            
            //Usera trqbva da e lognat za da suzdava postove
            if (Session.User == null)
                return "You are not logged in so you cannot create posts.";
            
            //Avtora ni e samiq user
            var author = Session.User;

            //Suzdavame si samiq post !!!

            var post = postService.Create(category, title, content, author);
            
            return $"Post with id {post.Id} created successfully !";

        }
    }
}
