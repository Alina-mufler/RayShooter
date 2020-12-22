using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (camera == null)
        {
            Debug.LogError("PlayerShoot: No camera");
            this.enabled = false;
        }
    }

    void Update()
    {
        if ( Input.GetButtonDown("Fire1"))
        {
            RaycastHit _hit; // вся инфа о выстреле
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out _hit, weapon.range, mask))
                print("We got into" + _hit.collider.name);
        }
    }

}
