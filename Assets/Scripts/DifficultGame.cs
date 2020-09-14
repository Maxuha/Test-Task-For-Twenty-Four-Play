namespace DefaultNamespace
{
    public class DifficultGame
    {
        public readonly int MaxLevel = 10;
        private int _level = 1;
        
        public int Level => _level;

        public int LevelUpAndGet()
        {
            if (_level < MaxLevel)
                _level++;
            return _level;
        }
    }
}