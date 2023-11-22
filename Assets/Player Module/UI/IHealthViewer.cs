namespace Assets.Player_Module.UI
{
    public interface IHealthViewer
    {
        void SetInitialHealthValue(float value);
        void OnHealthChanged(float value);
    }
}
