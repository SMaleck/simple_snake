using UnityEngine;

namespace Assets._Source.App
{
    public static class WorldConstants
    {        
        private static float _cameraWidth;
        public static float WidthUnits
        {
            get
            {
                if (_cameraWidth <= 0)
                {
                    _cameraWidth = HeightUnits * Camera.main.aspect;
                }

                return _cameraWidth;
            }
        }

        private static float _cameraHeight;
        public static float HeightUnits
        {
            get
            {
                if (_cameraHeight <= 0)
                {
                    _cameraHeight = 2f * Camera.main.orthographicSize;
                }

                return _cameraHeight;
            }
        }
    }
}
