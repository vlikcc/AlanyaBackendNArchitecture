using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reciepe : Entity
    {
       
        public string? RecipeName { get; set; }
        public decimal? RecipeCost { get; set; }    
        public Reciepe(int id, string recipeName, decimal recipeCost)
        {
            Id = id;
            RecipeName = recipeName;
            RecipeCost = recipeCost;
        }

        public Reciepe()
        {
        }
    }
}
