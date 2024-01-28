using UnityEngine;

[CreateAssetMenu]
public class Trigger_Still : TriggerStrategy
{
    public float distanceThreshold = 20f;
    public float timeRequired = 0.5f;


    private float countdownTimer;
    private Vector2 relativePosition;
    private float squaredDistanceThreshold;

    public override void Initialize(GameObject gameObject)
    {
        squaredDistanceThreshold = distanceThreshold * distanceThreshold;
        relativePosition = gameObject.transform.position;
        countdownTimer = timeRequired;
    }

    public override bool CheckConditionOnTick(GameObject gameObject)
    {
        Vector2 currentPosition = gameObject.transform.position;
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
        }
        return false;
    }
}