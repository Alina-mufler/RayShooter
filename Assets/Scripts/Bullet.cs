using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float damage = 1;
	public string targetTags ="Enemy";

	void OnTriggerEnter(Collider coll)
	{
		
			if (targetTags == coll.transform.tag)
			{
				coll.transform.GetComponent<EnemyHealth>().AddDamage(damage);
			Destroy(coll.gameObject);
			}
		
		Destroy(gameObject);
	}
}