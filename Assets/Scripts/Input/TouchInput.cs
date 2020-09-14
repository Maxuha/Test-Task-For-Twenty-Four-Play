using UnityEngine;

namespace DefaultNamespace
{
    public class TouchInput : IInputable
    {
        public Vector2 GetDataFromInputDevice()
        {
            Touch touch = Input.GetTouch(0);
            if (Input.touchCount == 1)
                if (touch.phase == TouchPhase.Moved)
                    return touch.position;
            return Vector2.zero;
        }

        public bool IsKeyUp()
        {
            if (Input.touchCount == 1)
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    return true;
            return false;
        }
    }
}