using Assets._Source.App;
using UnityEngine;

namespace Assets._Source.Snake
{
    public class InputComponent : MonoBehaviour
    {
        public Vector3 InputDirection { get; private set; }

        private void Start()
        {
            InputDirection = Vector2.up;
        }

        private void Update()
        {
            UpdateInputState();
        }

        private void UpdateInputState()
        {
            var xAxisInput = InputHelper.GetXAxis();
            var yAxisInput = InputHelper.GetYAxis();

            if (xAxisInput != 0)
            {
                InputDirection = Vector2.right * xAxisInput;
            }
            else if (yAxisInput != 0)
            {
                InputDirection = Vector2.up * yAxisInput;
            }
        }
    }
}
