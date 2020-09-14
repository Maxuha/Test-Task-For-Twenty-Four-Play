using UnityEngine;

namespace DefaultNamespace
{
    public class EntityTransform
    {
        private readonly Camera _camera;
        private readonly BallBaseStats _ballBaseStats;
        private readonly BallTransform _ballTransform;
        private readonly IMovable _playerMovable;
        private readonly IMovable _ballMovable;
        private readonly IMovable _aiMovable;
        private readonly ITransformPosition _playerTransformPosition;
        private readonly IStretchable _arrowStretchable;

        private Vector3 _target3D;
        private Vector3 _direction;
        private float _force;
        

        public EntityTransform(Camera camera, Player player, Ball ball, Arrow arrow, AI ai)
        {
            _camera = camera;
            _playerTransformPosition = player.GetComponent<PlayerTransform>();
            _playerMovable = player.GetComponent<PlayerMovable>();
            _ballBaseStats = ball.GetComponent<BallBaseStats>();
            _ballMovable = ball.GetComponent<BallMovable>();
            _ballTransform = ball.GetComponent<BallTransform>();
            _arrowStretchable = arrow.GetComponent<ArrowScretchable>();
            _aiMovable = ai.GetComponent<AIMovable>();
        }

        public void Run(Vector2 target2D, bool isCanMoveBall)
        {
            DirectionScreenTo3D(target2D);
            CalculateDirection();
            CalculateForce();
            if (isCanMoveBall)
                _ballMovable.Move(_direction * _force);
            _playerMovable.Move(_target3D);
            _arrowStretchable.Scale(_force, _ballBaseStats.MAXForce);
            _arrowStretchable.Rotate(_playerTransformPosition.GetPosition());
            _aiMovable.Move(_ballTransform.GetPosition());
        }
        
        private void DirectionScreenTo3D(Vector2 target2D)
        {
            Ray ray = _camera.ScreenPointToRay(target2D); 
            _target3D = ray.origin + ray.direction * _camera.transform.position.y;
            _target3D.y = _playerTransformPosition.GetPosition().y;
        }
        
        private void CalculateDirection()
        {
            _direction = CalculateWithStartPosition().normalized;
        }

        private void CalculateForce()
        { 
            _force = CalculateWithStartPosition().magnitude * _ballBaseStats.KForce;
        }
        
        private Vector3 CalculateWithStartPosition()
        {
            Vector3 position = _playerTransformPosition.GetPosition();
            position.y = 0; 
            position.z = position.z - _ballTransform.StartPosition.z;
            return position;
        }

        public void ResetTransform()
        {
            _playerMovable.StopMove();
            _aiMovable.StopMove();
            _ballMovable.StopMove();
            _arrowStretchable.Stop();
        }
    }
}