using UnityEngine;

public class Player : MonoBehaviour
{
    private Player _player;

    public Player CreatePlayer()
    {
        if (_player == null)
        {
            _player = Instantiate(this);
            _player.gameObject.AddComponent<PlayerMovable>();
            _player.gameObject.AddComponent<PlayerTransform>();
        }
        return _player;
    }
}
