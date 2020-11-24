using System;
using UnityEngine;

namespace Shops
{
    using Dialogs;
    public class ChangingRoom : MonoBehaviour
    {
        [SerializeField] private Dialog changingRoomDialog;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DialogManager.Open(DialogManager.DialogTypes.ChangingRoom);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DialogManager.CloseAllShop();
            }
        }
    }
}