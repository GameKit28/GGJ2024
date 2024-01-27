using UnityEngine;

[CreateAssetMenu]
public class Movement_Jitter : MovementStrategy
{
    //randomly choose a direction to move in and a force to apply
    public override void DoMovementUpdate(GameObject gameObject){
        //choose a random direction
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

        //choose a random force
        float force = Random.Range(0f, 1f);

        //apply the force
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
