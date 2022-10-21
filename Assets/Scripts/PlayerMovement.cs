using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float speed, JumpSpeed;
    private bool isJumping, is
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal") * speed;
        float vInput = Input.GetAxis("Vertical") * JumpSpeed;
        animator.
    }
}
