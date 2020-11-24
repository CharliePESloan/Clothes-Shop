using UnityEngine;
using UnityEngine.UI;

namespace Shops
{
    using Items.Apparel;
    public class ChangingRoomDialogItemOfClothing : MonoBehaviour
    {
        [SerializeField] private Text itemNameText;
        [SerializeField] private Image itemIcon;
        
        public void SetItem(BaseApparel item)
        {
            itemNameText.text = item.name;
            try
            {
                itemIcon.sprite = item.icon;
            } finally{}
        }
    }
}