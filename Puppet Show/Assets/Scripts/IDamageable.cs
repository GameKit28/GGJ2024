using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public enum DamageType
    {
        Intimidate,
        Disgust,
        Calm,
        Dazzle,
        Irritate
    }

    public void DealDamage(float damageAmmount, DamageType damageType);
}
