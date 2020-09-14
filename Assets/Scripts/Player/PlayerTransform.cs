using DefaultNamespace;
using UnityEngine;

public class PlayerTransform : MonoBehaviour, ITransformPosition
{
    private readonly Vector3 _startPosition = new Vector3(0, 0.3f, -3);
    private readonly Vector3 _startRotation = Vector3.zero;
    private readonly Vector3 _startScale = new Vector3(0.6f, 0.6f, 0.6f);
    private Transform _thisTransform;

    private void Start()
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