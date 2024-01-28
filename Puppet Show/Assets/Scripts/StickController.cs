using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class StickController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 stickPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float movementLeanAngle;
    [SerializeField] private float maxLeanDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stickPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        stickPosition = Vector3.Lerp(stickPosition, targetPosition, Time.fixedDeltaTime * moveSpeed);
        rb.MovePosition(stickPosition);
        float leanAngle = (Mathf.Clamp( targetPosition.x - stickPosition.x,-maxLeanDistance, maxLeanDistance) / maxLeanDistance) * movementLeanAngle;

        rb.MoveRotation(Quaternion.Euler(new Vector3(0,0,leanAngle)));
    }

  
}
