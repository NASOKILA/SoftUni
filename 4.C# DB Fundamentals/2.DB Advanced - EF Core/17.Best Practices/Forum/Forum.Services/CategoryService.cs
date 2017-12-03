namespace Forum.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Forum.Data.Models;
    using Forum.Data;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        
        //Trqbva ni kontexta setnat v konstruktor zashtoto shte rabotim s bazata
        private readonly ForumDbContext context; 

        public CategoryService(ForumDbContext context)
        {
            this.context = context;
        }


        public Category ById(int id)
        {
            var category = context.Categories.Find(id);
            return category;
        }

        public Category ByName(string name)
        {
            var category = context.Categories.SingleOrDefault( c => c.Name == name);
            return category;
        }

        public Category Create(string name)
        {
            Category category = new Category(name);

            context.Categories.Add(category);

            context.SaveChanges();

            return category;
        }

    }
}
