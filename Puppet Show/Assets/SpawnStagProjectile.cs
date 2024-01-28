using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStagProjectile : MonoBehaviour

    //Stag Princess shoots slightly seeking eyeball projectile on a sinuous path towards the right side of the screen
    //the projectile is spawned where the spawner is
    //the projectile has a rigidbody2d component
    //the projectile seeks
{
    public int launchRate = 500;

    public GameObject StagProjectile;
    public float launchVelocity = 10f;
    public float launchAngle = 170f;
    public float launchAngleRandomness = 35f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if a random integer is less than 1
        int randomInt = Random.Range(0, launchRate);
        if (randomInt < 1)
        {
            //spawn a projectile
            GameObject projectile = Instantiate(StagProjectile, transform.position, Quaternion.identity);
            //get the rigidbody of the projectile
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            //get the angle of the projectile
            float angle = launchAngle + Random.Range(-launchAngleRandomness, launchAngleRandomness);
            //get the x component of the angle
            float xComponent = Mathf.Cos(angle * Mathf.Deg2Rad);
            //get the y component of the angle
            float yComponent = Mathf.Sin(angle * Mathf.Deg2Rad);
            //set the velocity of the projectile
            projectileRigidbody.velocity = new Vector2(xComponent, yComponent) * launchVelocity;
        }

        
    }
}
