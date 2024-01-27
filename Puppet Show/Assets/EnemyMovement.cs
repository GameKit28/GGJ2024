using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementMagnitude;
    [SerializeField] private float moveTime;
    [SerializeField] private float timeBetweenMovements;
    [SerializeField] private float timeBetweenMovementsVariability;
    [SerializeField] private float jumpForce;
    private float timeTillNextMovement;
    private float timer;
    private Rigidbody2D rb;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        SetUpNextMovement();
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= timeTillNextMovement)
        {
            StartCoroutine(Move());
            StartCoroutine(Jump());
            SetUpNextMovement();
        }
    }

    private void SetUpNextMovement()
    {
        timer = 0;
        timeTillNextMovement = timeBetweenMovements + Random.Range(-timeBetweenMovementsVariability, timeBetweenMovementsVariability);
    }

    private IEnumerator Move()
    {
        timer = 0;
        Vector3 distance = Vector3.zero;
        Vector3 origin = transform.position;
        while (timer < moveTime)
        {
            timer += Time.fixedDeltaTime;
            distance = Vector3.Lerp(distance, new Vector3(movementMagnitude,0,0), Time.fixedDeltaTime * (1f / moveTime));
            rb.MovePosition(origin - distance);
            yield return new WaitForFixedUpdate();
        }
       
    }
    private IEnumerator Jump()
    {
        bool midJump = true;
        float baseHeight = transform.position.y;
        float height = 0;
        Vector3 origin = transform.position;
        float velocity = jumpForce;
        float acceleration = -9.81f;
        while (midJump)
        {
            height += velocity * Time.fixedDeltaTime * (1f / moveTime);
            velocity += acceleration * Time.fixedDeltaTime * (1f / moveTime);
            Debug.Log(velocity);
            rb.MovePosition(origin + new Vector3(0,height, 0));
            if (transform.position.y < baseHeight)
            {
                rb.MovePosition(new Vector2(transform.position.x, baseHeight));
                midJump = false;
            }
            yield return new WaitForFixedUpdate();
            
        }
    }
}
