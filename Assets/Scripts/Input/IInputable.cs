using UnityEngine;

namespace DefaultNamespace
{
    public interface IInputable
    {
        Vector2 GetDataFromInputDevice();
        bool IsKeyUp();
    }
}