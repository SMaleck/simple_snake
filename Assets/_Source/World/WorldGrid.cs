using Assets._Source.App;
using UnityEngine;

namespace Assets._Source.World
{
    public class WorldGrid : MonoBehaviour
    {
        [SerializeField] private Transform _snakeTransform;
        [SerializeField] private SpriteRenderer _snakeSprite;

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

        private Vector3 SnakePosition
        {
            get { return _snakeTransform.position; }
            set { _snakeTransform.position = value; }
        }

        private void Awake()
        {
            var playerElementSize = _snakeSprite.sprite.bounds.size;
            _gridCellSize = playerElementSize.x;
            
            _gridColumns = Mathf.RoundToInt(WorldConstants.WidthUnits / _gridCellSize);
            _gridRows = Mathf.RoundToInt(WorldConstants.HeightUnits / _gridCellSize);
        }

        private void Update()
        {
            var isDirty = false;
            var targetX = SnakePosition.x;
            var targetY = SnakePosition.y;

            // Out on LEFT
            if (SnakePosition.x < LeftBorder)
            {
                targetX = RightBorder - RepositionOffset;
                isDirty = true;
            }
            // Out on RIGHT
            else if (SnakePosition.x > RightBorder)
            {
                targetX = LeftBorder + RepositionOffset;
                isDirty = true;
            }
            // Out on TOP
            else if (SnakePosition.y > TopBorder)
            {
                targetY = BottomBorder + RepositionOffset;
                isDirty = true;
            }
            // Out on BOTTOM
            else if (SnakePosition.y < BottomBorder)
            {
                targetY = TopBorder - RepositionOffset;
                isDirty = true;
            }

            if (isDirty)
            {
                SnakePosition = new Vector3(targetX, targetY);
            }
        }
    }
}
