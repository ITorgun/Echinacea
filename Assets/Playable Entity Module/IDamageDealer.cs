namespace Assets.Playable_Entity_Module
{
    public interface IDamageDealer
    {
        public float Damage { get; }
        void DealDamage(IDamageable damageable);
    }
}
