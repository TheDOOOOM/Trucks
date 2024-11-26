using System.Collections.Generic;
using Project.Screpts.Interfaces;
using UnityEngine;

namespace Project.Screpts.Move
{
    public class MoveRevers : IMoveStrategy
    {
        private Transform _transform;
        private Stack<Waypoint> _visitedWaypoints;
        private float _speed;
        private Vector3 _targePosition = Vector3.zero;

        public MoveRevers(Transform transform, Stack<Waypoint> visitedWaypoints, float speed)
        {
            _transform = transform;
            _visitedWaypoints = visitedWaypoints;
            _speed = speed;
        }

        public void Move()
        {
            if (_visitedWaypoints is null) return;

            if (_targePosition == Vector3.zero)
            {
                _targePosition = _visitedWaypoints.Peek().transform.position;
            }

            Vector3 direction = (_targePosition - _transform.position).normalized;
            _transform.position += direction * (_speed * Time.deltaTime);

            if (Vector3.Distance(_transform.position, _targePosition) < 0.1f)
            {
                _targePosition = Vector3.zero;
            }
        }

        public Stack<Waypoint> GetPassedPosition()
        {
            return null;
        }
    }
}