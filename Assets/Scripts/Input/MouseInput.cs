using UnityEngine;

namespace DefaultNamespace
{
    public class MouseInput : IInputable
    {
        public Vector2 GetDataFromInputDevice()
        {
            if (Input.GetMouseButton(0))
                return Input.mousePosition;
            return Vector2.zero;
        }

        public bool IsKeyUp()
        {
            if (Input.GetMouseButtonUp(0))
                return true;
            return false;
        }
    }
}