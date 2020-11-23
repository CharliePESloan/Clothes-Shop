using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Data/Item", fileName = "New Item")]
    public class BaseItem : ScriptableObject
    {
        public string name;
        public Sprite icon;
        public int price;
    }
}