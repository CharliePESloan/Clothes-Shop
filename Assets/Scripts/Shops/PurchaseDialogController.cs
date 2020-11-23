using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shops
{
    using Player;
    using Items;
    using Items.Apparel;
    
    public class PurchaseDialogController : MonoBehaviour
    {
        [SerializeField] private PlayerWallet playerWallet;
        [SerializeField] private PlayerClothing playerClothing;
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private Text purchaseDescriptionText;
        [SerializeField] private Text priceText;

        private BaseItem currentItem;

        // Populate and open the dialog
        public void Open(BaseItem item)
        {
            purchaseDescriptionText.text = $"Purchase a {item.name}?";
            string priceString;
            int cash = item.price;
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
            priceText.text = priceString;
            currentItem = item;

            gameObject.SetActive(true);
        }

        // Close the dialog
        public void Close()
        {
            currentItem = null;
            gameObject.SetActive(false);
        }

        public void BuyItem()
        {
            // TODO: Handle items other than clothing (not relevant to this task)
            if (currentItem.price <= playerWallet.Cash)
            {
                BaseApparel clothes = (BaseApparel) currentItem;
                playerWallet.Spend(currentItem.price);
                playerInventory.AddClothing(clothes);
                playerClothing.SetClothing(clothes);
            }

            Close();
        }

        private void Start()
        {
            Close();
        }
    }

}