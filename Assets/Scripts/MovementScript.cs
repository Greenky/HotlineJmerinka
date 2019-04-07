using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xmove = Input.GetAxis("Horizontal") * Time.deltaTime;
        float ymove = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector2 newPos = new Vector3(xmove * _speed, ymove * _speed, 0) + transform.position;
        
        GetComponent<Rigidbody2D>().MovePosition(newPos);
        GetComponent<Rigidbody2D>().transform.eulerAngles = 
        new Vector3(0, 0,90 + (Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) 
        * Mathf.Rad2Deg));
    }
}
