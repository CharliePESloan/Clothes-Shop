using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Shops
{
    using Player;
    using Items;
    using Items.Apparel;
    using Dialogs;
    
    public class TakeDialog : Dialog
    {
        [FormerlySerializedAs("purchaseDescriptionText")] [SerializeField] private Text itemNameText;
        [SerializeField] private Text priceText;

        private PlayerInventory _playerInventory;
        private BaseItem _currentItem;
        private ShopItem _currentShopItem;

        public void Setup(BaseItem item,ShopItem shopItem)
        {
            itemNameText.text = $"Take the {item.name}?";
            priceText.text = item.Price;
            _currentItem = item;
            _currentShopItem = shopItem;
        }

        // Close the dialog
        public override void Close()
        {
            // _currentItem = null;
            // _currentShopItem = null;
            gameObject.SetActive(false);
        }

        public void TakeItem()
        {
            if (_currentShopItem.HasItem)
            {
                _currentShopItem.TakeItem();
                _playerInventory.AddFromShop(_currentItem);
            }
            Close();
        }

        private void Start()
        {
            _playerInventory = FindObjectOfType<PlayerInventory>();
            Close();
        }
    }

}