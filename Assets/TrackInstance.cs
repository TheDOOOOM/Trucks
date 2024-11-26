using System.Collections.Generic;
using Project.Screpts;
using Services;
using SO;
using UnityEngine;

public class TrackInstance : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private List<Waypoint> _path;

    private Counter _counter;

    private void Start()
    {
        _counter = ServiceLocator.Instance.GetService<Counter>();
        _counter.AddCount();
        var truckInstance = Instantiate(_playerConfig.GetActiveTruck(), transform);
        truckInstance.transform.position = transform.position;
        truckInstance.SetPath(_path);
    }

    private void OnDrawGizmosSelected()
    {
        if (_path == null || _path.Count == 0)
            return;

        Gizmos.color = Color.green;

        for (int i = 0; i < _path.Count - 1; i++)
        {
            Gizmos.DrawLine(_path[i].transform.position, _path[i + 1].transform.position);
        }
    }
}