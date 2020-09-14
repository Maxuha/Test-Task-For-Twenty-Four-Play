using System;
using UnityEngine;

public class BlockBaseStats : MonoBehaviour
{
    private GameObject _blockGameObject;
    private bool _isVisible = true;

    public void Start()
    {
        _blockGameObject = gameObject;
    }

    public bool IsVisible
    {
        get => _isVisible;
        set
        {
            _isVisible = value;
            _blockGameObject.SetActive(_isVisible);
        }
    }
}