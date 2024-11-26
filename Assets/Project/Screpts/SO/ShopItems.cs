using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Screpts.SO
{
    [CreateAssetMenu(fileName = "ShopItems", menuName = "ShopItems")]
    public class ShopItems : ScriptableObject
    {
        [SerializeField] private List<ShopItem> _shopItems;

        public List<ShopItem> GetItems()
        {
            return _shopItems;
        }

        public void Unlock(int itemIndex)
        {
            _shopItems[itemIndex].UnlockItem();
        }
    }

    [Serializable]
    public struct ShopItem
    {
        [SerializeField] private Truck _truckPrefab;
        [SerializeField] private int _price;
        [SerializeField] private bool _isUnlock;

        public bool Unlock => _isUnlock;
        public int Price => _price;

        public Truck GetPrefab() => _truckPrefab;

        public void Reset() => _isUnlock = false;

        public void UnlockItem() => _isUnlock = true;
    }
}