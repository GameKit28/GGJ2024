using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemAsset : ScriptableObject 
{
    [System.Serializable]
    public class DamageTypeToValueMap{
        public IDamageable.DamageType damageType;
        public float modifierValue;
    }

    public string puppetComponentName;
    public string puppetComponentDescription;
    public IBodyParts.BodyPart bodyPart;
    public Sprite sprite;
    public List<MovementStrategy> validMovementBehaviours;
    public List<TriggerStrategy> validTriggerBehaviours;
    public List<EffectStrategy> validEffectBehaviours;
    public List<DamageTypeToValueMap> constantModifiers;
    public List<DamageTypeToValueMap> percentageModifiers;
}