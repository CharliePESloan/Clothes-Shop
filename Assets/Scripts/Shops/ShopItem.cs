using System;
using UnityEngine;

namespace Shops
{
    using Player;
    using Items;
    using Items.Apparel;
    using Dialogs;
    
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private BaseItem item;
        [SerializeField] private GameObject itemSprite;

        // public BaseItem Item;

        private TakeDialog takeDialog;
        private WearDialog wearDialog;
        private ReplaceDialog replaceDialog;
        private PlayerInventory _playerInventory;
        
        private bool _hasItem = true;
        public bool HasItem => _hasItem;

        private void Awake()
        {
            // Gather the required objects
            takeDialog = FindObjectOfType<TakeDialog>();
            wearDialog = FindObjectOfType<WearDialog>();
            replaceDialog = FindObjectOfType<ReplaceDialog>();
            _playerInventory = FindObjectOfType<PlayerInventory>();
        }

        public void TakeItem()
        {
            itemSprite.SetActive(false);
            _hasItem = false;
        }

        public void ReplaceItem()
        {
            itemSprite.SetActive(true);
            _hasItem = true;
        }

        // Open a dialog when the player walks over an item
        private void OnTriggerEnter2D(Collider2D other)
        {
            BaseApparel clothing = item as BaseApparel;
            if (other.CompareTag("Player"))
            {
                if (_hasItem)
                {
                    takeDialog.Setup(item,this);
                    takeDialog.Open();
                    wearDialog.Setup(clothing,this);
                }
                else
                {
                    if (other.GetComponent<PlayerInventory>().ContainsFromShop(clothing))
                    {
                        replaceDialog.Setup(item, this);
                        replaceDialog.Open();
                    }
                }
            }
        }

        // Close all dialogs when leaving the item
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DialogManager.CloseAllShop();
            }
        }
    }
}