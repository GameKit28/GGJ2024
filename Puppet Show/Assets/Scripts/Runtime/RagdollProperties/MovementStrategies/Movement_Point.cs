using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
[CreateAssetMenu()]
public class Movement_Point : MovementStrategy
{
    [SerializeField] private float targetAngle;
    
    private Rigidbody2D rb;
    public override void DoMovementUpdate(GameObject gameObject)
    {
        if(rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        Quaternion currentRotation =  gameObject.transform.localRotation;
        Quaternion newRotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(new Vector3(0, 0, targetAngle)), strength * Time.fixedDeltaTime);
        rb.MoveRotation(newRotation);
        
        
    }
}
