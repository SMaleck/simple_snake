using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeManager : MonoBehaviour
    {
        [Header("Spawning")]
        [SerializeField] private SnakeHead _snakeHeadPrefab;
        [SerializeField] private SnakeElement _snakeElementPrefab;
        [SerializeField] private Vector2 _startPosition;

        [Header("Movement")]
        [Range(0.1f, 1f)]
        [SerializeField] private float _moveIntervalSeconds;
        [SerializeField] private InputComponent _inputComponent;

        private bool _isSetup = false;

        private SnakeHead _snakeHead;
        private List<SnakeElement> _snakeElements;

        private bool _hasQueuedElement;
        private float _elapsedTime = 0;
        private float _snakeSize;

        private void Awake()
        {
            Setup();
        }

        private void Setup()
        {
            if (_isSetup) { return; }

            _snakeElements = new List<SnakeElement>();

            _snakeHead = Instantiate(_snakeHeadPrefab);
            _snakeHead.SetSnakeManager(this);
            var spriteRenderer = _snakeHead.GetComponent<SpriteRenderer>();
            _snakeSize = spriteRenderer.sprite.bounds.size.x;

            _isSetup = true;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _moveIntervalSeconds)
            {
                _elapsedTime = 0;
                MoveElement();
            }
        }

        public SnakeElement GetSnakeHead()
        {
            if (!_isSetup) { Setup(); }

            return _snakeHead;
        }

        public float GetSnakeSize()
        {
            if (!_isSetup) { Setup(); }

            return _snakeSize;
        }

        public void OnPickedUpFood()
        {
            _hasQueuedElement = true;
        }

        public void OnCollidedWithSelf()
        {
            // ToDo RESTART level
        }

        private SnakeElement AddElement()
        {
            var snakeElement = Instantiate(_snakeElementPrefab);
            _snakeElements.Add(snakeElement);

            return snakeElement;
        }

        private void MoveElement()
        {
            if (_hasQueuedElement)
            {
                AddElement();
                _hasQueuedElement = false;
            }

            var lastHeadPosition = _snakeHead.Position;
            var targetPosition = _snakeHead.Position + (_snakeSize * _inputComponent.InputDirection);
            _snakeHead.Position = targetPosition;

            MoveTailTo(lastHeadPosition);
        }

        private void MoveTailTo(Vector3 lastHeadPosition)
        {
            if (_snakeElements.Count <= 0)
            {
                return;
            }

            var tail = _snakeElements.Last();
            tail.Position = lastHeadPosition;

            _snakeElements.Insert(0, tail);
            _snakeElements.RemoveAt(_snakeElements.Count - 1);
        }
    }
}
