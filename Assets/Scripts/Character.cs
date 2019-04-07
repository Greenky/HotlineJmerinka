using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public MoveComponent move;
	public HPcomponent hp;
	
    void Start()
    {
		if (move == null)
			move = GetComponent<MoveComponent>();
		if (hp == null)
			hp = GetComponent<HPcomponent>();
	}

    void Update()
    {
        
    }
}
