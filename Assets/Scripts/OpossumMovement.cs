using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumMovement : MonoBehaviour
{
    Collider2D collider;
    private float extraDist = .1f, distToObstacle;
    [SerializeField] private float speed = 1, initialDirection = -1;
    [SerializeField] private LayerMask obstacleMask;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        distToObstacle = collider.bounds.extents.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(initialDirection * speed * Time.deltaTime,0f,0f);

        if ((obstacleLeft() && initialDirection < 0) || (obstacleRight() && initialDirection > 0))
        {
            initialDirection = -initialDirection;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    private bool obstacleLeft()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(collider.bounds.center, Vector2.left, distToObstacle + extraDist, obstacleMask);
        Color rayColor;
        if(rayHit.collider != null)
        {
            rayColor = Color.red;
        }
        else rayColor = Color.green;

        Debug.DrawRay(collider.bounds.center, Vector2.left * (distToObstacle + extraDist), rayColor, obstacleMask);
        return rayHit.collider != null;
    }

    private bool obstacleRight()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(collider.bounds.center, Vector2.right, distToObstacle + extraDist, obstacleMask);
        Color rayColor;
        if (rayHit.collider != null)
        {
            rayColor = Color.red;
        }
        else rayColor = Color.green;

        Debug.DrawRay(collider.bounds.center, Vector2.right * (distToObstacle + extraDist), rayColor, obstacleMask);
        return rayHit.collider != null;
    }
}
