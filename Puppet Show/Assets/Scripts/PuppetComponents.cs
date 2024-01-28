using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuppetComponents : MonoBehaviour
{
    public string puppetComponentName;
    public string puppetComponentDescription;
    public IBodyParts.BodyPart bodyPart;
    public Sprite sprite;
    public MovementStrategy movementStrategy;
    public TriggerStrategy triggerStrategy;
    public EffectStrategy effectStrategy;
    public List<ItemAsset.DamageTypeToValueMap> constantModifiers;
    public List<ItemAsset.DamageTypeToValueMap> percentageModifiers;

    public void ApplyPropertiesToUI(GameObject uiObject)
    {
        uiObject.GetComponent<Image>().sprite = sprite;
    } 
}
