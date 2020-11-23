using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	using Items;
    using Items.Apparel;
    
    public class PlayerInventory : MonoBehaviour
    {
        private List<BaseApparel> allClothes;

        private void Awake()
        {
	        allClothes = new List<BaseApparel>();
        }

        public void AddClothing(BaseApparel item)
        {
            allClothes.Add(item);
        }
        
		public bool Contains(BaseApparel item)
		{
			return allClothes.Contains(item);
		}
    }
}