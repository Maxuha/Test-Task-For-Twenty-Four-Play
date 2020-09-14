namespace DefaultNamespace
{
    public struct Bound
    {
        private float _left;
        private float _right;
        private float _front;
        private float _back;

        public Bound(float left, float right, float front, float back)
        {
            this._left = left;
            this._right = right;
            this._front = front;
            this._back = back;
        }

        public float Left
        {
            get => _left;
            set => _left = value;
        }

        public float Right
        {
            get => _right;
            set => _right = value;
        }

        public float Front
        {
            get => _front;
            set => _front = value;
        }

        public float Back
        {
            get => _back;
            set => _back = value;
        }
    }
}