using System;
using Items.Apparel;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Shops
{
    using Dialogs;
    using Items;
    
    public class ReplaceDialog : Dialog
    {
        [SerializeField] private Text dialogText;
        [SerializeField] private Text priceText;

        private PlayerClothing _playerClothing;
        private PlayerInventory _playerInventory;
        private BaseItem _currentItem;
        private ShopItem _currentShopItem;

        public void Setup(BaseItem item, ShopItem shopItem)
        {
            _currentItem = item;
            _currentShopItem = shopItem;
            dialogText.text = $"Replace {item.name}?";
            priceText.text = item.Price;

        }

        public void Replace()
        {
            BaseApparel currentClothing = _currentItem as BaseApparel;
            if (currentClothing != null)
            {
                if (_playerClothing.Wearing(currentClothing))
                {
                    dialogText.text = $"You're wearing {currentClothing.name}.";
                }
                else
                {
                    _currentShopItem.ReplaceItem();
                    _playerInventory.RemoveFromShop(_currentItem);
                    Close();
                }
            }
            else
            {
                Close();
                _currentShopItem.ReplaceItem();
                _playerInventory.RemoveFromShop(_currentItem);
            }
        }

        private void Start()
        {
            _playerInventory = FindObjectOfType<PlayerInventory>();
            _playerClothing = FindObjectOfType<PlayerClothing>();
            Close();
        }
    }
}