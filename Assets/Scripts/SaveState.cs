using UnityEngine;

namespace DefaultNamespace
{
    public class SaveState
    {
        private Vector3 _velocityBall;
        private readonly Rigidbody _rigidbodyBall;

        public SaveState(Ball ball)
        {
            _rigidbodyBall = ball.GetComponent<Rigidbody>();
        }
    
        public void Save()
        {
            _velocityBall = _rigidbodyBall.velocity;
            _rigidbodyBall.velocity = Vector3.zero;
        }

        public void Load()
        {
            _rigidbodyBall.velocity = _velocityBall;
        }
    }
}