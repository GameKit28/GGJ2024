using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Effect_ApplyTypeDamage : EffectStrategy
{
    public IDamageable.DamageType damageType = IDamageable.DamageType.Intimidate;
    public float damageAmount = 10f;
    EnemyHealth enemyHealth;
    public override void ActivateOnTick(GameObject gameObject)
    {
        if(enemyHealth== null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length > 0 )
            {
                enemyHealth = enemies[0].GetComponent<EnemyHealth>();
            }
            else
            {
                gameObject.GetComponent<RagdollPartBehaviour>().enabled= false;
            }
        }
        enemyHealth.DealDamage(damageAmount, damageType);
        
    }
}