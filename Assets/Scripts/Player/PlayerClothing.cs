using UnityEngine;

namespace Player
{
    using Items.Apparel;
    
    public class PlayerClothing : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer clothingSprite;
        [SerializeField] private BaseApparel currentClothes;
        
        public void SetClothing(BaseApparel newApparel)
        {
            if (currentClothes == null || !currentClothes.Equals(newApparel))
            {
                currentClothes = newApparel;
                clothingSprite.sprite = newApparel.playerSprite;
            }
        }

        // Check if the player is already wearing this item
        public bool Wearing(BaseApparel item)
        {
            return item.Equals(currentClothes);
        }
    }
}