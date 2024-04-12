using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    StoryManager storyManager;
    TMP_InputField readingInput;
    TMP_InputField timeInput;
    TMP_InputField dateInput;

    /*
    TMP_Text readingInputDisplayed;
    TMP_Text timeInputDisplayed;
    TMP_Text dateInputDisplayed;
    */

    // Start is called before the first frame update
    void Start()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

}