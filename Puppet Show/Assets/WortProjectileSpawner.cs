using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WortProjectileSpawner : MonoBehaviour
{
    
    public GameObject WortProjectile;
    public float launchVelocity = 100f;
    public float launchAngle = 80f;
    public float launchAngleRandomness = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //choose a random integer between 0 and 100
        int randomInt = Random.Range(0, 1000);
        //if the random integer is less than 1
        if (randomInt < 1)
        {
            //spawn between one and three projectiles
            int healthDifferenceQuarter = Random.Range(1, 4);
            //for each projectile

           
            for (int i = 0; i < healthDifferenceQuarter; i++)
            {
                //spawn a projectile
                GameObject projectile = Instantiate(WortProjectile, transform.position, Quaternion.identity);
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
}