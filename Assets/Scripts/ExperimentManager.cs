using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExperimentManager : MonoBehaviour
{
    [Header("Experiment components")]
    public ArrayCreator arrayCreator;
    public ExperimentInstructions instructions;
    public ResponseDetection responses;
    
    [Header("Experiment variables")]
    private bool _finishedReading;
    private int _currentTaskNr;
    public int numberOfTasks;
    
    //public int numberOfBlocks;
    //private int _currentBlockNr;
    //private bool _isRunning;
    
    private float _startStimuliTime;
    private float _responseTime;
    private List<List<string>> _data;

    private List<string> _header;

    
    //initialize stuff
    public void Start()
    {
        _finishedReading = false;
        _currentTaskNr = 0;
        numberOfTasks = 3;
        
        //_currentBlockNr = 0;
        //_isRunning = false;
        
        _data = new List<List<string>>();
        _header = new List<string>();
        _header.Add("target_distractor");
        _header.Add("response_time");
        
        //_header.Add(("block_number"));
        //_header.Add("task_number");
        //_header.Add("condition");
        //_header.Add("correctAnswer");
        instructions.ShowWelcomeMsg();
    }
    
    //add information about participants response, start new trial
    private void ExperimentInformation(bool responded)
    {
        List<string> taskData = new List<string>();
        _responseTime = Time.realtimeSinceStartup;
        taskData.Add(arrayCreator.GetInformation().ToString());
        taskData.Add((_responseTime - _startStimuliTime).ToString());
        _data.Add(taskData);
        
        //taskData.Add(_currentBlockNr.ToString());
        //taskData.Add(_currentTaskNr.ToString());
       
        Debug.Log($"Time to answer: {_responseTime - _startStimuliTime}");
    }

    
    
    public void StartFirstTrial()
    {
        arrayCreator.BuildArray("fear", "inanimate");
        instructions.ShowPrompt();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instructions.HidePrompt();
            _startStimuliTime = Time.realtimeSinceStartup;
            arrayCreator.ShowArray();
            _currentTaskNr++;
        }
    }
    public void StartNextTrial()
    {
        arrayCreator.BuildArray("fear",  "inanimate");
        
        instructions.ShowPrompt();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("VAR");
            instructions.HidePrompt();
            _startStimuliTime = Time.realtimeSinceStartup;
            arrayCreator.ShowArray();
            _currentTaskNr++;
        }
    }
    
    
    
    // Experiment with multiple trials
    void Update()
    {
        // Let participant read instructions


        // start trials
        if (_finishedReading)
        {
            if (_currentTaskNr == 0)
            { 
                StartFirstTrial();
            }
                
            if (responses.GetResponse())
            {
                arrayCreator.DestroyArray();
                responses.SetFalse();
                ExperimentInformation(true);
                StartNextTrial();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _finishedReading = true;
                instructions.message.text = "";
            }
        }
        // add later multiple conditions with BuildArray("fear",  "animate") etc.
    } 
}


