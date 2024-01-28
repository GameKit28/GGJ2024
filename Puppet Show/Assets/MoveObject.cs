using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Vector2 targetPosition;
    [SerializeField] private float movementTime;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, timer / movementTime);
    }
}
