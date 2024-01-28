using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShrimpProjectiles : MonoBehaviour, IScalable
{
    //spawns a collumn of rising bubbles from a random point on the stage


    public GameObject ShrimpProjectile;
    public float launchVelocity = 20f;
    public float launchAngle = 190f;
    public float launchAngleRandomness = 10f;

    public float timeBetweenLaunchAttempt = 2f;
    private float timer;
    public float launchRate = 7;

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
        if(timer > timeBetweenLaunchAttempt )
        {
            timer = 0;

            //spawn a collumn of between 6 and 12 bubbles in succession

            //choose a random number of bubbles to spawn at y=0
            int numberOfBubbles = Random.Range(6, 12);
    

            //spawn the bubbles
            for (int i = 0; i < numberOfBubbles; i++)
            {


                //choose a random x-position 
                float x = Random.Range(-10, 5f);
                //choose a random angle
                float angle = Random.Range(launchAngle - launchAngleRandomness, launchAngle + launchAngleRandomness);
                //convert angle to radians
                angle = angle * Mathf.Deg2Rad;
                //calculate the x and y components of the velocity
                float xVelocity = Mathf.Cos(angle) * launchVelocity;
                float yVelocity = Mathf.Sin(angle) * launchVelocity;
                //spawn the bubble at y=0 with the random x-position
                //this should not be relative to the parent object
                GameObject shrimpProjectile = Instantiate(ShrimpProjectile, new Vector3(x, 0, 0), Quaternion.identity);
                //set the velocity of the bubble
                shrimpProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);






            }



        
        
      
        }
    }
}