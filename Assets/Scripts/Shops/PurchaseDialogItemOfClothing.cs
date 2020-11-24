using UnityEngine;
using UnityEngine.UI;

namespace Shops
{
    using Items.Apparel;
    
    public class PurchaseDialogItemOfClothing : MonoBehaviour
    {
        [SerializeField] private Text itemNameText;

        public void SetItem(BaseApparel item)
        {
            itemNameText.text = item.name;
        }
    }
}