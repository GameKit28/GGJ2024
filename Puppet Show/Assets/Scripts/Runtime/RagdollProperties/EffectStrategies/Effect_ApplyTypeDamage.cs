using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Effect_ApplyTypeDamage : EffectStrategy
{
    public IDamageable.DamageType damageType = IDamageable.DamageType.Intimidate;
    public float damageAmount = 10f;
    public AudioClip damageSound;
    EnemyHealth enemyHealth;
    GameObject[] particleIndicators;

    bool enemyPresent = true;
    bool particleEmitterPresent = true;
    float modifiedDamage;

    public override void Initialize(GameObject gameObject)
    {
        

        if (particleIndicators == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("ParticleEmitter");
            if (enemies.Length > 0)
            {
                particleIndicators = enemies;
            }
            else
            {
                particleEmitterPresent = false;
            }
        }

        if(Inventory.Instance != null)
        {
            float runningConstantMod = 0;
            float runningMultiplierMod = 1f;
            foreach(var itemPart in Inventory.Instance.itemByBodyParts){
                //Const modifiers add
                if(itemPart.Value.constantModifiers != null){
                    foreach(var constMod in itemPart.Value.constantModifiers){
                        if(constMod.damageType == this.damageType) {
                            runningConstantMod += constMod.modifierValue;
                        }
                    }
                }

                //percentage Modifiers multiply
                if(itemPart.Value.percentageModifiers != null){
                    foreach(var constMod in itemPart.Value.percentageModifiers){
                        if(constMod.damageType == this.damageType) {
                            runningMultiplierMod *= constMod.modifierValue;
                        }
                    }
                }
            }
            modifiedDamage = (damageAmount + runningConstantMod) * runningMultiplierMod;
        }
        else
        {
            modifiedDamage = damageAmount;
        }
    }

    public override void ActivateOnTick(GameObject gameObject)
    {
        if (enemyHealth == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                enemyHealth = enemies[0].GetComponent<EnemyHealth>();
            }
            else
            {
                enemyPresent = false;
            }
        }
        if (enemyPresent)
        {
            enemyHealth.DealDamage(20, damageType);
        }

        if (particleEmitterPresent)
        {
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

            foreach (GameObject emitter in particleIndicators)
            {
                if (emitter.name == targetEmitterName)
                {
                    particleIndicator = emitter;
                    particleSystem = emitter.GetComponent<ParticleSystem>();
                    break;
                }
            }
            //Debug.Log(gameObject);
            particleIndicator.transform.position = gameObject.transform.position;
            particleSystem.emission.SetBurst(0, new ParticleSystem.Burst(0, new ParticleSystem.MinMaxCurve(damageAmount)));
            particleSystem.Play();
        }
        
        if(damageSound != null) AudioSource.PlayClipAtPoint(damageSound, gameObject.transform.position);
    }
}