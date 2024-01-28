using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Effect_ApplyTypeDamage : EffectStrategy
{
    public IDamageable.DamageType damageType = IDamageable.DamageType.Intimidate;
    public float damageAmount = 10f;
    EnemyHealth enemyHealth;
    GameObject particleIndicator;
    ParticleSystem particleSystem;
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
        if (particleIndicator == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("ParticleEmitter");
            if (enemies.Length > 0)
            {
                particleIndicator = enemies[0];
                particleSystem = particleIndicator.GetComponent<ParticleSystem>();
            }
            else
            {
                gameObject.GetComponent<RagdollPartBehaviour>().enabled = false;
            }
        }
        enemyHealth.DealDamage(damageAmount, damageType);
        particleIndicator.transform.position = gameObject.transform.position;
        particleSystem.Play();

        
        
    }
}