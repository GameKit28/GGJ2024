using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShrimpProjectiles : MonoBehaviour, IScalable
{
    //spawns a collumn of rising bubbles from a random point on the stage


    public GameObject ShrimpProjectile;
    public float launchVelocity = 20f;
    public float launchVelocityRange = 5f;
    public float launchAngle = 190f;
    public float launchAngleRandomness = 10f;

    public float timeBetweenLaunchAttempt = 2f;
    private float timer;
    public float launchRate = 7;

    private int bubbleNumber = 0;

    private bool start = false;
    public void Scale(float strength)
    {
        launchRate = launchRate * (launchRate / (strength * launchRate));
        bubbleNumber = (int)(strength/4);
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

                //spawn a collumn of between 6 and 12 bubbles in succession

                //choose a random number of bubbles to spawn at y=0
                int numberOfBubbles = Random.Range(6, 12 + bubbleNumber);


                //choose a random integer between 0 and 100
                float randomValue = Random.Range(0, launchRate);
                //if the random integer is less than 1
                if (randomValue < 1)
                {
                    float x = Random.Range(-10f, 5f);
                    //spawn the bubbles
                    for (int i = 0; i < numberOfBubbles; i++)
                    {


                        //choose a random x-position 
                        
                        //choose a random angle
                        float angle = Random.Range(launchAngle - launchAngleRandomness, launchAngle + launchAngleRandomness);
                        //convert angle to radians
                        angle = angle * Mathf.Deg2Rad;
                        float activeLaunchVelocity = launchVelocity + Random.Range(-launchVelocityRange, launchVelocityRange);
                        //calculate the x and y components of the velocity
                        float xVelocity = Mathf.Cos(angle) * launchVelocity;
                        float yVelocity = Mathf.Sin(angle) * activeLaunchVelocity;
                        //spawn the bubble at y=0 with the random x-position
                        //this should not be relative to the parent object
                        GameObject shrimpProjectile = Instantiate(ShrimpProjectile, new Vector3(x, -5.5f, 0), Quaternion.identity);
                        //set the velocity of the bubble
                        shrimpProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);






                    }
                }


            }
        
        
      
        }
    }
}