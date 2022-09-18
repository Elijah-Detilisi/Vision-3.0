
namespace Vision.Services.ComputationServices
{
    public class ProximityEstimater
    {
        #region Instances
        private readonly double _controlDistance; 
        private readonly double _controlFaceWidth;
        private double _detectedFaceHeight;
        #endregion

        public ProximityEstimater()
        {
            _controlDistance = 30; //in centimeters
            _controlFaceWidth = 14.3;
            _detectedFaceHeight = 0.0;
        }

        #region Setters and Getters
        public double DetectedFaceWidth
        {
            set { _detectedFaceHeight = value; }
            get { return _detectedFaceHeight; }
            
        }
        #endregion

        #region Computations
        private double GetFocalLength(double detectedFaceWidth)
        {
            var focalLength = (_controlFaceWidth * _controlDistance) / detectedFaceWidth;
            return focalLength;
        }

        public double GetDistance(double detectedFaceWidth)
        {
            var distance = (_controlFaceWidth * GetFocalLength(detectedFaceWidth)) / detectedFaceWidth;
            return _controlDistance;
        }
        #endregion
    }
}
