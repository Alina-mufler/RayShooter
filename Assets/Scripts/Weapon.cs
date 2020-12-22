
using UnityEngine;

[System.Serializable]
public class Weapon : MonoBehaviour
{
    public string name = "pistol";
    public float damage = 5f;
    public float range = 100f;
    public float timeout = 0.2f;
    public string targetTags = "Enemy";
	private float curTimeout;
	public Camera camera;

	void Update()
	{
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(camera.transform.position);
		if (Physics.Raycast(ray, out hit))
		{
			if (Input.GetMouseButton(0))
			{
				
					if (hit.transform.CompareTag(targetTags))
					{
						curTimeout += Time.deltaTime;
						if (curTimeout > timeout)
						{
							curTimeout = 0;
							hit.transform.GetComponent<EnemyHealth>().AddDamage(damage);
						}
					}
				
			}
			else
			{
				curTimeout = timeout + 1;
			}
		}
	}

}

