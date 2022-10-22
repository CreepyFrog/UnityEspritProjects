using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;

    private Animator animator;
    private Rigidbody2D rb;
    public float speed, jumpSpeed, distToGround;
    private bool isCrouching, isHurt;
    private SpriteRenderer sr;
    private Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * speed;

        transform.Translate(hInput * Time.deltaTime, 0, 0);
        if (hInput > 0)
        {
            sr.flipX = false;
        }
        if (hInput < 0)
        {
            sr.flipX = true;
        }
        
        if (( Input.GetButtonDown("Jump") || ( Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0 ))
            && checkGrounded())
        {
            rb.AddForce(new Vector2(0f, rb.velocity.y + jumpSpeed));   
        }

        if ( Input.GetAxisRaw("Vertical") < 0 && checkGrounded())
        {
            isCrouching = true;
        }

        animator.SetFloat("speed", Mathf.Abs(hInput));
        animator.SetFloat("jumpSpeed", rb.velocity.y);
        animator.SetBool("isCrouching", true);
    }

    private bool checkGrounded()
    {
        float extraHeight = .05f;
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down, distToGround + extraHeight, groundMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(collider.bounds.center, Vector2.down * (distToGround + extraHeight), rayColor, groundMask);
        return raycastHit.collider != null;
    }
}
