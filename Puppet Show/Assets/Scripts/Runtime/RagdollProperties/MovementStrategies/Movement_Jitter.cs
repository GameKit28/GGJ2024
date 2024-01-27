using UnityEngine;

[CreateAssetMenu]
public class Movement_Jitter : MovementStrategy
{
    private Rigidbody2D rb;
    //randomly choose a direction to move in and a force to apply
    public override void DoMovementUpdate(GameObject gameObject){
        if(rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        //choose a random direction
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

        //choose a random force
        float force = Random.Range(-strength, strength);
        //apply the force
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
