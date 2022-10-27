using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Player collided with" + collision.gameObject.name);
    //    if (collision.gameObject.CompareTag("Enemy")){
    //        health--;
    //    }
    //}

    public void getDamaged(int damage)
    {
        health -= damage;
    }
}
