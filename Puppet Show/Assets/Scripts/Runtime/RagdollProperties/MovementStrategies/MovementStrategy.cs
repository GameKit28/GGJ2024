using UnityEngine;

public abstract class MovementStrategy : ScriptableObject
{
    [SerializeField] protected float strength;
    public abstract void DoMovementUpdate(GameObject gameObject);
}