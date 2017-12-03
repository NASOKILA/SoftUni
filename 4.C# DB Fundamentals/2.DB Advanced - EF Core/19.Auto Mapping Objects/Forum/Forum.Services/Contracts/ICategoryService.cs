using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Services.Contracts
{
    public interface ICategoryService
    {
        //kakvo shte ima edna kategoriq

        Category ById(int id);

        Category ByName(string name);

        Category Create(string name);
    }
}
