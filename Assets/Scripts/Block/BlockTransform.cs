using DefaultNamespace;
using UnityEngine;

public class BlockTransform : MonoBehaviour, ITransformScale
{
    private readonly Vector3 _startRotation = Vector3.zero;
    private readonly Vector3 _startScale = new Vector3(1, 0.3f, 0.3f);
    private Transform _thisTransform;

    public void Start()
    {
        _thisTransform = transform;
        ResetTransform();
    }
    
    public void ResetTransform()
    { 
        ResetScale();
        _thisTransform.rotation = Quaternion.Euler(_startRotation);
        _thisTransform.localScale = _startScale;
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
}