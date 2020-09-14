using UnityEngine;

namespace DefaultNamespace
{
    public interface IStretchable
    {
        void Scale(float currentForce, float maxForce);
        void Rotate(Vector3 target3D);
        void Stop();
    }
}