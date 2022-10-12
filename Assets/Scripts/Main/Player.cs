using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float moveSpeed = 3f;
    private float rotationSpeed = 720f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vecticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, vecticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
