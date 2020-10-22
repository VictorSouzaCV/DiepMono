using DiepMono.Data;
using DiepMono.Managers;
using DiepMono.Utils;

namespace DiepMono.Boxes
{
    public class Spawner_Box : Spawner, IDamageable
    {

        public BoxData BoxData;
        Damageable damageComponent;
        public Damageable DamageComponent
        {
            get
            {
                if (damageComponent == null)
                    damageComponent = new Damageable(BoxData.MaxHealth);
                return damageComponent;
            }
        }

        void Awake()
        {
            ItemPool = BoxData.DropPool;
            damageComponent = new Damageable(BoxData.MaxHealth);
            damageComponent.OnDeath.AddListener(Break);
        }

        public void TakeDamage(float damage)
        {
            damageComponent.Damage(damage);
        }

        public Damageable GetDamageComponent()
        {
            return DamageComponent;
        }

        public override void Spawn()
        {
            base.Spawn();
            ScoreManager.Instance.GainScore(BoxData.Score);
        }

        public void Break()
        {
            Spawn();
            gameObject.SetActive(false);
        }
    } 
}
