using FruitsAndVegetables.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitsAndVegetables.Data.interfaces
{
    public interface IOrderRepository
    {
         void CreateOrder(Order order);
    }
}
