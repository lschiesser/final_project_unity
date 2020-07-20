using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCreator : MonoBehaviour
{
    public GameObject[] stimuliPrefabs;

    private List<GameObject> fearInducing;
    private List<GameObject> animateControl;
    private List<GameObject> inanimateControl;
    // Start is called before the first frame update
    void Start()
    {
        fearInducing = new List<GameObject>();
        animateControl = new List<GameObject>();
        inanimateControl = new List<GameObject>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
