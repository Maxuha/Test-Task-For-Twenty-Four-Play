using UnityEngine;

public class Map : MonoBehaviour
{
    private Map _map;

    public Map CreateMap()
    {
        _map = Instantiate(this);
        return _map;
    }
}