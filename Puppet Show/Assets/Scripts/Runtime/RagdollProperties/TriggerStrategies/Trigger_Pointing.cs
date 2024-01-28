using UnityEngine;

[CreateAssetMenu]
public class Trigger_Pointing : TriggerStrategy
{
    //takes in a GameObject, an angle, and a tolerance
    //returns true if the GameObject is pointing within the tolerance of the angle
    //returns false otherwise
    [SerializeField] float targetAngle;
    [SerializeField] float tolerance;

    public override bool CheckConditionOnTick(GameObject gameObject){

        //check to see if the GameObject is pointing very close to straight right

        //get the angle of the GameObject
        float angle = gameObject.transform.rotation.eulerAngles.z;
        if (angle > targetAngle - tolerance && angle < targetAngle + tolerance){
            return true;
        }

        return false;
    }
}
