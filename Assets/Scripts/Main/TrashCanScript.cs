using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MovingObject") && other.gameObject.GetComponent<Rigidbody>().useGravity == true)
        {
            Destroy(other.gameObject);
        }
    }
}
