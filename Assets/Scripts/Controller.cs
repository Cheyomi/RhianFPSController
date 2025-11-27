using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public float WalkSpeed = 1.0f;
    public CharacterController controller;
    public float jumpForce = 20.0f;
    private bool isGrounded;
    public float Gravity = 1.0f;
    private float MovementY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting the wasd values
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        //making the wasd values into vectors.... whatever those are
        Vector3 MovementX = transform.forward * VerticalInput;
        Vector3 MovementZ = transform.right * HorizontalInput;

        //add them together!@!
        Vector3 Direction = (MovementX + MovementZ);
        Vector3 Movement = (Direction * WalkSpeed * Time.deltaTime);

        controller.Move(Movement);
        Movement.y = MovementY;
        controller.Move(Movement * Time.deltaTime);


        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("CharacterController is grounded");
                MovementY = jumpForce;
            }
        }
        else
        {
            MovementY -= Gravity;
        }

    }

}
