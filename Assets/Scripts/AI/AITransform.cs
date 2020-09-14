using DefaultNamespace;
using UnityEngine;

public class AITransform : MonoBehaviour, ITransformPosition
{
    private readonly Vector3 _startPosition = new Vector3(0, 0.2f, 2);
    private readonly Vector3 _startRotation = Vector3.zero;
    private readonly Vector3 _startScale = new Vector3(0.6f, 0.3f, 0.3f);
    private Transform _thisTransform;

    public void Start()
    {
        _thisTransform = transform;
        ResetTransform();
    }

    public void ResetTransform()
    {
        ResetPosition();
        _thisTransform.rotation = Quaternion.Euler(_startRotation);
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
}