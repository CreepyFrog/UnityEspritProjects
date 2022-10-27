using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private PlayerMovement playerM;
    private PlayerHealth playerH;
    private float safetyMargin = 0.01f;
    private void Start()
    {
        playerM = gameObject.GetComponent<PlayerMovement>();
        playerH = gameObject.GetComponent<PlayerHealth>();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 pPosMin = GetComponent<Collider2D>().bounds.min;
            Vector3 pPosMax = GetComponent<Collider2D>().bounds.max;
            var enemy = collision.gameObject;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if(contact.point.y < pPosMin.y + safetyMargin)
                {
                    var enemyH = enemy.GetComponent<EnemyHealth>();
                    enemyH.Damaged();

                    playerM.bounceUp(200f);
                }
                else
                {
                    if((contact.point.x > pPosMin.x + safetyMargin) || (contact.point.x < pPosMax.x + safetyMargin))
                    {
                        playerH.getDamaged(1);
                        playerM.bounceUp(200f);
                    }
                }
            }
        }
    }
}
