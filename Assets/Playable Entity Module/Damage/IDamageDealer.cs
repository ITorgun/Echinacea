namespace Assets.PlayableEntityModule
{
    public interface IDamageDealer
    {
        public float Damage { get; }
        void DealDamage(IDamageable damageable);
    }
}
