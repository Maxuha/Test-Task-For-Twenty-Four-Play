using System;
using UnityEngine;

public class AI : MonoBehaviour
{
    private AI _ai;

    public AI CreateAI()
    {
        if (_ai == null)
        {
            _ai = Instantiate(this);
            _ai.gameObject.AddComponent<AIBaseStats>();
            _ai.gameObject.AddComponent<AIMovable>();
            _ai.gameObject.AddComponent<AITransform>();
        }
        return _ai;
    }
}