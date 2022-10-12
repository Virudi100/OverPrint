using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryScript : MonoBehaviour
{
    private Material baseMat;
    [SerializeField] private Material highlightMat;
    [HideInInspector] public GameObject selectedGO;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MovingObject"))
        {
            selectedGO = other.gameObject;
            baseMat = other.gameObject.GetComponent<MeshRenderer>().material;
            other.gameObject.GetComponent<MeshRenderer>().material = highlightMat;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MovingObject"))
        {
            selectedGO = null;
            other.gameObject.GetComponent<MeshRenderer>().material = baseMat;
            baseMat = null;
        }
    }
}
