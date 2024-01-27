using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    
    [SerializeField] private float intimidate;
    [SerializeField] private float disgust;
    [SerializeField] private float calm;
    [SerializeField] private float dazzle;
    [SerializeField] private float irritate;

    [Header("Debug")]
    [SerializeField] private IDamageable.DamageType damageType;
    [SerializeField] private float ammountOfDamage;
    [SerializeField] private bool dealDamage;
    private void Update()
    {
        if(dealDamage)
        {
            dealDamage= false;
            DealDamage(ammountOfDamage, damageType);
        }
    }

    public void DealDamage(float damageAmmount, IDamageable.DamageType damageType)
    {
        switch (damageType)
        {
            case IDamageable.DamageType.Intimidate:
                DamageEnemy(damageAmmount,ref intimidate);
                break;
            case IDamageable.DamageType.Disgust:
                DamageEnemy(damageAmmount, ref disgust);
                break;
            case IDamageable.DamageType.Calm:
                DamageEnemy(damageAmmount, ref calm);
                break;
            case IDamageable.DamageType.Dazzle:
                DamageEnemy(damageAmmount, ref dazzle);
                break;
            case IDamageable.DamageType.Irritate:
                DamageEnemy(damageAmmount, ref irritate);
                break;
            default:
                break;
        }
    }
    private void DamageEnemy(float ammount, ref float healthPool)
    {
        healthPool -= Mathf.Abs(ammount);
        if(healthPool <= 0)
        {
            Debug.Log("Dead");
            //Insert Death Logic Here
        }
    }
}
