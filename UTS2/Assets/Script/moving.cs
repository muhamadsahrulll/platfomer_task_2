using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan gerakan platform
    public float moveDistance = 10f; // Jarak maksimal platform akan bergerak

    private Rigidbody2D rb;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingToEnd = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        endPos = startPos + new Vector3(moveDistance, 0, 0);
    }

    void FixedUpdate()
    {
        // Pergerakan platform
        if (movingToEnd)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime));
            if (transform.position == endPos)
            {
                movingToEnd = false;
            }
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime));
            if (transform.position == startPos)
            {
                movingToEnd = true;
            }
        }
    }
}
