using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine.UI;

namespace Shops
{
    using Player;
    using Items.Apparel;
    using Dialogs;
    
    public class ChangingRoomDialog : Dialog
    {
        [SerializeField] private GameObject clothingPrefab;
        [SerializeField] private GameObject itemsOfClothingPanel;
        
        private PlayerInventory _playerInventory;
        
        private void Start()
        {
            _playerInventory = FindObjectOfType<PlayerInventory>();
            Close();
        }

        public override void Open()
        {
            int length = itemsOfClothingPanel.transform.childCount;
            for (int i = length-1; i >= 0; i--)
            {
                Destroy(itemsOfClothingPanel.transform.GetChild(i).gameObject);
            }
            
            List<BaseApparel> clothes = _playerInventory.Clothes.Concat(_playerInventory.ClothesFromShop).ToList();

            foreach (BaseApparel itemOfClothing in clothes)
            {
                ChangingRoomDialogItemOfClothing item = Instantiate(clothingPrefab).GetComponent<ChangingRoomDialogItemOfClothing>();
                item.SetItem(itemOfClothing);
                item.transform.SetParent(itemsOfClothingPanel.transform);
                Button itemWearButton = item.GetComponent<Button>();
                ChangingRoomDialog changingRoomDialog =
                    DialogManager.Get(DialogManager.DialogTypes.ChangingRoom) as ChangingRoomDialog;
                itemWearButton.onClick.AddListener(() =>
                {
                    WearDialog wearDialog = DialogManager.Get(DialogManager.DialogTypes.Wear) as WearDialog;
                    wearDialog?.Setup(itemOfClothing,null);
                    wearDialog?.Open();
                    Close();
                });
            }
            
            gameObject.SetActive(true);
        }
    }
}