namespace DiepMono.Utils
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        Damageable GetDamageComponent();
    } 
}
