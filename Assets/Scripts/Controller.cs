using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public float WalkSpeed = 2.0f;
    public CharacterController controller;
    public float jumpForce = 30.0f;
    private bool isGrounded;
    public float Gravity = .01f;
    private float MovementY;
    private bool isCrouched;

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


        controller.Move(Movement); //moves the capsule according to the wasd input, activastes movement
        Movement.y = MovementY; // allowes jumping
        controller.Move(Movement * Time.deltaTime); //makes jumping framerate dependent 


        if (controller.isGrounded) //checks if character is on ground, if its true then allows jumping
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MovementY = jumpForce; //sets the y of the movement vector to the jumpforce value
            }
        }
        else //if in the air
        {
            MovementY -= Gravity; //if its in the air it will subtract gravity from the y constantly until it hits the groound
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && isCrouched == false) //if keycode down is leftshift and crouching is false
        {
            WalkSpeed = 8.5f; //increase walk speed (sprint)
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //if left shift is not being pressed down
        {
            WalkSpeed = 2.0f; //return the wallkspeed to its normal value
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) //if left ccontrol is pressed
            {
                isCrouched = true; //set iscrouched to true
                controller.height = 0.5f; //change the controller height to a lower value
                Debug.Log("Crouching");
            }

            if (Input.GetKeyUp(KeyCode.LeftControl)) //if left control is not being actively pressed down
            {
                isCrouched = false; //iscrouched is set to false
                controller.height = 2.0f; //controller height is set to its default vavlue
            }



        }

    }

