using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
    [SerializeField] private bool isDll = false;
    [SerializeField] private GameObject printingSchema;

    private void OnTriggerStay(Collider other)
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
        GameObject sdCard = Instantiate(printingSchema,new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z + 0.5f),Quaternion.identity);
        isDll = false;
    }
}
