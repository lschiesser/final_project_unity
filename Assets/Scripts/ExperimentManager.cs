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
        
        StartNextTrial();
    }

    
    
    public void StartFirstTrial()
    {
        _startStimuliTime = Time.realtimeSinceStartup;
        instructions.ShowPrompt();
        arrayCreator.BuildArray("fear",  "inanimate");
        _currentTaskNr++;
    }
    public void StartNextTrial()
    {
        _startStimuliTime = Time.realtimeSinceStartup;
        instructions.ShowPrompt();
        arrayCreator.BuildArray("fear",  "inanimate");
        _currentTaskNr++;
    }
    
    
    
    // Experiment with multiple trials
    void Update()
    {
        // Let participant read instructions
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _finishedReading = true;
            instructions.message.text = "";
        }
        if (!_finishedReading)
        {
            instructions.ShowWelcomeMsg();
        }

        
        // start trials
        if (_finishedReading)
        {
            if (_currentTaskNr == 0)
            { 
                StartFirstTrial();
            }
                
            if (responses._responded)
            {
                arrayCreator.DestroyArray();
                responses._responded = false;
                ExperimentInformation(true);

            }
        }
        // add later multiple conditions with BuildArray("fear",  "animate") etc.
    }
}
