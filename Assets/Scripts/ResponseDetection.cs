using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDetection : MonoBehaviour
{
    public bool _responded;
    
    
    void Start()
    {
        _responded = false;
    }

    // Check if participant clicked on one of the objects 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)){
                // if something was clicked on, print its name and change respond-boolean to true
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);
                    Debug.Log("Did Hit");
                    _responded = true;
                    
                    //problem: array object is only clickable; no individual objects
                    //problem2: only works once ?! 
                }
                
            }
        }
    }

    public void PrintName(GameObject obj)
    {
        print(obj.name);
    }
}
