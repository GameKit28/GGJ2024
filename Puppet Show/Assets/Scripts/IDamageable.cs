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
    private static Color intimidateColor = new Color(255, 123, 0);
    private static Color disgustColor = new Color(84, 197, 1);
    private static Color calmColor = new Color(138, 255, 0);
    private static Color dazzleColor = new Color(88, 226, 255);
    private static Color irritateColor = new Color(255, 248, 4);

    public void DealDamage(float damageAmmount, DamageType damageType);
    public static Color GetColor(DamageType type)
    {
        return default(Color);
    }
}
