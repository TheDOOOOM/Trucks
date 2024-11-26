using Project.Screpts;
using Project.Screpts.SO;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _unlock;
    [SerializeField] private Sprite _lock;
    [SerializeField] private Image _lockImage;
    [SerializeField] private PlayerCoins _playerCoins;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private TextMeshProUGUI _textPrice;

    private Truck _truckItem;
    private int _price;
    private bool _isItemUnlock;
    private ShopItems _shopItems;
    private int _index;

    public void SetData(ShopItems shopItems, bool unlocl, Truck truckprefab, int Price, int index)
    {
        _index = index;
        _shopItems = shopItems;
        _isItemUnlock = unlocl;
        _truckItem = truckprefab;
        _price = Price;
        _textPrice.text = $"${_price}";

        if (_isItemUnlock)
        {
            _image.sprite = _unlock;
            _lockImage.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isItemUnlock)
        {
            _playerConfig.SetActiveTruck(_truckItem);
        }

        if (_price >= _playerCoins.Coins)
        {
            _shopItems.Unlock(_index);
            _playerCoins.RemoveValue(_price);
            _image.sprite = _unlock;
            _lockImage.gameObject.SetActive(false);
        }
    }
}