using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject TimerTextBox;
    float playingTime = 0;
    private void Update()
    {
        playingTime += Time.deltaTime;
        TimerTextBox.GetComponent<TMP_Text>().text = $"{Mathf.FloorToInt(playingTime / 60)}:{Mathf.FloorToInt(playingTime % 60)}";
    }
}
