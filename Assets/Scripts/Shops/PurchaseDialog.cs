using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Shops
{
    using Items;
    using Items.Apparel;
    using Player;
    using Dialogs;
    
    public class PurchaseDialog : Dialog
    {
        [SerializeField] private PlayerWallet playerWallet;
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private Text priceText;
        [SerializeField] private GameObject itemsOfClothingPanel;
        [SerializeField] private Button purchaseButton;
        [SerializeField] private GameObject clothingPrefab;

        private List<BaseApparel> _currentItems;

        private int _totalPrice;

        public override void Open()
        {
            int length = itemsOfClothingPanel.transform.childCount;
            for (int i = length-1; i >= 0; i--)
            {
                Destroy(itemsOfClothingPanel.transform.GetChild(i).gameObject);
            }
            
            _currentItems = playerInventory.ClothesFromShop.ToList();

            _totalPrice = 0;

            foreach (BaseApparel itemOfClothing in _currentItems)
            {
                PurchaseDialogItemOfClothing item = Instantiate(clothingPrefab).GetComponent<PurchaseDialogItemOfClothing>();
                item.SetItem(itemOfClothing);
                item.transform.SetParent(itemsOfClothingPanel.transform);
                _totalPrice += itemOfClothing.price;
            }
            
            string priceString;
            int cash = _totalPrice;
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

            if (_totalPrice > FindObjectOfType<PlayerWallet>().Cash)
            {
                purchaseButton.interactable = false;
            }
            else
            {
                purchaseButton.interactable = true;
            }
            
            base.Open();
        }

        // Close the dialog
        public override void Close()
        {
            _currentItems = new List<BaseApparel>();
            gameObject.SetActive(false);
        }

        public void BuyItem()
        {
            // TODO: Handle items other than clothing (not relevant to this task)
            if (_totalPrice <= playerWallet.Cash)
            {
                playerWallet.Spend(_totalPrice);
                foreach (BaseApparel apparel in _currentItems)
                {
                    playerInventory.RemoveFromShop(apparel);
                    playerInventory.Add(apparel);
                }
            }

            Close();
        }

        private void Start()
        {
            Close();
        }
    }
}