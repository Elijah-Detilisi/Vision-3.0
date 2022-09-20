
namespace Vision.Services.ComputationServices
{
    public static class ProximityEstimater
    {
        #region Instances
        private static double _estimatedDistance = 0.0;
        private static readonly double _controlDistance = 30.0; 
        private static readonly double _controlFaceWidth = 41.3;
        #endregion

        #region Computations
        private static double GetFocalLength(double detectedFaceWidth)
        {
            var focalLength = (_controlFaceWidth * _controlDistance) / detectedFaceWidth;
            return focalLength;
        }

        public static void SetEstimatedDistance(double detectedFaceWidth)
        {
            _estimatedDistance = (_controlFaceWidth * GetFocalLength(detectedFaceWidth))/10;
        }
        #endregion

        public static double GetEstimatedFaceDistance()
        {
            var distanceValue = _estimatedDistance;
            _estimatedDistance = 0;

            return distanceValue;
            
        }
    }
}
