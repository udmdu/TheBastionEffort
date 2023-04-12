using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    public PolygonCollider2D col;
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) {
           Physics2D.IgnoreCollision(collision.collider, col);
        }
    }
}
