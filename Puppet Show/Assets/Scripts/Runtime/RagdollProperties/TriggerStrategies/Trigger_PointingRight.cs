using UnityEngine;

[CreateAssetMenu]
public class Trigger_PointingRight : TriggerStrategy
{
    public override bool CheckConditionOnTick(GameObject gameObject){
        //check to see if the GameObject is pointing very close to straight right

        //get the angle of the GameObject
        float angle = gameObject.transform.rotation.eulerAngles.z;
        if (angle > 170f && angle < 190f){
            return true;
        }

        return false;
    }
}
