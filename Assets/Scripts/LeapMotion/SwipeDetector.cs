using System;
using Leap;
using Leap.Unity;
using UnityEngine;

namespace LeapMotion
{
    public class SwipeDetector : Detector
    {
        public HandModelBase HandModel;
        public Finger.FingerType FingerName = Finger.FingerType.TYPE_INDEX;
        
        public float minimumDistance = 10;
        public SwipeDirection direction = SwipeDirection.Up;

        private Vector3 _previousPosition;
        private float _currentDistance = 0;

        private void OnDisable() => Deactivate();

        private void Update()
        {
            if (HandModel == null || !HandModel.IsTracked)
                return;

            Hand hand = HandModel.GetLeapHand();
            if (hand == null)
                return;

            int selectedFinger = SelectedFingerOrdinal();
            Vector3 currentPosition = hand.Fingers[selectedFinger].TipPosition.ToVector3();

            switch (direction)
            {
                case SwipeDirection.Up:
                    if (!(currentPosition.y >= _previousPosition.y))
                    {
                        _currentDistance = 0;
                        break;
                    }
                    _currentDistance += Math.Abs(currentPosition.y - _previousPosition.y);
                    break;
                case SwipeDirection.Down:
                    if (!(currentPosition.y <= _previousPosition.y))
                    {
                        _currentDistance = 0;
                        break;
                    }
                    _currentDistance += Math.Abs(currentPosition.y - _previousPosition.y);
                    break;
                case SwipeDirection.Left:
                    if (!(currentPosition.x <= _previousPosition.x))
                    {
                        _currentDistance = 0;
                        break;
                    }
                    _currentDistance += Math.Abs(currentPosition.x - _previousPosition.x);
                    break;
                case SwipeDirection.Right:
                    if (!(currentPosition.x >= _previousPosition.x))
                    {
                        _currentDistance = 0;
                        break;
                    }
                    _currentDistance += Math.Abs(currentPosition.x - _previousPosition.x);
                    break;
            }
            
            if (_currentDistance >= minimumDistance)
                Activate();
            else 
                Deactivate();
            
            _previousPosition = currentPosition;
        }

        private int SelectedFingerOrdinal(){
            switch(FingerName){
                case Finger.FingerType.TYPE_INDEX:
                    return 1;
                case Finger.FingerType.TYPE_MIDDLE:
                    return 2;
                case Finger.FingerType.TYPE_PINKY:
                    return 4;
                case Finger.FingerType.TYPE_RING:
                    return 3;
                case Finger.FingerType.TYPE_THUMB:
                    return 0;
                default:
                    return 1;
            }
        }
    }
}