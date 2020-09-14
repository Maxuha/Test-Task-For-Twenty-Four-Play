using System;
using DefaultNamespace;
using UnityEngine;

public class AIMovable : MonoBehaviour, IMovable
{
    private AITransform _aiTransform;
    private AIBaseStats _aiBaseStats;
    private Vector3 _targetPosition;

    public void Start()
    {
        _aiTransform = GetComponent<AITransform>();
        _aiBaseStats = GetComponent<AIBaseStats>();
    }

    public void Move(Vector3 target)
    {
        Vector3 currentPosition = _aiTransform.GetPosition();
        _targetPosition = target;
        _targetPosition.y = currentPosition.y;
        _targetPosition.z = currentPosition.z;
        currentPosition += (_targetPosition - currentPosition).normalized * (_targetPosition - currentPosition).magnitude * _aiBaseStats.Speed * Time.deltaTime;
        _aiTransform.ApplyPosition(currentPosition);
    }

    public void StopMove()
    {
        _aiTransform.ResetTransform();
    }
}