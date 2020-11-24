using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shops
{
    using Items.Apparel;
    using Player;
    using Dialogs;
    
    public class WearDialog : Dialog
    {
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private PlayerClothing playerClothing;
        [SerializeField] private Text itemNameText;
        [SerializeField] private Button wearButton;
        [SerializeField] private Button takeButton;

        private BaseApparel _currentItem;
        private ShopItem _currentShopItem;

        public void Setup(BaseApparel item,ShopItem shopItem)
        {
            _currentItem = item;
            _currentShopItem = shopItem;
            itemNameText.text = $"Wear {item.name}?";
            
            var btn = takeButton.GetComponent<CanvasGroup>();
            if (shopItem == null)
            {
                btn.interactable = false;
                btn.alpha = 0;
            }
            else
            {
                btn.interactable = true;
                btn.alpha = 1;
            }
        }

        public void WearItem()
        {
            playerClothing.SetClothing(_currentItem);
            if (_currentShopItem != null)
            {
                _currentShopItem.TakeItem();
            }
            Close();
        }

        private void Start()
        {
            playerClothing = FindObjectOfType<PlayerClothing>();
            Close();
        }
    }
}