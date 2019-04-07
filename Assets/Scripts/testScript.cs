using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
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
        //transform.Translate(new Vector3(xmove * _speed, ymove * _speed, 0));
        //transform.LookAt(new Vector3(mousePos.x, mousePos.y, 0));
    }
}
