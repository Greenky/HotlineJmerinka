using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	
	public HPcomponent hp;
	
    void Start()
    {
		
		if (hp == null)
			hp = GetComponent<HPcomponent>();
	}

    void Update()
    {
        
    }
}
