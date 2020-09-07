using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDetection : MonoBehaviour
{
    public bool _responded;
    public string _name;
    private bool _flag;
    
    void Start()
    {
        _responded = false;
        _flag = false;
    }

    // Check if participant clicked on one of the objects 
    void Update()
    {
        /*if (_flag)
        {
            _flag = false;
            _responded = false;
        }*/
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("mouse down");
            if (Physics.Raycast(ray, out hit)){
                // if something was clicked on, print its name and change respond-boolean to true
                Debug.Log("raycast");
                if (hit.collider)
                {
                    PrintName(hit.collider.gameObject);
                    Debug.Log("Did Hit");
                    _responded = true;
                    _name = hit.collider.gameObject.name;
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

    public string CheckResponse()
    {
        return _name;
    }
}
