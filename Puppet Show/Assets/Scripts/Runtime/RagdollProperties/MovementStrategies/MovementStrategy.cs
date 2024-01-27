using UnityEngine;

public abstract class MovementStrategy : ScriptableObject
{
    public abstract void DoMovementUpdate(GameObject gameObject);
}