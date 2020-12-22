using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private Rigidbody rigidbody;

    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 rotationCamera;
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void RotateCam(Vector3 _rotateCamera)
    {
        rotationCamera = _rotateCamera;
    }

    private void FixedUpdate()
    {
        PerformMove();
        PerformRotate();
    }

    void PerformMove()
    {
        if (velocity != Vector3.zero)
        {
            rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        }
    }
    void PerformRotate()
    {
        rigidbody.MoveRotation(rigidbody.rotation*Quaternion.Euler(rotation));
        if (camera != null)
            camera.transform.Rotate(-rotationCamera);
    }
}
