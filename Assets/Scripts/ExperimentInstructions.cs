using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperimentInstructions : MonoBehaviour
{
    public TextMeshProUGUI message;

    public void ShowWelcomeMsg()
    {
        message.text = "Welcome!! Thank you for taking time to participate. In the following experiment you will " +
                       "be presented an object. You have 3 seconds to take a look at it. After that " +
                       "you will see an array with multiple objects. Your task is to find the object that " +
                       "you were presented prior and click on it. Try to make your responses as fast and as " +
                       "accurate as possible! If you feel ready to start the experiment, click the space bar.";
    }

    public void ShowPrompt()
    {
        message.text = "Search for: ";
    }

    public void HidePrompt()
    {
        message.text = "";
    }

    public void ShowGoodbyeMsg()
    {
        message.text = "That was it! Thank you for participating!";
    }
}
