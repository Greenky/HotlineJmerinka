using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        if (gameObject.name == "5(Clone)" || gameObject.name == "12(Clone)")
        {
            Invoke("DestroyAfter", 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy" || other.collider.tag == "Player")
        {
            other.collider.GetComponent<HPcomponent>().DoDamage(10);
        }
        if (gameObject)
            Destroy(gameObject);
    }

    private void DestroyAfter()
    {
        if (gameObject)
            Destroy(gameObject);
    }
}
