using System;
using UnityEngine;

namespace Shops
{
    using Dialogs;
    using Player;
    
    public class SalesAssistant : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PurchaseDialog dialog = DialogManager.Get(DialogManager.DialogTypes.Purchase) as PurchaseDialog;
                if (dialog != null)
                {
                    dialog.Open();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                DialogManager.CloseAllShop();
            }
        }
    }
}