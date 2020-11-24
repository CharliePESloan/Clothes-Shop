using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Data/Item", fileName = "New Item")]
    public class BaseItem : ScriptableObject
    {
        public string name;
        public Sprite icon;
        public int price;

        public string Price
        {
            get
            {
                string priceString;
                int cash = price;
                int pounds = cash/100;
                int pennies = cash - pounds*100;
                if (pennies < 10)
                {
                    priceString = $"£{pounds}.0{pennies}";
                }
                else
                {
                    priceString = $"£{pounds}.{pennies}";
                }

                return priceString;
            }
        }
    }
}