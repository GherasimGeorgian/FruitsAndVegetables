using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.Data.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsAndVegetables.Data.mocks
{
    public class MockCategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> Categories { get {
                return new List<Category>
                {
                     new Category{ CategoryName = "Fructe", Description = "Fructele sunt delicioase." },
                     new Category{ CategoryName = "Legume", Description = "Legumele sunt delicioase."}
                };
            }
        }
    }
}
