using UnityEngine;

[CreateAssetMenu]
public class Effect_ApplyTypeDamage : EffectStrategy
{
    public IDamageable.DamageType damageType = IDamageable.DamageType.Intimidate;
    public float damageAmount = 10f;

    public override void ActivateOnTick(GameObject gameObject)
    {
        Debug.Log($"Applying {damageAmount} {damageType} damage to enemy.");
    }
}