﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
	public Camera m_Camera;

	private void Awake()
	{
		m_Camera = Camera.main;
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
			m_Camera.transform.rotation * Vector3.up);
	}
	//Orient the camera after all movement is completed this frame to avoid jittering
	void LateUpdate()
	{
		
		
		//transform.forward = new Vector3(transform.forward.x, tmp.y, tmp.z);
	}
}
