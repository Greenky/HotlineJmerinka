using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPcomponent : MonoBehaviour
{
	public float currentHP;
	public float maxHP;

	public void DoDamage(float dmg)
	{
		if (currentHP - dmg > 0)
		{
			currentHP -= dmg;
		}
		else
		{
			currentHP = 0;
			OnDeath();
		}

	}

	void OnDeath()
	{

	}
}
