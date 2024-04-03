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
        readingInput = storyManager.gameObjectDictionary["ReadingInput"].GetComponent<TMP_InputField>();
        timeInput = storyManager.gameObjectDictionary["TimeInput"].GetComponent<TMP_InputField>();
        dateInput = storyManager.gameObjectDictionary["DateInput"].GetComponent<TMP_InputField>();
        
        /*
        readingInputDisplayed = storyManager.gameObjectDictionary["UserReadingInputDisplayed"].GetComponent<TMP_Text>();
        timeInputDisplayed = storyManager.gameObjectDictionary["UserTimeInputDisplayed"].GetComponent<TMP_Text>();
        dateInputDisplayed = storyManager.gameObjectDictionary["UserDateInputDisplayed"].GetComponent<TMP_Text>();
        */

        readingInput.image.enabled = false;
        timeInput.image.enabled = false;
        dateInput.image.enabled = false;

        /*
        readingInputDisplayed.text = "";
        timeInputDisplayed.text = "";
        dateInputDisplayed.text = "";
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecordSample() 
    {
        readingInput.image.enabled = false;
        timeInput.image.enabled = false;
        dateInput.image.enabled = false;

        string userReadingInput;
        string userTimeInput;
        string userDateInput;

        float userReadingInputFloat;        

        userReadingInput = readingInput.text;
        userTimeInput = timeInput.text;
        userDateInput = dateInput.text;

        try
        {
            userReadingInputFloat = float.Parse(userReadingInput);
            storyManager.userReadingInputValue = userReadingInputFloat;
        }
        catch 
        {
            Debug.Log("Invalid Input");
            readingInput.text = "Invalid Input";


        }

        if(userDateInput != null && userTimeInput != null) 
        {

           dateInput.text = userDateInput;
           timeInput.text = userTimeInput;
        }

    }

    public void DisableInputFieldsImage() 
    {
        readingInput.image.enabled = false;
        timeInput.image.enabled = false;
        dateInput.image.enabled = false;
    }
}
