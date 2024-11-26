using UnityEngine;

namespace Project.Screpts.SO
{
    [CreateAssetMenu(fileName = "PlayerCoins", menuName = "PlayerCoins")]
    public class PlayerCoins : ScriptableObject
    {
        [SerializeField] private int _playerCoins;

        public int Coins => _playerCoins;

        public void AddValue(int value)
        {
            _playerCoins = value;
        }

        public void RemoveValue(int value)
        {
            _playerCoins -= value;
        }

        public void Reset()
        {
            _playerCoins = 0;
        }
    }
}