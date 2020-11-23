using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField] private Text cashText;
        [SerializeField] private int cash;

        private string CashString
        {
            get
            {
                int pounds = cash / 100;
                int pennies = cash - pounds * 100;
                if (pennies < 10)
                {
                    return $"£{pounds}.0{pennies}";
                }
                else
                {
                    return $"£{pounds}.{pennies}";
                }
            }
        }

        public int Cash => cash;

        public void Spend(int amount)
        {
            SetCash(cash - amount);
        }

        public void SetCash(int newCash)
        {
            // Set the player's cash to a minimum of 0 and set the onscreen text
            cash = Mathf.Max(0, newCash);
            cashText.text = "Cash: " + CashString;
        }

        void Start()
        {
            SetCash(cash);
        }
    }
}