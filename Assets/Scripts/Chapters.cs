using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Chapters", order = 51)]
public class Chapters : ScriptableObject
{
    //Tag of the object user is supposed to click on to finish this section.
    
    public string interactObjectTag;  
    public string highlightObject;

    public AnimationClip interactObjectAnim;
    public AudioClip chapAudio;

    public List<string> chapterMethodNames = new List<string>();   
    public UnityEvent chapterEvent;

    public bool chapterComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
