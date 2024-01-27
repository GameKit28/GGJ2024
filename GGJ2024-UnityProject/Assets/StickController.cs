using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 stickPosition;
    [SerializeField] private float moveSpeed;
   
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
        stickPosition = Vector3.Lerp(stickPosition, targetPosition, Time.deltaTime * moveSpeed);
        rb.MovePosition(stickPosition);
    }

  
}
