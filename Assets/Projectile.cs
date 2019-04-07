using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy" || other.collider.tag == "Player")
        {
            // ubit
        }
        Destroy(gameObject);
    }
}
