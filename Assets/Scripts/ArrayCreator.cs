using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCreator : MonoBehaviour
{
    public GameObject[] stimuliPrefabs;
    public GameObject arrayCube;

    private List<GameObject> fearInducing;
    private List<GameObject> animateControl;
    private List<GameObject> inanimateControl;

    private int cubeLength = 100;
    // Start is called before the first frame update
    void Start()
    {
        fearInducing = new List<GameObject>();
        animateControl = new List<GameObject>();
        inanimateControl = new List<GameObject>();
        
        initializeStimuli();

        int stepper = 0;
        for (var i = 0; i < stimuliPrefabs.Length; i++)
        {
            var tmp = i % 3;
            Debug.Log(i + " " + tmp);
            if (tmp == 0 && i > 0)
            {
                stepper++;
            }
            stimuliPrefabs[i].transform.position = new Vector3(cubeLength*stepper,cubeLength*tmp, 0);
            
            Debug.Log("Stepper: "+ stepper);
        }
    }
    
    // function called to initialize all important variables
    private void initializeStimuli()
    {
        foreach (var item in stimuliPrefabs)
        {
            if (item.CompareTag("fear"))
            {
                fearInducing.Add(item);
            } else if (item.CompareTag("animate"))
            {
                animateControl.Add(item);
            } else if (item.CompareTag("inanimate"))
            {
                inanimateControl.Add(item);
            }
        }   
    }
    
    // function that should choose stimuli based on input
    private void selectStimuli()
    {
        
    }
    
    // function building the search array
    private void buildArray()
    {
        
    }
    
    // function holding information about search array
    // e.g. position of target, target type, distractor type
    public void getInformation()
    {
        
    }
    
    // function that destroys (or makes inivisible) search array
}
