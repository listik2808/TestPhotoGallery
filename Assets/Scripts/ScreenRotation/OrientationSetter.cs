using UnityEngine;

namespace Scripts.ScreenRotation
{
    public class OrientationSetter : MonoBehaviour
    {
        public enum Orientation
        {
            Portrait,
            LandscapeLeft,
            LandscapeRight,
        }

        public Orientation orientation;

        private void Start()
        {
            Application.targetFrameRate = 60;

            switch (orientation)
            {
                case Orientation.Portrait:
                    Screen.orientation = ScreenOrientation.Portrait;
                    Screen.orientation = ScreenOrientation.AutoRotation;

                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                    break;

                case Orientation.LandscapeLeft:
                case Orientation.LandscapeRight:
                    Screen.orientation = ScreenOrientation.LandscapeLeft;
                    Screen.orientation = ScreenOrientation.LandscapeRight;
                    Screen.orientation = ScreenOrientation.AutoRotation;

                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                    Screen.autorotateToLandscapeRight = Screen.autorotateToLandscapeLeft = true;
                    break;
            }
        }
    }
}