using UnityEngine;

namespace Assets._Source.App
{
    public static class InputHelper
    {
        public static int GetXAxis()
        {
            return GetRoundedInput(InputConstants.XAxisInputName);
        }

        public static int GetYAxis()
        {
            return GetRoundedInput(InputConstants.YAxisInputName);
        }

        private static int GetRoundedInput(string axisName)
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
    }
}
