using Domain.Entities.Recipes.Juice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Juice
{
    public class FruitPressService: IFruitPressService
    {

        public Dictionary<string,decimal> GenerateFruitDictionary(decimal appleQuantity, decimal melonQuantity, decimal orangeQuantity)
        {
            Dictionary<string, decimal> fruits = new();
            fruits.Add("Apple", appleQuantity);
            fruits.Add("Melon", melonQuantity);
            fruits.Add("Orange", orangeQuantity);
            return fruits;
        }

        public List<string> Produce(JuiceRecipe recipe, Dictionary<string, decimal> fruits, int moneyPaid, int orderedGlassQuantity)
        {
            //DECLARE LISTS WHERE WE WILL STORE STRINGS OF OUR RESULT AFTER PRODUCE METHOD HAS BEEN COMPLITED
            List<string> errorList = new();
            List<string> result = new();

            //DECLARE PAYMENT CALCULATION VARIABLES
            int moneyRequired = recipe.PricePerGlass * orderedGlassQuantity;
            int moneyExchange = moneyPaid - moneyRequired;
            int missingMoneyAmmount = moneyRequired - moneyPaid;
            int payableAmountOfGlasses = moneyPaid / recipe.PricePerGlass;

            //DECLARE TYPE AND QUANTITY CALCULATION VARIABLES
            decimal consumptionPerGlass = recipe.ConsumptionPerGlass;
            decimal fruitRequired = orderedGlassQuantity * consumptionPerGlass;

            //CHECK IF MONEY IS ENOUGH TO BUY SELECTED QUANTITY OF GLASSES
            if (moneyPaid >= moneyRequired)
            {
                //LOOP TRUE FRUIT DICTIONARY TO PERFORM TYPE AND QUANTITY CALCULATIONS
                foreach (var fruit in fruits)
                {
                    decimal fruitLeftover = fruit.Value - fruitRequired;
                    decimal missingFruitQuantity = fruitRequired - fruit.Value;

                    switch (fruit.Key == recipe.AllowedFruit)
                    {
                        case false:
                            //FOR ALL THE FRUITS THAT ARE NOT ALLOWED AND QUANTITY IS NOT ZERO SHOW AN ERROR MESSAGE
                            if (fruit.Value > 0)
                            {
                                result.Clear();
                                result.Add("Error! " + fruit.Key + "(s) are not allowed in this recipe! This value must be 0 when you are selling product " + recipe.Name + "!");
                            }
                            break;

                        case true:

                        //IF ALLOWED FRUIT QUANTITY IS NOT ENOUGH TO PRODUCE THE JUICE SHOW AN ERROR MESSAGE
                        if (fruit.Value < fruitRequired)
                        {
                            result.Clear();
                            result.Add("Error! " + "You don't have enough " + fruit.Key.ToLower() + " (s) for selected quantity! You must add " + missingFruitQuantity + " " + fruit.Key.ToLower() + " (s) to produce this order!");
                        }

                        //IF ALLOWED FRUIT QUANTITY IS ABOVE REQUIRED QUANTITY SHOW SUCCESS MESSAGE
                        else
                        {
                            if (!result.Any())
                            {
                                result.Add("Success! " + fruitLeftover + " " + fruit.Key.ToLower() + " (s) will remain after the production of this juice! You must return " + moneyExchange + " SEK to your customer!");
                            }
                        }
                        break;
                    }
                }
            }

            //SHOW AN ERROR BECAUSE MONEY IS NOT ENOUGH TO COMPLETE THE ORDER
            else
            {
                result.Clear();
                result.Add("Error! " + "Money only enough for " + payableAmountOfGlasses + " glass (es). Money: " + moneyRequired + " SEK needed! Missing amount: " + missingMoneyAmmount + " SEK!");
            }

            return result;
        }
    }
}