using System.Collections.Generic;
using Project.Screpts.Interfaces;
using Project.Screpts.SO;
using Services;
using UnityEngine;

namespace Project.Screpts
{
    public class Truck : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _moveUP;
        [SerializeField] private Sprite _moveDowne;
        [SerializeField] private Sprite _moveLeft;
        [SerializeField] private Sprite _moveRight;
        [SerializeField] private int _addCoinsValue;
        [SerializeField] private PlayerCoins _playerCoins;

        private List<Waypoint> _path;
        private IMoveStrategy _moveStrategy;
        private bool _isMoving = false;
        private float _speed = 1f;
        private bool _moveForward = true;
        private int _currentWaypointIndex;
        private Vector3 _targetPosition;
        private Counter _counter;
        private Vector3 _direction;

        private void Start()
        {
            _counter = ServiceLocator.Instance.GetService<Counter>();
        }

        public void SetPath(List<Waypoint> path)
        {
            _path = path;
            _targetPosition = _path[_currentWaypointIndex + 1].transform.position;
            _direction = (_targetPosition - transform.position).normalized;
            UpdateSpriteDirection(_direction);
        }

        public void StartMoving()
        {
            if (_path != null && _path.Count > 0)
            {
                _isMoving = true;
                _moveForward = true;
            }
        }

        private void Update()
        {
            if (_isMoving)
            {
                Move();
            }
        }

        public void Move()
        {
            _direction = (_targetPosition - transform.position).normalized;
            UpdateSpriteDirection(_direction);
            transform.position += _direction * (_speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            {
                if (_moveForward)
                {
                    _currentWaypointIndex++;

                    if (_currentWaypointIndex >= _path.Count)
                    {
                        _counter.RemoveCount();
                        _playerCoins.AddValue(_addCoinsValue);
                        Destroy(gameObject);
                        return;
                    }

                    SetTargetPosition(_path[_currentWaypointIndex].transform.position);
                }
                else
                {
                    if (_currentWaypointIndex != 0)
                    {
                        _currentWaypointIndex--;
                        SetTargetPosition(_path[_currentWaypointIndex].transform.position);
                    }
                    else
                        _isMoving = false;
                }
            }
        }

        public void UpdateSpriteDirection(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            if (direction.x > 0 && direction.y > 0)
            {
                _spriteRenderer.sprite = _moveUP;
            }
            else if (direction.x < 0 && direction.y < 0)
            {
                _spriteRenderer.sprite = _moveDowne;
            }
            else if (direction.x > 0 && direction.y < 0)
            {
                _spriteRenderer.sprite = _moveLeft;
            }
            else if (direction.x < 0 && direction.y > 0)
            {
                _spriteRenderer.sprite = _moveRight;
            }
            else if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                _spriteRenderer.sprite = direction.x > 0 ? _moveRight : _moveLeft;
            }
            else
            {
                _spriteRenderer.sprite = direction.y > 0 ? _moveUP : _moveDowne;
            }
        }

        private void SetTargetPosition(Vector3 position)
        {
            _targetPosition = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Truck>(out var result))
            {
                _moveForward = false;
                _targetPosition = result.transform.position;
            }
        }

        public void HandleRayCastHit()
        {
            if (!_isMoving)
            {
                StartMoving();
            }
        }
    }
}