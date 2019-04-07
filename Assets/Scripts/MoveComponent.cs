using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	public float speed;
	public bool moving;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
			moving = true;
		}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
		{
			moving = false;
		}

	}

}