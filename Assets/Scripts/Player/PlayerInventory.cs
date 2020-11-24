using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Player
{
	using Items;
    using Items.Apparel;
    
    public class PlayerInventory : MonoBehaviour
    {
	    public List<BaseItem> items;
	    public List<BaseItem> itemsFromShop;

        private void Awake()
        {
	        items = items ?? new List<BaseItem>();
	        itemsFromShop = itemsFromShop ?? new List<BaseItem>();
        }

        public void Add(BaseItem item)
        {
	        items.Add(item);
        }
        public void AddFromShop(BaseItem item)
        {
	        itemsFromShop.Add(item);
        }

        public void Remove(BaseItem item)
        {
	        items.Remove(item);
        }
        public void RemoveFromShop(BaseItem item)
        {
	        itemsFromShop.Remove(item);
        }
        
		public bool Contains(BaseApparel item)
		{
			return items.Contains(item);
		}
		public bool ContainsFromShop(BaseApparel item)
		{
			return itemsFromShop.Contains(item);
		}

		public IEnumerable<BaseApparel> Clothes
		{
			get
			{
				IEnumerable<BaseItem> filteredItems = items.Where(item =>
				{
					BaseApparel apparel = item as BaseApparel;
					return apparel != null;
				});
				IEnumerable<BaseApparel> clothes = filteredItems.Select(item => item as BaseApparel);
				return clothes;
			}
		}

		public IEnumerable<BaseApparel> ClothesFromShop
		{
			get
			{
				IEnumerable<BaseItem> filteredItems = itemsFromShop.Where(item =>
				{
					BaseApparel apparel = item as BaseApparel;
					return apparel != null;
				});
				IEnumerable<BaseApparel> clothes = filteredItems.Select(item => item as BaseApparel);
				return clothes;
			}
		}
    }
}