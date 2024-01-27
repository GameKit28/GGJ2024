using UnityEngine;

[CreateAssetMenu]
public class Movement_Rotate : MovementStrategy
{
    public float rotationRate = 20;

    public override void DoMovementUpdate(GameObject gameObject){
        gameObject.transform.Rotate(Vector3.back, rotationRate * Time.deltaTime);
    }
}
