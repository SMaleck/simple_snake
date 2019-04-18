using Assets._Source.App;
using Assets._Source.Snake;
using UnityEngine;

namespace Assets._SourceV1
{
    public class WorldGridV1 : MonoBehaviour
    {
        [SerializeField] private SnakeHead _snakeHead;

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

        private Vector2 SnakePosition
        {
            get { return _snakeHead.gameObject.transform.position; }
            set { _snakeHead.gameObject.transform.position = value; }
        }


        private void Awake()
        {
            Setup();
        }

        private void Setup()
        {
            if (_isSetup) { return; }
            
            _gridCellSize = _snakeHead.GetSnakeSize();
            _gridColumns = Mathf.RoundToInt(WorldConstants.WidthUnits / _gridCellSize);
            _gridRows = Mathf.RoundToInt(WorldConstants.HeightUnits / _gridCellSize);

            _isSetup = true;
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
