using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : MonoBehaviour
{

	public Rigidbody bullet;
    public Transform gunPoint;
    public int bulletSpeed = 10;
    public float timeout = 0.5f;
    private float curTimeout;
	
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			curTimeout += Time.deltaTime;
			if (curTimeout > timeout)
			{
				curTimeout = 0;
				Rigidbody bulletInstance = Instantiate(bullet, gunPoint.parent.parent) as Rigidbody;
				bulletInstance.transform.position = gunPoint.position + gunPoint.forward*2;
				bulletInstance.AddForce(gunPoint.forward * 10, ForceMode.Impulse);
				
			}
		}
		else
		{
			curTimeout = timeout + 1;
		}
	}
}
