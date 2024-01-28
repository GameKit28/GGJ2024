using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWortProjectiles : MonoBehaviour, IScalable
{
    
    public GameObject WortProjectile;
    public float launchVelocity = 20f;
    public float launchAngle = 105f;
    public float launchAngleRandomness = 10f;
    public float timeBetweenLaunchAttempt = 0.25f;
    private float timer;
    public float launchRate = 7;
    private bool start = false;

    public void Scale(float strength)
    {
        launchRate = launchRate * (launchRate / (strength * launchRate));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!start)
        {
            if(timer > 1)
            {
                timer = 0;
                start = true;
            }
        }
        else
        {
            if (timer > timeBetweenLaunchAttempt)
            {
                timer = 0;

                //choose a random integer between 0 and 100
                float randomValue = Random.Range(0, launchRate);
                //if the random integer is less than 1
                if (randomValue < 1)
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
    }
}