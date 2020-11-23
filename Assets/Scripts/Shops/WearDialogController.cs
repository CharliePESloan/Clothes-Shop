using System;
using Items.Apparel;
using UnityEngine;
using UnityEngine.UI;

namespace Shops
{
    using Player;
    
    public class WearDialogController : MonoBehaviour
    {
        [SerializeField] private PlayerInventory playerInventory;
        [SerializeField] private PlayerClothing playerClothing;
        [SerializeField] private Text itemNameText;
        [SerializeField] private Button wearButton;

        private BaseApparel currentItem;
        
        // Populate and open the dialog
        public void Open(BaseApparel item)
        {
            if (playerClothing.Wearing(item))
            {
                itemNameText.text = $"Already wearing {item.name}.";
                wearButton.interactable = false;
            }
            else
            {
                currentItem = item;
                itemNameText.text = $"Wear {item.name}?";
                wearButton.interactable = true;
            }
            gameObject.SetActive(true);
        }

        // Close the dialog
        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void WearItem()
        {
            if (playerInventory.Contains(currentItem))
            {
                playerClothing.SetClothing(currentItem);
            }
            Close();
        }

        private void Start()
        {
            Close();
        }
    }
}