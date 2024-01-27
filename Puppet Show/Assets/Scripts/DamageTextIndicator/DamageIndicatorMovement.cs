using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageIndicatorMovement : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private Vector2 offsetRange;
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private Vector2 initialVelocityRange;
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private float lifetime;
    private Vector3 velocity;
    private float timer;
    private bool setupComplete;
    private TextMeshPro text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (setupComplete)
        {
            transform.position = transform.position + velocity * Time.deltaTime;
            velocity += (Vector3)acceleration * Time.deltaTime;
            timer += Time.deltaTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, (lifetime - timer) / lifetime);
            if (timer >= lifetime)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetupMovement(Transform startingPos)
    {
        origin = startingPos;
        transform.position = origin.position + new Vector3(Random.Range(-offsetRange.x, offsetRange.x), Random.Range(-offsetRange.y, offsetRange.y));
        velocity = initialVelocity + new Vector2(Random.Range(-initialVelocityRange.x, initialVelocityRange.x), Random.Range(-initialVelocityRange.y, initialVelocityRange.y));
        setupComplete = true;
        text = GetComponent<TextMeshPro>();
    }
}
