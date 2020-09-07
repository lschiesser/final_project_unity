using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperimentInstructions : MonoBehaviour
{
    public TextMeshProUGUI message;
    private GameObject _target;

    public void ShowWelcomeMsg()
    {
        message.text = "Welcome!! Thank you for taking time to participate. In the following experiment you will " +
                       "be presented an object. Have a good look at it and press the space bar if you want to start the trial. After that " +
                       "you will see an array with multiple objects. Your task is to find the object that " +
                       "you were presented prior and click on it. Try to make your responses as fast and as " +
                       "accurate as possible! If you feel ready to start the experiment, click the space bar.";
    }

    public string ShowPrompt(ArrayCreator creator)
    {
        message.text = "Search for: ";
        _target = creator.ShowTarget();
        _target.transform.position = new Vector3(x:20, y:150, z:280);
        
        return _target.name; //to compare to what was actually clicked by participant
    }

    public void HidePrompt()
    {
        message.text = "";
    }

    public void HideTargetPrompt()
    {
        HidePrompt();
        Destroy(_target);
    }

    public void ShowGoodbyeMsg()
    {
        message.text = "That was it! Thank you for participating!";
    }
}
