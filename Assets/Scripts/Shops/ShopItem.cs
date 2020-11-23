using System;
using UnityEngine;

namespace Shops
{
    using Player;
    using Items;
    using Items.Apparel;
    
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private BaseItem item;

        private PurchaseDialogController purchaseDialog;
        private WearDialogController wearDialog;
        private PlayerInventory playerInventory;

        private void Awake()
        {
            // Gather the required objects
            purchaseDialog = FindObjectOfType<PurchaseDialogController>();
            wearDialog = FindObjectOfType<WearDialogController>();
            playerInventory = FindObjectOfType<PlayerInventory>();
        }

        // Open a dialog when the player walks over an item
        private void OnTriggerEnter2D(Collider2D other)
        {
            BaseApparel clothing = (BaseApparel) item;
            if (other.gameObject.CompareTag("Player"))
            {
                if (playerInventory.Contains(clothing))
                {
                    wearDialog.Open(clothing);
                }
                else
                {
                    purchaseDialog.Open(item);
                }
            }
        }

        // Close all dialogs when leaving the item
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                purchaseDialog.Close();
                wearDialog.Close();
            }
        }
    }
}