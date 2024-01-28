using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveVelocity;
    [SerializeField] private Vector2 runVelocity;
    private Vector2 activeVelocity;
    [SerializeField] private float timeBetweenMovements;
    [SerializeField] private float timeBetweenMovementsVariability;
    [SerializeField] private float gravity;
    private float timer;
    private Rigidbody2D rb;
    private bool midJump = false;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        activeVelocity = moveVelocity;
        SetUpNextMovement();
    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0 && !midJump)
        {
            StartCoroutine(Move());
        }
    }

    private void SetUpNextMovement()
    {
        timer = timeBetweenMovements + Random.Range(-timeBetweenMovementsVariability, timeBetweenMovementsVariability);
    }

    private IEnumerator Move()
    {
        midJump = true;
        float floorHeight = transform.position.y;
        Vector2 velocity = activeVelocity;
        Vector2 acceleration = new Vector2(0, gravity);
        while (midJump)
        {
            rb.MovePosition(transform.position + (Vector3)velocity * Time.fixedDeltaTime);
            velocity += acceleration * Time.fixedDeltaTime;
            if(transform.position.y < floorHeight)
            {
                midJump = false;
                rb.MovePosition(new Vector3(transform.position.x, floorHeight, 0));
                SetUpNextMovement();
            }
            yield return new WaitForFixedUpdate();
        }
    }
    public void RunAway()
    {
        timeBetweenMovements = 0.25f;
        timeBetweenMovementsVariability = .1f;
        activeVelocity = runVelocity;
        SetUpNextMovement();
    }
}
