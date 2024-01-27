using UnityEngine;

[CreateAssetMenu]
public class Trigger_PointingUp : TriggerStrategy
{
    public override bool CheckConditionOnTick(GameObject gameObject){
        //check to see if the GameObject is pointing very close to straight up

        //get the angle of the GameObject
        float angle = gameObject.transform.rotation.eulerAngles.z;
        if (angle > 80 && angle < 100){
            return true;
        }

        return false;
    }
}