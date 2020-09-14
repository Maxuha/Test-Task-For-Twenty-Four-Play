using UnityEngine;

public class Ball : MonoBehaviour
{
    private Ball _ball;
    private GameManager _gameManager;

    public GameManager GameManager
    {
        get => _gameManager;
        set => _gameManager = value;
    }

    public Ball CreateBall(GameManager gameManager)
    {
        if (_ball == null)
        {
            _ball = Instantiate(this);
            _ball.gameObject.AddComponent<BallBaseStats>();
            _ball.gameObject.AddComponent<BallMovable>();
            _ball.gameObject.AddComponent<BallTransform>();
            _ball.GameManager = gameManager;
        }
        return _ball;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        _gameManager.CheckCollider(other);
    }
}