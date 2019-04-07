using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public int bulletsNum;
    public GameObject bullet;
    private Rigidbody2D _rb;
    private bool isThrown = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rb.velocity.magnitude > 0.1f && isThrown == false)
        {
            Invoke("TriggerOn", 1.5f);
            isThrown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
            StartCoroutine(other.gameObject.GetComponent<EnemyMove>().Stan());
    }

    private void TriggerOn()
    {
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
