using Assets._Source.App;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class SnakeMovement : MonoBehaviour
    {
        private const float StepTimeSeconds = 0.5f;

        private int _directionY;
        private int _directionX;

        private bool MoveOnTimeStep
        {
            get { return _directionX != 0 || _directionY != 0; }
        }

        private float _elapsedTime;


        private void Update()
        {
            UpdateInputState();
            UpdateMovement();
        }

        private void UpdateInputState()
        {
            var xAxisInput = GetRoundedInput(InputConstants.XAxisInputName);
            var yAxisInput = GetRoundedInput(InputConstants.YAxisInputName);

            if (xAxisInput != 0)
            {
                _directionX = xAxisInput;
                _directionY = 0;
            }
            else if (yAxisInput != 0)
            {
                _directionX = 0;
                _directionY = yAxisInput;
            }
        }

        private int GetRoundedInput(string axisName)
        {
            var axisValue = Input.GetAxis(axisName);

            var absoluteAxisValue = Mathf.Abs(axisValue);

            if (absoluteAxisValue <= float.Epsilon)
            {
                return 0;
            }

            var directionalFactor = axisValue > 0 ? 1 : -1;

            return Mathf.CeilToInt(absoluteAxisValue) * directionalFactor;
        }

        private void UpdateMovement()
        {
            if (!MoveOnTimeStep)
            {
                Move();
                return;
            }

            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= StepTimeSeconds)
            {
                _elapsedTime = 0;
                Move();
            }
        }

        private void Move()
        {
            var position = transform.position;

            var nextX = position.x + (_directionX * WorldConstants.GridSize);
            var nextY = position.y + (_directionY * WorldConstants.GridSize);

            transform.position = new Vector3(nextX, nextY, position.z);
        }
    }
}
