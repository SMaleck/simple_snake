using System.Collections.Generic;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeManager : MonoBehaviour
    {
        [Header("Spawning")]
        [SerializeField] private SnakeElement _snakeElementPrefab;
        [SerializeField] private Vector2 _startPosition;

        [Header("Movement")]
        [Range(0.1f, 1f)]
        [SerializeField] private float _moveIntervalSeconds;
        [SerializeField] private InputComponent _inputComponent;

        private bool _isSetup = false;

        private List<SnakeElement> _snakeElements;
        private bool hasQueuedElement;
        private int _headIndex;
        private int _tailIndex;

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
            var head = AddElement(_startPosition);
            _headIndex = 0;
            _tailIndex = 0;

            var spriteRenderer = head.GetComponent<SpriteRenderer>();
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

            return _snakeElements[_headIndex];
        }

        public float GetSnakeSize()
        {
            if (!_isSetup) { Setup(); }

            return _snakeSize;
        }

        public void OnPickedUpFood()
        {
            hasQueuedElement = true;
        }

        public void OnCollidedWithSelf()
        {

        }

        private SnakeElement AddElement(Vector3 spawnPosition)
        {
            var snakeElement = SpawnAt(spawnPosition);
            snakeElement.SetSnakeManager(this);
            _snakeElements.Add(snakeElement);

            return snakeElement;
        }

        private SnakeElement SpawnAt(Vector3 spawnPosition)
        {
            var snakeElement = Instantiate(_snakeElementPrefab);
            snakeElement.gameObject.transform.position = spawnPosition;

            return snakeElement;
        }

        private void MoveElement()
        {
            var head = _snakeElements[_headIndex];
            var tail = _snakeElements[_tailIndex];

            var targetPosition = head.Position + (_snakeSize * _inputComponent.InputDirection);

            tail.Position = targetPosition;
            DecrementTailIndex();
        }

        private void DecrementTailIndex()
        {
            if (_tailIndex >= 0)
            {
                _tailIndex = _snakeElements.Count - 1;
                return;
            }

            _tailIndex--;
        }
    }
}
