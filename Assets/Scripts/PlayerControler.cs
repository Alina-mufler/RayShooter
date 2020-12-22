
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControler : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lookSpeed = 3f;

    private PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * speed;

        playerMotor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f)*lookSpeed;

        playerMotor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSpeed;

        playerMotor.RotateCam(cameraRotation);
    }

}
