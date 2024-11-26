using Project.Screpts;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Truck _activeTrucl;

        public void SetActiveTruck(Truck truckPrefab)
        {
            _activeTrucl = truckPrefab;
        }

        public Truck GetActiveTruck()
        {
            return _activeTrucl;
        }
    }
}