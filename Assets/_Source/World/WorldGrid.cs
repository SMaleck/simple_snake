﻿using Assets._Source.App;
using Assets._Source.Snake;
using UnityEngine;

namespace Assets._Source.World
{
    public class WorldGrid : MonoBehaviour
    {
        [SerializeField] private SnakeManager _snakeManager;

        private bool _isSetup = false;
        
        private float _gridCellSize;
        private int _gridColumns;
        private int _gridRows;  

        private float HorizontalExtend
        {
            get { return ((float)_gridColumns / 2) * _gridCellSize; }            
        }

        private float VerticalExtend
        {
            get { return ((float)_gridRows / 2) * _gridCellSize; }
        }

        private float LeftBorder
        {
            get { return -HorizontalExtend; }
        }

        private float RightBorder
        {
            get { return HorizontalExtend; }
        }

        private float TopBorder
        {
            get { return VerticalExtend; }
        }

        private float BottomBorder
        {
            get { return -VerticalExtend; }
        }

        private float RepositionOffset
        {
            get { return _gridCellSize / 2; }
        }

        private void Awake()
        {
            Setup();
        }

        private void Setup()
        {
            if (_isSetup) { return; }
            
            _gridCellSize = _snakeManager.GetSnakeSize();
            _gridColumns = Mathf.RoundToInt(WorldConstants.WidthUnits / _gridCellSize);
            _gridRows = Mathf.RoundToInt(WorldConstants.HeightUnits / _gridCellSize);

            _isSetup = true;
        }

        private void Update()
        {
            var snakeHead = _snakeManager.GetSnakeHead();

            var isDirty = false;
            var targetX = snakeHead.Position.x;
            var targetY = snakeHead.Position.y;

            // Out on LEFT
            if (snakeHead.Position.x < LeftBorder)
            {
                targetX = RightBorder - RepositionOffset;
                isDirty = true;
            }
            // Out on RIGHT
            else if (snakeHead.Position.x > RightBorder)
            {
                targetX = LeftBorder + RepositionOffset;
                isDirty = true;
            }
            // Out on TOP
            else if (snakeHead.Position.y > TopBorder)
            {
                targetY = BottomBorder + RepositionOffset;
                isDirty = true;
            }
            // Out on BOTTOM
            else if (snakeHead.Position.y < BottomBorder)
            {
                targetY = TopBorder - RepositionOffset;
                isDirty = true;
            }

            if (isDirty)
            {
                snakeHead.Position = new Vector3(targetX, targetY);
            }
        }

        public Vector2 GetMinPosition()
        {
            if (!_isSetup) { Setup(); }

            return new Vector2(-HorizontalExtend, -VerticalExtend);
        }

        public Vector2 GetMaxPosition()
        {
            if (!_isSetup) { Setup(); }

            return new Vector2(HorizontalExtend, VerticalExtend);
        }
    }
}
