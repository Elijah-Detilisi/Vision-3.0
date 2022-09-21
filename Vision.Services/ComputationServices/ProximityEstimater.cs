
using System.Diagnostics;

namespace Vision.Services.ComputationServices
{
    public static class ProximityEstimater
    {
        #region Instances
        private static double _estimatedDistance = 0.0;
        private static double _detectedFaceWidth = 0.0;
        private static double _detectedBodyWidth = 0.0;

        private static readonly double _controlDistance = 30.0; 
        private static readonly double _controlFaceWidth = 41.3;
        #endregion

        #region Setter and Getter methods
        public static void SetDetectedFaceAndBodyWidth(double detectedFaceWidth, double detectedBodyWidth)
        {
            _detectedFaceWidth = detectedFaceWidth; 
            _detectedBodyWidth = detectedBodyWidth;

            CalculateEstimatedDistance();
        }

        public static double GetEstimatedProximityDistance()
        {
            var distanceValue = _estimatedDistance;
            _estimatedDistance = 0;

            return distanceValue;
        }
        #endregion

        #region Computations
        private static double GetFocalLength(double detectedFaceWidth)
        {
            var focalLength = (_controlFaceWidth * _controlDistance) / detectedFaceWidth;
            return focalLength;
        }

        private static void CalculateEstimatedDistance()
        {
            _estimatedDistance = (_controlFaceWidth * GetFocalLength(_detectedFaceWidth)) / 10;

            /*if (_detectedFaceWidth > 0)
            {
                _estimatedDistance = (_controlFaceWidth * GetFocalLength(_detectedFaceWidth)) / 10;
            }
            else
            {
                if (_detectedBodyWidth>0)
                {
                    _estimatedDistance = (_controlFaceWidth * GetFocalLength(_detectedBodyWidth)) / 2.5;
                }
            }*/
        }
        #endregion

        
    }
}
