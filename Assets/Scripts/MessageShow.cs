using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageShow : MonoBehaviour
{
    private TextMeshProUGUI thisMessage;

    private int timer;
    public static string message;
    public static bool displayMessage;
    private bool displayMessage2;
    // Start is called before the first frame update
    void Start()
    {
        thisMessage = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        thisMessage.text = "";

        if (displayMessage)
        {
            MessageTimer();
            thisMessage.text = message;
        }

        if (displayMessage2)
        {
            MessageTimer2();
            thisMessage.text = ScoreManager.hostages.ToString() + " hostages remain.";
        }
    }
    void MessageTimer()
    {
        timer++;

        if (timer > 1000)
        {
            timer = 0;
            displayMessage = false;
            displayMessage2 = true;
        }
    }

    void MessageTimer2()
    {
        timer++;

        if (timer > 1000)
        {
            timer = 0;
            displayMessage2 = false;
        }
    }
}
