using DefaultNamespace;
using UnityEngine;

public class PlayerMovable : MonoBehaviour, IMovable
{
        private ITransformPosition _playerTransformPosition;
        private Bound _bound;
    
        public void Start()
        {
            _playerTransformPosition = GetComponent<PlayerTransform>();
            _bound = new Bound(-2, 2, 0, -4);
        }

        public void Move(Vector3 target)
        {
            if (IsCanMove(target))
                _playerTransformPosition.ApplyPosition(target);
        }
    
        
        private bool IsCanMove(Vector3 target)
        {
            if (target.x > _bound.Left &&
                target.x < _bound.Right &&
                target.z > _bound.Back &&
                target.z < _bound.Front)
                return true;
            return false;
        }
        
        public void StopMove()
        {
            _playerTransformPosition.ResetTransform();
        }
}