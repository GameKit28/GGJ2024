using UnityEngine;

public abstract class EffectStrategy : ScriptableObject{
    public virtual void ActivateOnTick(GameObject gameObject){} //Called every tick while the trigger condition is met
    public virtual void ActivateStart(GameObject gameObject){} //Called the first tick when the trigger condition is met
    public virtual void ActivateEnd(GameObject gameObject){} //Called the first tick when the trigger condition goes from met to unmet
}