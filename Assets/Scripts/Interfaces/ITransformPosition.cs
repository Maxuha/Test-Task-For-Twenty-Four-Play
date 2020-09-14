using UnityEngine;

namespace DefaultNamespace
{
    public interface ITransformPosition : ITransformable
    {
        Vector3 GetPosition();
        void ApplyPosition(Vector3 position);
        void ResetPosition();
    }
}