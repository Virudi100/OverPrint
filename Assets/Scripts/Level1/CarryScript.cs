using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryScript : MonoBehaviour
{
    [HideInInspector] public GameObject selectedGO;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MovingObject") || other.CompareTag("Crate"))
        {
            selectedGO = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MovingObject"))
        {
            selectedGO = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovingObject") || other.CompareTag("Crate"))
        {
            selectedGO = null;
        }
    }
}
