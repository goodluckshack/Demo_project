using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    //[SerializeField] private float _rotationSpeed = 10f;

    private JoystickControl joystickControl;

    // Start is called before the first frame update
    void Start()
    {
        joystickControl = GameObject.FindGameObjectWithTag("Joystick").GetComponent<JoystickControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        float verticalInput = joystickControl.Vertical();
        float horizontalInput = joystickControl.Horizontal();


        if (verticalInput != 0f || horizontalInput != 0f)
        {
        
            Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;
            
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(0, 0, -targetAngle);
            
            float moveSpeed = Mathf.Max(Mathf.Abs(verticalInput), Mathf.Abs(horizontalInput)) * _moveSpeed * Time.deltaTime;
            
            Vector2 movement = movementDirection * moveSpeed;
            transform.position += (Vector3)movement;
        }
    }
}
