using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private Text timer;
    private bool isPlaying = true;
    private float time;
    private float time2;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();

    }

    private void Update()
    {
        if (isPlaying)
        {
            Clocking();
        }
    }

    private void Clocking()
    {
        time += Time.deltaTime;
        time2 = Mathf.Floor(time);
        timer.text = "Time: " + time2.ToString();
    }
}
