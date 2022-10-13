using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float moveSpeed = 3f;
    private float rotationSpeed = 720f;
    [SerializeField] private CarryScript cScript;
    private bool isCarring = false;
    [SerializeField] private GameObject anchorCarry;
    private GameObject newPrefab;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vecticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, vecticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (cScript.selectedGO != null && cScript.selectedGO.CompareTag("MovingObject") && Input.GetKeyDown(KeyCode.E))
        {
            if (isCarring == false)
            {
                cScript.selectedGO.transform.SetParent(gameObject.transform);
                cScript.selectedGO.transform.position = anchorCarry.transform.position;
                cScript.selectedGO.GetComponent<Rigidbody>().useGravity = false;
                cScript.selectedGO.GetComponent<Rigidbody>().isKinematic = true;
                isCarring = true;
            }
            else if (isCarring == true)
            {
                cScript.selectedGO.GetComponent<Rigidbody>().useGravity = true;
                cScript.selectedGO.GetComponent<Rigidbody>().isKinematic = false;
                cScript.selectedGO.transform.parent = null;
                isCarring = false;
            }
        }
        else if (cScript.selectedGO != null && cScript.selectedGO.CompareTag("Crate") && Input.GetKeyDown(KeyCode.E))
        {
            if (isCarring == false)
            {
                newPrefab = Instantiate(cScript.selectedGO.GetComponent<ComposantCrate>().prefabGO, gameObject.transform.position, Quaternion.identity);
                newPrefab.transform.SetParent(gameObject.transform);
                newPrefab.transform.position = anchorCarry.transform.position;
                newPrefab.GetComponent<Rigidbody>().useGravity = false;
                newPrefab.GetComponent<Rigidbody>().isKinematic = true;
                isCarring = true;
            }
            else if (isCarring == true)
            {
                newPrefab.GetComponent<Rigidbody>().useGravity = true;
                newPrefab.GetComponent<Rigidbody>().isKinematic = false;
                newPrefab.transform.parent = null;
                isCarring = false;
            }
        }
    }
}
