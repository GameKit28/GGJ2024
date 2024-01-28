using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Effect_ApplyTypeDamage : EffectStrategy
{
    public IDamageable.DamageType damageType = IDamageable.DamageType.Intimidate;
    public float damageAmount = 10f;
    EnemyHealth enemyHealth;
    GameObject[] particleIndicators;
    
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
        if (particleIndicators == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("ParticleEmitter");
            if (enemies.Length > 0)
            {
                particleIndicators = enemies;
            }
            else
            {
                gameObject.GetComponent<RagdollPartBehaviour>().enabled = false;
            }
        }
        enemyHealth.DealDamage(damageAmount, damageType);
        string targetEmitterName = "";
        GameObject particleIndicator = null;
        ParticleSystem particleSystem = null;
        switch (damageType)
        {
            case IDamageable.DamageType.Intimidate:
                targetEmitterName = "intimidateEmitter";
                break;
            case IDamageable.DamageType.Disgust:
                targetEmitterName = "disgustEmitter";
                break;
            case IDamageable.DamageType.Calm:
                targetEmitterName = "calmEmitter";
                break;
            case IDamageable.DamageType.Dazzle:
                targetEmitterName = "dazzleEmitter";
                break;
            case IDamageable.DamageType.Irritate:
                targetEmitterName = "irritateEmitter";
                break;
        }
        foreach(GameObject emitter in particleIndicators)
        {
            if(emitter.name == targetEmitterName)
            {
                particleIndicator = emitter;
                particleSystem = emitter.GetComponent<ParticleSystem>();
                break;
            }
        }
        //Debug.Log(gameObject);
        particleIndicator.transform.position = gameObject.transform.position;
        particleSystem.emission.SetBurst(0,new ParticleSystem.Burst(0,new ParticleSystem.MinMaxCurve(damageAmount)));
        particleSystem.Play();        
    }
}