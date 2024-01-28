using UnityEngine;

[CreateAssetMenu]
public class Trigger_HitOtherPart : TriggerStrategy
{
    public IBodyParts.BodyPart OtherBodyPart;
    public float distanceThreshold = 0.5f;

    private Transform otherPartTransform;

    public override void Initialize(GameObject gameObject)
    {
        string gameObjectName;
        /*switch(OtherBodyPart){
            case IBodyParts.BodyPart.chest:
                gameObjectName = "torso"; break;
            case IBodyParts.BodyPart.rightShoulder:
                gameObjectName = "stick_upper_arm_front"; break;
            case IBodyParts.BodyPart.leftShoulder:
                gameObjectName = "stick_upper_arm_back"; break;
            case IBodyParts.BodyPart.rightForearm:
                gameObjectName = "stick_lower_arm_front"; break;
                case IBodyParts.BodyPart.leftForearm:
                gameObjectName = "stick_lower_arm_back"; break;
                case IBodyParts.BodyPart.leftHand:
                gameObjectName = "sword_hand (1)"; break;
                case IBodyParts.BodyPart.rightHand:
                gameObjectName = "tambarine_hand"; break;
            default:
                otherPartTransform = null;
            break;
        }*/
    }

    public override bool CheckConditionOnTick(GameObject gameObject)
    {
        /*Vector2 currentPosition = gameObject.transform.position;
        float a = currentPosition.x - relativePosition.x;
        float b = currentPosition.y - relativePosition.y;
        float c2 = (a * a) + (b * b);
        if(c2 <= squaredDistanceThreshold){
            //We're within the threshold, countdown
            countdownTimer -= RagdollPartBehaviour.TickFrequency;
            if(countdownTimer <= 0){
                return true;
            }
        }else
        {
            countdownTimer = timeRequired;
            relativePosition = currentPosition;
        }*/
        return false;
    }
}