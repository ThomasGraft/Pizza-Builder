using System;
using System.Collections.Generic;
using System.Text;

namespace CSC420Project1
{
    public class Pizza
    {
        #region Fields

        private string size;
        private string crust;
        private List<string> toppings;
        private int quantity = 1;

        public double Price { get; private set; } 
       
        #endregion

        #region Dictionaries

        Dictionary<string, double> sizePrice = new Dictionary<string, double>()
        {
            {"Small", 6.50 },
            {"Medium", 8.50 },
            {"Large", 10.50 }
        };

        Dictionary<string, double> crustPrice = new Dictionary<string, double>()
        {
            {"Thin Crust", 1 },
            {"Deep Dish", 1.50 },
            {"Stuffed Crust", 2 }
        };

        Dictionary<string, double> toppingPrice = new Dictionary<string, double>()
        {
            {"Pepperoni", 1 },
            {"Sausage", 1 },
            {"Bacon", 1 },
            {"Ham", 1},
            {"Onions", .5},
            {"Mushrooms", .5},
            {"Tomatos", .5},
            {"Green Peppers", .5},
            {"Extra Cheese", .75},
            {"Mexican Cheese Mix", 1},
        };

        #endregion

        public override string ToString()
        {
            var s = new StringBuilder();

            foreach (string a in toppings)
            {
                s.Append($"{a} ");
            }

            return $"{quantity} {size} {crust} pizza with {s}";
        }

        #region Properties

        public string Size
        {
            get => size;
            set
            {
                switch (value)
                {
                    case "Small":
                        Price += sizePrice["Small"];
                        size = value;
                        break;

                    case "Medium":
                        Price += sizePrice["Medium"];
                        size = value;
                        break;

                    case "Large":
                        Price += sizePrice["Large"];
                        size = value;
                        break;
                }
            }
        }

        public string Crust
        {
            get => crust;
            set
            {
                switch (value)
                {
                    case "Thin Crust":
                        Price += crustPrice["Thin Crust"];
                        crust = value;
                        break;

                    case "Deep Dish":
                        Price += crustPrice["Deep Dish"];
                        crust = value;
                        break;

                    case "Stuffed Crust":
                        Price += crustPrice["Stuffed Crust"];
                        crust = value;
                        break;
                }
            }
        }

        public List<string> Toppings
        {
            get => toppings;
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    Price += toppingPrice[value[i]];
                }

                toppings = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                Price *= value;
                quantity = value;
            }
        }

        #endregion

        #region Constructor

        public Pizza(string s, string c, List<string> t, int q)
        {
            Size = s;
            Crust = c;
            Toppings = t;
            Quantity = q;
        }

        #endregion
    }
}
