using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Sensitivity = 2.0f;
    private float XRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock the cursor
        Cursor.visible = false; //make the cursor not visible
    }

    // Update is called once per frame
    void Update()
    {
        //getting the mouse inputs
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity;

        //convert the mouseY into camera rotation
        XRotation -= MouseY;

        //clamp is making it so the rotation cant go higher or lower
        //than these max and min values
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        //camera and movement are connected and not seperate
        //if you make it a  quaternoasfdinon, it will rotate and move the camera at
        //the same time
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        //transform.parent.rotate will make Mr.capsule rotate with the camera
        transform.parent.Rotate(Vector3.up * MouseX);

    }
}
