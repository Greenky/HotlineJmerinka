using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;
	public float attackDist = 0.2f;
	public float speed = 10f;

	public LayerMask targetMask;
	public LayerMask obstacleMask;
	
	//[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start()
	{
		StartCoroutine("FindTargetsWithDelay", .2f);
	}


	IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
			/*if (visibleTargets.Count > 0)
			{
				Vector2 pos = new Vector2(visibleTargets[0].transform.position.x, visibleTargets[0].transform.position.y);
				MoveToTarget(attackDist, pos);
			}*/
		}
	}

	private void MoveToTarget(float stopDist, Vector2 pos)
	{
		float dist = Vector3.Distance(transform.position, visibleTargets[0].position);
		Debug.Log(dist + " dist");
		if (attackDist < dist)
		{
			GetComponent<Rigidbody2D>().MovePosition(pos*Time.deltaTime* speed);			
		}
	}

	void FindVisibleTargets()
	{
		
		visibleTargets.Clear();
		Vector2 pos = new Vector2(transform.position.x, transform.position.y);
		Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(pos, viewRadius, targetMask);
		Debug.Log("try to find " + targetsInViewRadius.Length);
		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle(-transform.up, dirToTarget) < viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(transform.position, target.position);

				if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
				{
					visibleTargets.Add(target);
					GetComponent<Rigidbody2D>().transform.eulerAngles =
			new Vector3(0, 0, 90 + (Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x)
			* Mathf.Rad2Deg));
				}
			}
		}
	}


	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad),0 );
	}
}
