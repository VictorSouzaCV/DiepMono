using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable, ISpawner {

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
    

	void Start()
    {
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

    public void SpawnItem()
    {
        int randomID = UnityEngine.Random.Range(0, BoxData.DropPool.Count);
        Instantiate(BoxData.DropPool[randomID], transform.position, BoxData.DropPool[randomID].transform.rotation);
        ScoreManager.Instance.GainScore(BoxData.Score);
    }

    public void Break()
    {
        SpawnItem();
        gameObject.SetActive(false);
    }
}
