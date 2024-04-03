using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalActionDictionary : MonoBehaviour
{

    public Dictionary<string, UnityAction> ActionDict = new Dictionary<string, UnityAction>();

    [SerializeField]
    GameObject storyManagerRef;

    Chapters currentChapter;
    // Start is called before the first frame update
    private void Awake()
    {

        storyManagerRef = GameObject.FindWithTag("StoryManager");
  
        //currentChapter = storyManagerRef.GetComponent<StoryManager>().simChapters[storyManagerRef.GetComponent<StoryManager>().currentChapterIndex];
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubscribeChapterMethods() 
    {
        currentChapter = storyManagerRef.GetComponent<StoryManager>().simChapters[storyManagerRef.GetComponent<StoryManager>().currentChapterIndex];
        foreach (string methodName in currentChapter.chapterMethodNames)
        {
            currentChapter.chapterEvent.AddListener(ActionDict[methodName]);
            //currentChapter.chapterEvent.AddListener(Ac)
            //StartCoroutine(methodName);
        }
    }
}
