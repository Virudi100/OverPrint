using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
    private bool isDll;
    [SerializeField] private GameObject printingSchema;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && isDll == false)
        {
            Downloading();
            isDll = true;
        }
    }

    public void Downloading()
    {
        StartCoroutine(StartDownloading());
    }

    IEnumerator StartDownloading()
    {
        int i = 0;
        while(i < 5)
        {
            i++;
            yield return new WaitForSeconds(1);
        }
        isDll = false;
    }
}
