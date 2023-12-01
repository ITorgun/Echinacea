namespace Assets.PlayableEntityModule
{
    public interface IMovable
    {
        public float Speed { get; }
        public float CurrentSpeed { get; }

        void DebaffSpeed(float speed);
        void ResetSpeed();
    }
}
