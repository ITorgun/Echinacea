namespace Assets.Playable_Entity_Module.Mover
{
    public interface ISpeediable
    {
        public float Speed { get; }
        public float CurrentSpeed { get; }

        void DebaffSpeed(float speed);
        void ResetSpeed();
    }
}
