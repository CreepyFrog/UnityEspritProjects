using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{

    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    public float moveSpeed = 7;

    float angle, smoothInputMagnitude, smoothMoveVelocity;
    Vector3 velocity;

    private Rigidbody rb;
    private Animator animator;
    bool isIdle, isWalking, isAttacking, isDead;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isIdle = true;
        isWalking = false;
        isAttacking = false;
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        isIdle = true; isWalking = false; isAttacking = false; isDead = false;

        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        float inputMagnitude = inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);
        if (inputMagnitude > 0)
        {
            isIdle = false;
            isWalking = true;
            isAttacking = false;
            isDead = false;
        }

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;

        //if(Input.GetButton("Vertical"))
        //{
        //    transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, 0);
        //    animator.SetBool("isIdle", false);
        //    animator.SetBool("isWalking", true);
        //    animator.SetBool("isAttacking", false);
        //}
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isDead", isDead);
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
