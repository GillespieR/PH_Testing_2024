using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{

    StoryManager storyManager;
    public InteractionManagerV2 interactionManager;
    AudioManager audioManager;
    public List<GameObject> glowGameObjects = new List<GameObject>();        

    public bool stopHighlight = true;
    public bool endHighlightCoroutine = false;

    //could problem be here?
    string chapTargetTag;
    int currentChap;

    GameObject chapterGlowObject;
    

    void Start()
    {

        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        chapTargetTag = storyManager.simChapters[storyManager.currentChapterIndex].interactObjectTag;
        currentChap = storyManager.currentChapterIndex;

        interactionManager = storyManager.gameObjectDictionary["InteractionManager"].GetComponent<InteractionManagerV2>();
        audioManager = storyManager.gameObjectDictionary["AudioManager"].GetComponent<AudioManager>();

        PopulateGlowGameObjects();

        foreach (GameObject glowObject in glowGameObjects)
        {
            if (glowObject.tag == chapTargetTag)
            {
                chapterGlowObject = glowObject;
                Debug.Log("Chapter glow Object is " + chapterGlowObject.tag.ToString());
            }
            /*
            else 
            {
                chapterGlowObject = storyManager.gameObjectDictionary["WrongTarget"];
            }
            */
        }

        //chapterGlowObject = storyManager.gameObjectDictionary["Sludge_judge"];

    }

    void Update()
    {
        chapTargetTag = storyManager.simChapters[storyManager.currentChapterIndex].interactObjectTag;

        //Debug.Log("Value of stopHighlight is " + stopHighlight);
        foreach (GameObject glowObject in glowGameObjects)
        {
            if (glowObject.tag == chapTargetTag)
            {
                chapterGlowObject = glowObject;
                //Debug.Log("Chapter glow Object is " + chapterGlowObject.tag.ToString());
            }
            /*
            else
            {
                chapterGlowObject = storyManager.gameObjectDictionary["WrongTarget"];
            }
            */
        }

    }

    public void StartHighlightCoroutine() 
    {
                
        StartCoroutine(StartHighlightCycle());        
        
    }

    public void PopulateGlowGameObjects() 
    {

        foreach (GameObject go in storyManager.globalDictionaryObject.GetComponent<GlobalGameObjectDictionary>().assets)
        {
            if (go.GetComponent<Outline>())
            {
                glowGameObjects.Add(go);
            }
        }
    }
    public IEnumerator StartHighlightCycle()
    {

        
        //float lerpTime = 2f;        

        while (true)
        {
            if (chapterGlowObject != null)
            {
                break;
            }
            else
            {
                Debug.Log("Waiting to populate glow object");
            }
            yield return null;
        }

        //chapterGlowObject.GetComponent<Outline>().enabled = false;
        Debug.Log("Inside StartHighlightCycle Coroutine");
        Debug.Log("The value of chapterGlowObject is " + chapterGlowObject.name.ToString());
                

        while (true)
        {


            if (!stopHighlight) 
            {
                if (!audioManager.audioSource.isPlaying)
                {
                    chapterGlowObject.GetComponent<Outline>().enabled = true;
                }

                /*
                if (!stopHighlight)
                {

                    chapterGlowObject.GetComponent<Outline>().enabled = true;

                }            
                */

                if (interactionManager.target == storyManager.currentChapter.interactObjectTag)
                {
                    chapterGlowObject.GetComponent<Outline>().enabled = false;
                    stopHighlight = true;
                    break;
                }                
            }


            yield return null;
            

                /*
                if (chapterGlowObject.GetComponent<Outline>().enabled && !stopHighlight)
                {
                    //Debug.Log("Inside enable to disable outline, !stopHighlight");
                    yield return new WaitForSeconds(.5f);
                    chapterGlowObject.GetComponent<Outline>().enabled = true;
                }
                else if (chapterGlowObject.GetComponent<Outline>().enabled == false && !stopHighlight)
                {
                    //Debug.Log("Inside disable to enable outline, !stopHighlight");
                    yield return new WaitForSeconds(.5f);
                    chapterGlowObject.GetComponent<Outline>().enabled = true;
                }

                if (chapterGlowObject.GetComponent<Outline>().enabled && stopHighlight)
                {
                    //Debug.Log("Inside enable to disable outline, stopHighlight");
                    yield return new WaitForSeconds(.5f);
                    chapterGlowObject.GetComponent<Outline>().enabled = false;
                }
                else if (chapterGlowObject.GetComponent<Outline>().enabled == false && stopHighlight)
                {
                    //Debug.Log("Inside disable to enable outline,  stopHighlight");
                    yield return new WaitForSeconds(.5f);
                    chapterGlowObject.GetComponent<Outline>().enabled = false;
                }
                //interactionManager.target == currentChapter.interactObjectTag
                yield return null;


                if (currentChap >= storyManager.simChapters.Count)
                {
                    Debug.Log("Breaking out of highlight loop");
                    break;
                }

                yield return null;
                */
            

        }
    }

    IEnumerator MaterialFade(Material objMaterial) 
    {
        for (float f = 1f; f >= 0; f -= 0.001f)
        {
            if (f <= 0.01f)
            {
                Color col = objMaterial.color;
                col.a = 0f;
            }
            Color c = objMaterial.color;
            c.a = f;
            objMaterial.color = c;

            yield return null;
        }
        yield return null;
    }
}
