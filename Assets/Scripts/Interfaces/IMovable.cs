using UnityEngine;

namespace DefaultNamespace
{
    public interface IMovable
    {
        void Move(Vector3 target);
        void StopMove();
    }
}