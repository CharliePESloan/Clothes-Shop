using Shops;
using UnityEngine;

namespace Dialogs
{
    public class DialogManager : MonoBehaviour
    {
        public enum DialogTypes
        {
            Wear,
            Take,
            ChangingRoom,
            Purchase,
            Replace
        }
        
        [SerializeField] private WearDialog wearDialog;
        [SerializeField] private TakeDialog takeDialog;
        [SerializeField] private ChangingRoomDialog changingRoomDialog;
        [SerializeField] private PurchaseDialog purchaseDialog;
        [SerializeField] private ReplaceDialog replaceDialog;

        private static DialogManager _dialogManagerInstance;
        private static DialogManager DialogManagerInstance
        {
            get
            {
                if (_dialogManagerInstance == null)
                {
                    _dialogManagerInstance = FindObjectOfType<DialogManager>();
                }

                return _dialogManagerInstance;
            }
        }
        
        public Dialog GetDialog(DialogTypes dialog)
        {
            switch (dialog)
            {
                case DialogTypes.Wear:
                    return wearDialog;
                case DialogTypes.Take:
                    return takeDialog;
                case DialogTypes.ChangingRoom:
                    return changingRoomDialog;
                case DialogTypes.Purchase:
                    return purchaseDialog;
                case DialogTypes.Replace:
                    return replaceDialog;
            }

            return null;
        }
        public void OpenDialog(DialogTypes dialog)
        {
            GetDialog(dialog).Open();
        }
        public void CloseDialog(DialogTypes dialog)
        {
            GetDialog(dialog).Close();
        }
        
        public static Dialog Get(DialogTypes dialog)
        {
            return DialogManagerInstance.GetDialog(dialog);
        }
        public static void Open(DialogTypes dialog)
        {
            Get(dialog).Open();
        }
        public static void Close(DialogTypes dialog)
        {
            Get(dialog).Close();
        }

        public static void CloseAllShop()
        {
            Close(DialogTypes.Purchase);
            Close(DialogTypes.Take);
            Close(DialogTypes.Wear);
            Close(DialogTypes.ChangingRoom);
            Close(DialogTypes.Replace);
        }
    }
}