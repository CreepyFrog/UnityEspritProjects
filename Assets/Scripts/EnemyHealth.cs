using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Collider2D collider;
    GameObject parent;
    Animator animator;
    [SerializeField] private float health = 1;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            parent.transform.localScale = new Vector3(1f, 0.3f, 1f);
            Destroy(parent);
        }
    }

    public void Damaged()
    {
        Debug.Log(health);
        health--;
    }
}
