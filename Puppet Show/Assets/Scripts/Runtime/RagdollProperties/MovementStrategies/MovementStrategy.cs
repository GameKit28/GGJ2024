using UnityEngine;

public abstract class MovementStrategy : ScriptableObject
{
    [SerializeField] public float strength;
    public abstract void DoMovementUpdate(GameObject gameObject);
    public virtual void Initialize(GameObject gameObject) {}
}