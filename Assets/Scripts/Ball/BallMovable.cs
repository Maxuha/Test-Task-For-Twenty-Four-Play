using DefaultNamespace;
using UnityEngine;

public class BallMovable : MonoBehaviour, IMovable
{
    private Rigidbody _rigidbody;
    private ITransformPosition _ballTransformPosition;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ballTransformPosition = GetComponent<BallTransform>();
    }

    public void Move(Vector3 target)
    {
        _rigidbody.AddForce(target * Time.deltaTime, ForceMode.Impulse);
    }

    public void StopMove()
    {
        _rigidbody.velocity = Vector3.zero;
        _ballTransformPosition.ResetTransform();
    }
}