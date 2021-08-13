/******************************************************************************
Author: Marcus

Name of Class: TimeDisplay

Description of Class: Display time and date in the menu UI.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    //get ui text
    public TMP_Text timeDisplay;
    public TMP_Text dateDisplay;

    //set time
    public int hour;
    public int minutes;
    public int seconds;

    //set date
    public int day;
    public int month;
    public int year;

    // Update is called once per frame
    void Update()
    {
        //set to actual time
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
        //show on text
        timeDisplay.text = "" + hour + ":" + minutes + ":" + seconds;

        //set to actual date
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;
        //show on text
        dateDisplay.text = "" + day + "/" + month + "/" + year;
    }
}
