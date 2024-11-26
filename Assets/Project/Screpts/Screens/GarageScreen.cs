using System.Collections.Generic;
using Project.Screpts.SO;
using UnityEngine;

namespace Project.Screpts.Screens
{
    public class GarageScreen : BaseScreen
    {
        [SerializeField] private ShopItems _shopItems;
        [SerializeField] private List<ShopElement> _shopElements;

        public override void Init()
        {
            base.Init();
            var items = _shopItems.GetItems();
            for (int i = 0; i < _shopElements.Count; i++)
            {
                Debug.Log(items[i]);
                Debug.Log(_shopElements[i]);
                _shopElements[i].SetData(_shopItems, items[i].Unlock, items[i].GetPrefab(), items[i].Price, i);
            }
        }

        public void BackMenu()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowMenuScreen();
        }
    }
}