using UnityEngine;

[CreateAssetMenu]
public class Trigger_AlwaysActive : TriggerStrategy
{
    public override bool CheckConditionOnTick(GameObject gameObject){
        return true;
    }
}
