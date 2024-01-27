using UnityEngine;

public class RagdollPartBehaviour : MonoBehaviour
{
    public static float TickFrequency = 0.1f;

    public MovementStrategy movementStrategy;
    public TriggerStrategy triggerStrategy;
    public EffectStrategy effectStrategy;

    private float nextTickCountdown = 0f;
    private bool triggerCurrentlyMet = false;

    void Start()
    {
        //This ensures that modifying the fields of strategies at runtime don't effect the asset.
        if(movementStrategy != null) movementStrategy = (MovementStrategy)ScriptableObject.CreateInstance(movementStrategy.GetType());
        if(triggerStrategy != null) triggerStrategy = (TriggerStrategy)ScriptableObject.CreateInstance(triggerStrategy.GetType());
        if(effectStrategy != null) effectStrategy = (EffectStrategy)ScriptableObject.CreateInstance(effectStrategy.GetType());
    }

    void Update(){
        //Perform our movement update.
        movementStrategy?.DoMovementUpdate(this.gameObject);

        //Countdown until our next tick. This may trigger multiple ticks in a single unity frame (which is desired).
        nextTickCountdown -= Time.deltaTime;
        while(nextTickCountdown <= 0){
            nextTickCountdown += TickFrequency;

            bool triggerMetThisTick = false;
            if(triggerStrategy != null){
                triggerMetThisTick = triggerStrategy.CheckConditionOnTick(this.gameObject);
            }

            //Call ActivateStart, ActivateOnTick, and ActivateEnd in that order if the respective conditions are met.
            if(triggerCurrentlyMet == false && triggerMetThisTick == true) effectStrategy?.ActivateStart(this.gameObject);
            if(triggerMetThisTick) effectStrategy?.ActivateOnTick(this.gameObject);
            if(triggerCurrentlyMet == true && triggerMetThisTick == false) effectStrategy?.ActivateEnd(this.gameObject);

            triggerCurrentlyMet = triggerMetThisTick;
        }
    }
}