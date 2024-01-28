using UnityEngine;

[CreateAssetMenu]
public class Trigger_ChangeDirections : TriggerStrategy
{
    private float lastAngularVelocity = 0f;
    Rigidbody2D rigidbody2D;

    public override void Initialize(GameObject gameObject)
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        lastAngularVelocity = rigidbody2D.angularVelocity;
    }

    public override bool CheckConditionOnTick(GameObject gameObject)
    {
        float newAngularVelocity = rigidbody2D.angularVelocity;
        bool newIsPositive = newAngularVelocity >= 0;
        bool oldIsPositive = lastAngularVelocity >= 0;
        lastAngularVelocity = newAngularVelocity;
        return newIsPositive != oldIsPositive; //Fires if it used to be positive but is now negative or vise-versa
    }
}