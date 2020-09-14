using UnityEngine;

namespace DefaultNamespace
{
    public interface ITransformRotation : ITransformable
    {
        Quaternion GetRotation();
        void ApplyRotation(Quaternion rotation);
        void ResetRotation();
    }
}