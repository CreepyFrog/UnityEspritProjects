using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpossumMovement : MonoBehaviour
{
    Collider2D collider;
    private float extraDist = .01f, distToObstacle;
    [SerializeField] private float speed = 1, initialDirection = -1;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private LayerMask enemyMask;
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

        //if ((obstacleLeft() && initialDirection < 0) || (obstacleRight() && initialDirection > 0))
        //{
        //    initialDirection = -initialDirection;
        //    spriteRenderer.flipX = !spriteRenderer.flipX;
        //}

    }

    //private bool obstacleLeft()
    //{
    //    RaycastHit2D rayHitGround = Physics2D.Raycast(collider.bounds.center, Vector2.left, distToObstacle + extraDist, obstacleMask);
    //    return rayHitGround.collider != null;
    //}

    //private bool obstacleRight()
    //{
    //    RaycastHit2D rayHitGround = Physics2D.Raycast(collider.bounds.center, Vector2.right, distToObstacle + extraDist, obstacleMask);
    //    return rayHitGround.collider != null;
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.tag == "Enemy")
        {
            initialDirection = -initialDirection;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
