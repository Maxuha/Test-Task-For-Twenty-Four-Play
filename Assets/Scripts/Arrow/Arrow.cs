using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Arrow _arrow;

    public Arrow CreateArrow()
    {
        if (_arrow == null)
        {
            _arrow = Instantiate(this);
            _arrow.gameObject.AddComponent<ArrowBaseStats>();
            _arrow.gameObject.AddComponent<ArrowScretchable>();
            _arrow.gameObject.AddComponent<ArrowTransform>();
        }
        return _arrow;
    }
}