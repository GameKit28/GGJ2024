using UnityEngine;

public abstract class TriggerStrategy : ScriptableObject
{
    public abstract bool CheckConditionOnTick(GameObject gameObject);
    public virtual void Initialize(GameObject gameObject) {}
}
