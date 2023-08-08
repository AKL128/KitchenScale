using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenLibrary
{
    public class Ingredient
    {
        private string amount;
        private string unit;
        private string name;

        public Ingredient(string amount, string unit, string name)
        {
            this.amount = amount;
            this.unit = unit;
            this.name = name;
        }

        public string getAmount() 
        { 
            return amount; 
        }
        public string getUnit() 
        { 
            return unit; 
        }

        public string getName() 
        { 
            return name; 
        }

        public void setAmount(string amount) 
        {  
            this.amount = amount; 
        }
        public void setUnit(string unit) 
        {  
            this.unit = unit; 
        }

        public void setName(string name) 
        { 
            this.name = name; 
        }
    }
}
