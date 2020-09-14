using System;
using DefaultNamespace;
using UnityEngine;

public class ArrowScretchable : MonoBehaviour, IStretchable
{
    private ITransformable _arrowTransformable;
    private ArrowBaseStats _arrowBaseStats;

    public void Start()
    {
        _arrowTransformable = GetComponent<ArrowTransform>();
        _arrowBaseStats = GetComponent<ArrowBaseStats>();
    }

    public void Scale(float currentForce, float maxForce)
    {
        float percentForce = currentForce * Util.MaxPercent / maxForce;
        float currentSize = _arrowBaseStats.MAXLength * percentForce / Util.MaxPercent;
        Vector3 size = new Vector3(currentSize, currentSize, 1);
        ((ITransformScale)_arrowTransformable).ApplyScale(size);
    }

    public void Rotate(Vector3 target3D)
    {
        ITransformPosition transformPosition = (ITransformPosition) _arrowTransformable;
        ITransformRotation transformRotation = (ITransformRotation) _arrowTransformable;
        Quaternion result = Quaternion.LookRotation(target3D - transformPosition.GetPosition(), Vector3.up);
        result.eulerAngles = new Vector3(0, result.eulerAngles.y + 90, 0);
        transformRotation.ApplyRotation(result);
    }

    public void Stop()
    {
        _arrowTransformable.ResetTransform();
    }
}