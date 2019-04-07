using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPcomponent : MonoBehaviour
{
	public int currentHP =1;
	public int maxHP;

	public void DoDamage(int dmg)
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

	private void Start()
	{
		
	}

	public void OnDeath()
	{
		List<SpriteRenderer> parts = new List<SpriteRenderer>();
		parts.Add(GetComponent<SpriteRenderer>());
		SpriteRenderer[] sprites =  GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer sp in sprites)
		{
			parts.Add(sp);
		}
		foreach (SpriteRenderer sp in parts)
		{
			StartCoroutine(Blink(0.2f, 10, sp));
		}
		
	}
	IEnumerator Blink(float delay, int blinkCount, SpriteRenderer sp)
	{
		float timer = blinkCount * delay;
		float t = 0;

		while (t < timer)
		{
			t += delay;
			if (sp.color.a > 0.5)
				sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0.49f);
			else
				sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 1f);
			yield return new WaitForSeconds(delay);		
		}
		Destroy(gameObject);
	}
}
