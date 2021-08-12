using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TMP_Text timeDisplay;
    public TMP_Text dateDisplay;


    public int hour;
    public int minutes;
    public int seconds;

    public int day;
    public int month;
    public int year;

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
        timeDisplay.text = "" + hour + ":" + minutes + ":" + seconds;

        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;
        dateDisplay.text = "" + day + "/" + month + "/" + year;
    }
}
