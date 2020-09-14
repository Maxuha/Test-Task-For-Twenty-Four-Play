using System;
using DefaultNamespace;
using UnityEngine;

public class ArrowTransform : MonoBehaviour, ITransformPosition, ITransformRotation, ITransformScale
{
    private readonly Vector3 _startPosition = new Vector3(0, 0.65f,-4);
    private readonly Vector3 _startRotation = new Vector3(90, 0, 90);
    private readonly Vector3 _startScale = new Vector3(0.1f, 0.1f, 1);
    private Transform _thisTransform;

    public void Start()
    {
        _thisTransform = transform;
        ResetTransform();
    }
    
    public Quaternion GetRotation()
    {
        return _thisTransform.rotation;
    }

    public void ApplyRotation(Quaternion rotation)
    {
        rotation.eulerAngles = new Vector3(_startRotation.x, rotation.eulerAngles.y, rotation.eulerAngles.z);
        _thisTransform.rotation = rotation;
    }
    
    public void ResetRotation()
    {
        _thisTransform.rotation = Quaternion.Euler(_startRotation);
    }
    
    public Vector3 GetScale()
    {
        return _thisTransform.localScale;
    }

    public void ApplyScale(Vector3 scale)
    {
        _thisTransform.localScale = scale;
    }

    public void ResetScale()
    {
        _thisTransform.localScale = _startScale;
    }
    
    public Vector3 GetPosition()
    {
        return _thisTransform.position;
    }

    public void ApplyPosition(Vector3 position)
    {
        _thisTransform.position = position;
    }

    public void ResetPosition()
    {
        _thisTransform.position = _startPosition;
    }

    public void ResetTransform()
    {
        ResetPosition();
        ResetRotation();
        ResetScale();
    }
}