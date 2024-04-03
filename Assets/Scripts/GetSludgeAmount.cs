using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSludgeAmount : MonoBehaviour
{
    StoryManager storyManager;
    float markNumber;
    // Start is called before the first frame update
    void Start()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == 7) 
        {
            markNumber = float.Parse(other.gameObject.name);
            Debug.Log("Value of mark number is " + markNumber);
            storyManager.sludgeValue = markNumber;
        }
    }
}
