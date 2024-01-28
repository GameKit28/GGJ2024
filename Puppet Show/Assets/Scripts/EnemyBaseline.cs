using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyBaseline : ScriptableObject
{
    public Vector2 startingPos;
    public Vector2 damageIndicatorPosition;
    public Vector2 projectileSpawnerPosition;
    public Vector2 hitBoxSize;
    public IDamageable.DamageType preferedType;
    public Sprite EnemySprite;
    public GameObject ProjectileSpawner;
    private static float strengthHealthFactor = 250f;
    private static float statVariabilityFactor = 75f;
    public float[] GenerateStats(float strength)
    {
        float[] returnStats = new float[5];
        switch (preferedType)  //Circle of stats    - Inti - Dis - calm - dazz - irr -
        {
            case IDamageable.DamageType.Intimidate:
                returnStats = DistributeStats(1.00f * strength, 0.66f * strength , 0.33f * strength, 0.33f * strength, 0.66f * strength);
                break;
            case IDamageable.DamageType.Disgust:
                returnStats = DistributeStats(0.66f * strength, 1f * strength, 0.66f * strength, 0.33f * strength, 0.33f * strength);
                break;
            case IDamageable.DamageType.Calm:
                returnStats = DistributeStats(0.33f * strength, 0.66f * strength, 1.00f * strength, 0.66f * strength, 0.33f * strength);
                break;
            case IDamageable.DamageType.Dazzle:
                returnStats = DistributeStats(0.33f * strength, 0.33f * strength, 0.66f * strength, 1.00f * strength, 0.66f * strength);
                break;
            case IDamageable.DamageType.Irritate:
                returnStats = DistributeStats(0.66f * strength, 0.33f * strength, 0.33f * strength, 0.66f * strength, 1.00f * strength);
                break;
        }
        return returnStats;
    }

    private float[] DistributeStats(float intimidate, float disgust, float calm, float dazzle, float irritate)
    {
        float[] returnStats = new float[5];
        returnStats[0] = (intimidate * strengthHealthFactor) + ((1.33f - intimidate) * Random.Range(-statVariabilityFactor, statVariabilityFactor));
        returnStats[1] = (disgust * strengthHealthFactor) + ((1.33f - disgust) * Random.Range(-statVariabilityFactor, statVariabilityFactor));
        returnStats[2] = (calm * strengthHealthFactor) + ((1.33f - calm) * Random.Range(-statVariabilityFactor, statVariabilityFactor));
        returnStats[3] = (dazzle * strengthHealthFactor) + ((1.33f - dazzle) * Random.Range(-statVariabilityFactor, statVariabilityFactor));
        returnStats[4] = (irritate * strengthHealthFactor) + ((1.33f - irritate) * Random.Range(-statVariabilityFactor, statVariabilityFactor));
        return returnStats;
    }
}
