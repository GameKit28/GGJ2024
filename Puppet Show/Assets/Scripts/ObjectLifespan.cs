using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifespan : MonoBehaviour
{
    [SerializeField] private float lifespan;
    private float timer;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}
