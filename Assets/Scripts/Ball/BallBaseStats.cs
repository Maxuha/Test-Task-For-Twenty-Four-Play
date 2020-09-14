using System;
using UnityEngine;

public class BallBaseStats : MonoBehaviour
{
    private float _kForce = 80;
    private float _maxForce;

    public float KForce
    {
        get => _kForce;
        set
        {
            _kForce = value;
            CalculateMaxForce();
        }
    }

    public float MAXForce => _maxForce;

    public void Start()
    {
        CalculateMaxForce();
    }

    private void CalculateMaxForce()
    {
        _maxForce = _kForce * GetComponent<BallTransform>().StartPosition.z;
    }
}