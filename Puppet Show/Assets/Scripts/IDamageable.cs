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
    private static Color intimidateColor = new Color(252f/255f, 107f / 255f, 3f / 255f);
    private static Color disgustColor = new Color(84f / 255f, 197f / 255f, 1f / 255f);
    private static Color calmColor = new Color(138f / 255f, 255f / 255f, 0);
    private static Color dazzleColor = new Color(88f / 255f, 226f / 255f, 255f / 255f);
    private static Color irritateColor = new Color(255f / 255f, 248f / 255f, 4f / 255f);

    public void DealDamage(float damageAmmount, DamageType damageType);
    public static Color GetColor(DamageType type)
    {
        Color returnColor = default(Color);
        switch (type)
        {
            case DamageType.Intimidate:
                returnColor = intimidateColor;
                break;
            case DamageType.Disgust:
                returnColor = disgustColor;
                break;
            case DamageType.Calm:
                returnColor = calmColor;
                break;
            case DamageType.Dazzle:
                returnColor = dazzleColor;
                break;
            case DamageType.Irritate:
                returnColor = irritateColor;
                break;
            default:
                returnColor = default(Color);
                break;
        }
        return returnColor;
    }
}
