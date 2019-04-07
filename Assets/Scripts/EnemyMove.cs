using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;
	public float attackDist = 1.0f;
	
	public LayerMask targetMask;
	public LayerMask obstacleMask;

	private bool _isShooting = false;
	public bool isAlive = true;
	//[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start()
	{
//		StartCoroutine("FindTargetsWithDelay", .2f);
	}

	private void Update()
	{
		if (isAlive)
		{
			FindVisibleTargets();
			if (visibleTargets.Count > 0)
			{
				if (!_isShooting)
					StartCoroutine(Shoot());
				MoveToTarget(visibleTargets[0].position);
			}
		}
		
	}

	private IEnumerator Shoot()
	{
		_isShooting = true;
		GetComponent<EnemyWeaponScript>().Shoot(visibleTargets[0].position);
		yield return new WaitForSeconds(0.5f);
		if (visibleTargets.Count > 0)
			StartCoroutine(Shoot());
		_isShooting = false;
	}
	
	private void MoveToTarget(Vector3 pos)
	{
		float dist = Vector3.Distance(transform.position, visibleTargets[0].position);
		Debug.Log(dist + " dist");
		if (attackDist < dist)
		{
			GetComponent<Rigidbody2D>().MovePosition((pos - transform.position).normalized * Time.deltaTime * 3 + transform.position);			
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
