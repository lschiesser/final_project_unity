using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;


public class ExperimentManager : MonoBehaviour
{
    [Header("Experiment components")]
    public ArrayCreator arrayCreator;
    public ExperimentInstructions instructions;
    public ResponseDetection responses;

    private GameObject _target;
    
    [Header("Experiment variables")]
    private bool _finishedReading;
    private int _expcond1;
    private int _expcond2;
    private int _controlcond1;
    private int _controlcond2;
    private bool _endReached;
    private bool _presentTarget;
    private int _trialtype;
    public string targetname;
    private bool _correctAnsw;
    private float _startStimuliTime;
    private float _responseTime;
    private List<List<string>> _data;

    private List<string> _header;

    
    //initialize stuff
    public void Start()
    {
        _finishedReading = false;
        _expcond1 = 0;
        _expcond2 = 0;
        _controlcond1 = 0;
        _controlcond2 = 0;
        _endReached = false;
        _presentTarget = true;
        
        _data = new List<List<string>>();
        _header = new List<string>();
        _header.Add("target_distractor");
        _header.Add("response_time");
        _header.Add("condition");
        _header.Add("correctAnswer");
        instructions.ShowWelcomeMsg();
        
    }
    
    //add information about participants response, start new trial
    private void ExperimentInformation(int condition, bool answer)
    {
        List<string> taskData = new List<string>();
        _responseTime = Time.realtimeSinceStartup;
        taskData.Add(arrayCreator.GetInformation().ToString());
        taskData.Add((_responseTime - _startStimuliTime).ToString());
        taskData.Add(condition.ToString());
        taskData.Add(answer.ToString());
        _data.Add(taskData);
        
        Debug.Log("expinfo");
    }
    
    public int PrepareNextTrial()
    {
        _presentTarget = true;
        
        int rand = Random.Range(0, 4);
        //choose between 4 different conditions
        //limit amount of executions of each condition to 3; hence 16 trials in total 

        if (rand == 0 && _expcond1 < 4)
        {
            arrayCreator.BuildArray("fear",  "inanimate");
            _expcond1++;
            targetname = instructions.ShowPrompt(arrayCreator);
            
            Debug.Log("next before s");
            return rand; //to indicate which trial type we have (kinda redundant bc you can get that from GetInformation() but oh well....)
        } 
        else if (rand == 1 && _expcond2 < 4)
        {
            arrayCreator.BuildArray("fear",  "animate");
            _expcond2++;
            targetname = instructions.ShowPrompt(arrayCreator);
            
            Debug.Log("next before s");
            return rand; 
        } 
        else if (rand == 2 && _controlcond1 < 4)
        {
            arrayCreator.BuildArray("animate",  "inanimate");
            _controlcond1++;
            targetname = instructions.ShowPrompt(arrayCreator);
            
            Debug.Log("next before s");
            return rand; 
        }
        else if (rand == 3 && _controlcond2 < 4)
        {
            arrayCreator.BuildArray("inanimate",  "animate");
            _controlcond2++;
            targetname = instructions.ShowPrompt(arrayCreator);
            
            Debug.Log("next before s");
            return rand; 
        }
        else
        {
            _endReached = true;
            return 100; 
        }
    }

    public void StartNextTrial()
    {
        Debug.Log("VAR");
        instructions.HideTargetPrompt();
        _startStimuliTime = Time.realtimeSinceStartup;
        arrayCreator.ShowArray();
    }

    public void EndExperiment()
    {
        instructions.ShowGoodbyeMsg();
        List<string> csvLines = CsvTools.GenerateCsv(_data, _header);
        CsvTools.SaveFile(Application.dataPath+"/Data/"+System.Guid.NewGuid(), csvLines);
        //Application.Quit();
        // maybe add questionaire about snake phobia etc
        // create output file 
    }
    
    
    // Experiment with multiple trials
    void Update()
    {
        if (_finishedReading && _endReached == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _presentTarget)
            {
                StartNextTrial();
                _presentTarget = false;

            }
            if (responses.GetResponse() && _endReached == false)
            {
                arrayCreator.DestroyArray();
                responses.SetFalse();
                //check response to see if answer was correct
                string clickedobj = responses.CheckResponse();
                if (clickedobj == targetname)
                {
                    _correctAnsw = true;
                }
                else
                {
                    _correctAnsw = false;
                }
                //print(_correctAnsw);
                
                ExperimentInformation(_trialtype, _correctAnsw);
                _trialtype = PrepareNextTrial();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _finishedReading = true;
                instructions.HidePrompt();
                _trialtype = PrepareNextTrial();
            }
        }
        
        if (_endReached == true)
        {
            EndExperiment();
            Application.Quit();
        }
    } 
}


