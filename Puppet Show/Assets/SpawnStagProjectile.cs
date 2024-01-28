using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStagProjectile : MonoBehaviour, IScalable

    //Stag Princess shoots slightly seeking eyeball projectile on a sinuous path towards the right side of the screen
    //the projectile is spawned where the spawner is
    //the projectile has a rigidbody2d component
    //the projectile seeks
{
    public float launchRate = 8;
    public float timeBetweenLaunchAttempt = 0.25f;
    public GameObject StagProjectile;
    public float launchVelocity = 10f;
    public float launchAngle = 170f;
    public float launchAngleRandomness = 35f;
    private float timer;
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
            if (timer > 1)
            {
                timer = 0;
                start = true;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenLaunchAttempt)
            {
                timer = 0;
                //check to see if a random integer is less than 1
                float randomValue = Random.Range(0f, launchRate);
                if (randomValue < 1)
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
        
    }
}
