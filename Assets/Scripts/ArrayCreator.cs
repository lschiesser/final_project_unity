﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrayCreator : MonoBehaviour
{
    public GameObject[] stimuliPrefabs;
    public GameObject arrayCube;

    private List<GameObject> fearInducing;
    private List<GameObject> animateControl;
    private List<GameObject> inanimateControl;
    private GameObject _distractor;
    private GameObject _target;

    private int cubeLength = 100;

    // Start is called before the first frame update
    void Start()
    {
        fearInducing = new List<GameObject>();
        animateControl = new List<GameObject>();
        inanimateControl = new List<GameObject>();
        _distractor = new GameObject();
        _target = new GameObject();
        
        InitializeStimuli();
        
    }
    

    // function called to initialize all important variables
    private void InitializeStimuli()
    {
        foreach (var item in stimuliPrefabs)
        {
            if (item.CompareTag("fear"))
            {
                fearInducing.Add(item);
            }
            else if (item.CompareTag("animate"))
            {
                animateControl.Add(item);
            }
            else if (item.CompareTag("inanimate"))
            {
                inanimateControl.Add(item);
            }
        }
    }

    // function that should choose stimuli based on input
    private void SelectStimuli(string targetId, string distractorId)
    {
        _target = CompareId(targetId);
        _distractor = CompareId(distractorId);
    }

    private GameObject CompareId(string id)
    {
        switch (id)
        {
            case "fear":
                return fearInducing[Random.Range(0, fearInducing.Count)];
            case "animate":
                return animateControl[Random.Range(0, animateControl.Count)];
            case "inanimate":
                return inanimateControl[Random.Range(0, inanimateControl.Count)];
            default:
                throw new Exception("Couldn't find stimulus by ID. Please check ID");
        }
    }

    // function building the search array
    public void BuildArray(string targetId, string distractorId)
    {
        SelectStimuli(targetId, distractorId);
    }

    // return current target 
    public GameObject ShowTarget()
    {
        GameObject target = Instantiate(_target);
        print(target.name); 
        return target;
    }
    

    public void ShowArray()
    {
        List<GameObject> searchArray = Enumerable.Repeat(_distractor, 8).ToList();
        searchArray.Add(_target);
        searchArray = Shuffle(searchArray);
        int stepper = 0;
        for (int i = 0; i < searchArray.Count; i++)
        {
            var tmp = i % 3;
            //Debug.Log(i + " " + tmp);
            if (tmp == 0 && i > 0)
            {
                stepper++;
            }

            
            
            Transform stimTransform = searchArray[i].GetComponentsInChildren<Transform>(true)[0];
            Quaternion stimRot = stimTransform.rotation;
            Vector3 stimPos = stimTransform.position;
            var stimulusPosition = stimPos + new Vector3(cubeLength * stepper, cubeLength * tmp, 0);
            Instantiate(searchArray[i], stimulusPosition, stimRot).transform.SetParent(transform);
            //Debug.Log("Stepper: " + stepper);
        }
    }

    // function holding information about search array
    // e.g. position of target, target type, distractor type
    public Tuple<String, String> GetInformation()
    {
        return new Tuple<string, string>(_distractor.name, _target.name);
    }

    private List<GameObject> Shuffle(List<GameObject> list)
    {
        for (int i = list.Count-1; i >= 0; i--)
        {
            //Debug.Log(i);
            int j = Random.Range(0, list.Count);
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }

        return list;
    }

    // function that destroys (or makes inivisible) search array
    public void DestroyArray()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
