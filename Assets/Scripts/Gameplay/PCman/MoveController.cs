using Gameplay.Rails;
using UnityEngine;

namespace Gameplay.PCman
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private RailPoint currentPoint;
        [SerializeField] private RailPoint nextPoint;
        
        private int _nextDirection;
        private int _lastDirection;
        
        private int _left = -1;
        private int _right = 1;
        private int _up = 2;
        private int _down = -2;
        
        private float _speed;

        private Vector3 _currentPosition;
        private Vector3 _nextPosition;
        private Transform _cachedTransform;

        void Start()
        {
            _cachedTransform = transform;
            _currentPosition = currentPoint.transform.position;
            
            _speed = 2.1f;
        }

        void Update()
        {
            _nextPosition = nextPoint.transform.position;
            
            if (Input.anyKeyDown)
            {
                ChangeDirection();
            }
            
            Movement();
            _currentPosition = Vector3.MoveTowards(_currentPosition, _nextPosition, _speed * Time.deltaTime);
            _cachedTransform.position = _currentPosition;
        }

        private void MoveToDirection(int direction, RailPoint newNextPoint)
        {
            _lastDirection = direction;
            currentPoint = nextPoint;
            nextPoint = newNextPoint;
        }

        private void Movement()
        {
            if (_nextDirection == -1 && (Arrived() || _nextDirection == -_lastDirection))
                MoveToDirection(-1, nextPoint.Left);
            else if (_nextDirection == 2 && (Arrived() || _nextDirection == -_lastDirection))
                MoveToDirection(2, nextPoint.Up);
            else if (_nextDirection == 1 && (Arrived() || _nextDirection == -_lastDirection))
                MoveToDirection(1, nextPoint.Right);
            else if (_nextDirection == -2 && (Arrived() || _nextDirection == -_lastDirection))
                MoveToDirection(-2, nextPoint.Down);
        }

        private void ChangeDirection()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _nextDirection = _left;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _nextDirection = _up;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _nextDirection = _right;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _nextDirection = _down;
            }
        }

        private bool Arrived()
        {
            return Vector3.Distance(_currentPosition, _nextPosition) < 0.05f;
        }

        protected internal void Teleport(Portal portal)
        {
            currentPoint = portal.Teleport;
            nextPoint = portal.NextPoint;
            _currentPosition = currentPoint.transform.position;
            
            _cachedTransform.position = _currentPosition;
        }

        public void InvertDirection()
        {
            Debug.Log("Controles invertidos");
            
            _left = 1;
            _right = -1;
            _up = -2; 
            _down = 2;
        }

        public void UpdateCurrentPoint(RailPoint newCurrentPoint)
        {
            currentPoint = newCurrentPoint;
        }

        public RailPoint CurrentPoint
        {
            get => currentPoint;
            set => currentPoint = value;
        }

        public RailPoint NextPoint
        {
            get => nextPoint;
            set => nextPoint = value;
        }
    }
}