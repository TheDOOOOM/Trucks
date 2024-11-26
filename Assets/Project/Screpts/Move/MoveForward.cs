using System.Collections.Generic;
using Project.Screpts.Interfaces;
using UnityEngine;

namespace Project.Screpts.Move
{
    public class MoveForward : IMoveStrategy
    {
        private Transform _transform;
        private List<Waypoint> _path;
        private Stack<Waypoint> _pointsPassed = new();
        private int _currentWaypointIndex = 0;
        private float _speed;

        public void Move()
        {
            if (_currentWaypointIndex < 0 || _currentWaypointIndex >= _path.Count) return;

            Vector3 targetPosition = _path[_currentWaypointIndex].transform.position;
            Vector3 direction = (targetPosition - _transform.position).normalized;
            _transform.position += direction * (_speed * Time.deltaTime);
            if (Vector3.Distance(_transform.position, targetPosition) < 0.1f)
            {
                _pointsPassed.Push(_path[_currentWaypointIndex]);
                _currentWaypointIndex++;

                if (_currentWaypointIndex >= _path.Count)
                {
                    GameObject.Destroy(_transform.gameObject);
                }
            }
        }
    }
}