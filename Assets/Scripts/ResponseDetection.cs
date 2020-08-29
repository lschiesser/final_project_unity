using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDetection : MonoBehaviour
{
    public bool _responded;
    private bool _flag;
    
    void Start()
    {
        _responded = false;
        _flag = false;
    }

    // Check if participant clicked on one of the objects 
    void Update()
    {
        if (_flag)
        {
            _flag = false;
            _responded = false;
        }
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100)){
                // if something was clicked on, print its name and change respond-boolean to true
                if (hit.collider)
                {
                    PrintName(hit.collider.gameObject);
                    Debug.Log("Did Hit");
                    _responded = true;
                    //problem: array object is only clickable; no individual objects
                    //problem2: only works once ?! 
                }
                
            }
        }
    }

    public void SetFalse()
    {
        _responded = false;
    }

    private void SetTrue()
    {
        _flag = true;
    }

    public bool GetResponse()
    {
        return _responded;
    }
    public void PrintName(GameObject obj)
    {
        print(obj.name);
    }
}
