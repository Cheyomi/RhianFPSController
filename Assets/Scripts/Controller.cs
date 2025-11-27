using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public float WalkSpeed = 1.0f;
    public CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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



    }
}
