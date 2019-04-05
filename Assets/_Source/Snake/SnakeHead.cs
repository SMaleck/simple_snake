﻿using Assets._Source.App;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeHead : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _snakeSprite;
        [SerializeField] private float _moveIntervalSeconds;

        private Vector2 _moveDirection = Vector2.up;
        private float _snakeSize = 1;
        private float _elapsedTime = 0;

        private void Start()
        {
            _snakeSize = _snakeSprite.sprite.bounds.size.x;
        }

        private void Update()
        {
            UpdateInputState();
            UpdateMovement();
        }

        private void UpdateInputState()
        {
            var xAxisInput = InputHelper.GetXAxis();
            var yAxisInput = InputHelper.GetYAxis();

            if (xAxisInput != 0)
            {
                _moveDirection = Vector2.right * xAxisInput;
            }
            else if (yAxisInput != 0)
            {
                _moveDirection = Vector2.up * yAxisInput;
            }
        }

        private void UpdateMovement()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _moveIntervalSeconds)
            {
                _elapsedTime = 0;

                var translateTarget = _moveDirection * _snakeSize;
                transform.Translate(translateTarget);
            }
        }
    }
}