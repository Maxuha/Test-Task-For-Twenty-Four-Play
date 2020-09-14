using UnityEngine;

namespace DefaultNamespace
{
    public interface ITransformScale : ITransformable
    {
        Vector3 GetScale();
        void ApplyScale(Vector3 scale);
        void ResetScale();
    }
}