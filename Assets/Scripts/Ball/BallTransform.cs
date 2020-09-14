using DefaultNamespace;
using UnityEngine;

public class BallTransform : MonoBehaviour, ITransformPosition
{
    private readonly Vector3 _startPosition = new Vector3(0, 0.25f, -4);
    private readonly Vector3 _startRotation = Vector3.zero;
    private readonly Vector3 _startScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Transform _thisTransform;

    public Vector3 StartPosition => _startPosition;

    public void Start()
    {
        _thisTransform = transform;
        ResetTransform();
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
        _thisTransform.rotation = Quaternion.Euler(_startRotation);
        _thisTransform.localScale = _startScale;
    }
}