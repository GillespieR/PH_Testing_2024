using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Events;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class StoryManager : MonoBehaviour
{
    
    
    public GameObject globalDictionaryObject;

    //using this variable to hold the current position in the list
    public Chapters currentChapter;
    //Scriptable object list index variable. 
    public int currentChapterIndex = 0;

    //Initializing the list that holds the scriptable objects. 
    public List<Chapters> simChapters = new List<Chapters>();

    CameraController camController;    
    GlobalActionDictionary functionDictionary;
    AudioManager audioManager;
    InteractionManagerV2 interactionManager;
    HighlightManager highlightManager;
    

    public Dictionary<string, GameObject> gameObjectDictionary;
    Outline outline;

    //bool chapterComplete = false;

    private CinemachineTrackedDolly dolly;
    AudioSource audioSource;

    Animator sceneAnimator;
    Animator ClipboardAnim;
    
    GameObject blockRaycast;
    GameObject SJSludge;
    GameObject sludgeRandomized;

    public float userReadingInputValue;
    public float sludgeValue;
    private void Awake()
    {        

        globalDictionaryObject = GameObject.FindWithTag("GlobalDictionaryObject");
        functionDictionary = globalDictionaryObject.GetComponent<GlobalActionDictionary>();
        gameObjectDictionary = globalDictionaryObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict;        

        PopulateDictionary();       
    }
    private void Start()
    {

        camController = gameObjectDictionary["CameraManager"].gameObject.GetComponent<CameraController>();
        audioManager = gameObjectDictionary["AudioManager"].gameObject.GetComponent<AudioManager>();
        interactionManager = gameObjectDictionary["InteractionManager"].gameObject.GetComponent<InteractionManagerV2>();
        highlightManager = gameObjectDictionary["HighlightManager"].gameObject.GetComponent<HighlightManager>();        


        blockRaycast = gameObjectDictionary["BlockRaycast"].gameObject;
        sceneAnimator = gameObjectDictionary["Complete_Set_Animated"].GetComponent<Animator>();
        audioSource = audioManager.GetComponent<AudioSource>();

        foreach (Chapters chaps in simChapters) 
        {

            chaps.chapterComplete = false;
        }

        // currentChapterIndex = 0;        

        currentChapter = simChapters[currentChapterIndex];

        functionDictionary.GetComponent<GlobalActionDictionary>().SubscribeChapterMethods();
        currentChapter.chapterEvent.Invoke();
        currentChapter.chapterEvent.RemoveAllListeners();

        
    }
    private void Update()
    {
        //Debug.Log("currently at Chapter: " + currentChapterIndex);
        

    }

    public void NextChapter() 
    {
        //StopAllCoroutines();
        Debug.Log("Inside StoryManager.NextChapter()");
        

        interactionManager.target = "No Tag";
        highlightManager.stopHighlight = true;
        
        

        if (currentChapterIndex < simChapters.Count)
        {
                //currentChapter.chapterEvent.RemoveAllListeners();

                //go to next chapter
                currentChapterIndex++;
                //currentChapterIndex = currentChapterIndex +1;
                currentChapter = simChapters[currentChapterIndex];
                //subscribe chapter methods
                functionDictionary.GetComponent<GlobalActionDictionary>().SubscribeChapterMethods();
                currentChapter.chapterEvent.Invoke();
                currentChapter.chapterEvent.RemoveAllListeners();
                
                //await Task.Yield();
        }


        Debug.Log("Chaper Index is " + currentChapterIndex);
        //Debug.Log("At end of NextChapter()");

    }

    public void PopulateGlowGameObjects() 
    {
        highlightManager.PopulateGlowGameObjects();
    }

    public void IntroChapter() 
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(IntroChapterCoroutine());
    }

    public void ChapterOne() 
    {

        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterOneCouroutine());
       
    }

    public void ChapterTwo()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwoCouroutine());

    }

    public void ChapterThree()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterThreeCouroutine());

    }
    public void ChapterFour()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterFourCouroutine());

    }
    public void ChapterFive()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterFiveCouroutine());

    }
    public void ChapterSix()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterSixCouroutine());

    }

    public void ChapterSeven()
    {

        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterSevenCouroutine());

    }

    public void ChapterEight()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterEightCouroutine());

    }

    public void ChapterNine()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterNineCouroutine());

    }
    public void ChapterTen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTenCouroutine());

    }
    public void ChapterEleven()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterElevenCouroutine());

    }
    public void ChapterTwelve()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwelveCouroutine());

    }

    public void ChapterThirteen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterThirteenCouroutine());

    }

    public void ChapterFourteen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterFourteenCouroutine());

    }

    public void ChapterFifteen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterFifteenCouroutine());

    }

    public void ChapterSixteen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterSixteenCouroutine());

    }

    public void ChapterSeventeen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterSeventeenCouroutine());

    }

    public void ChapterEighteen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterEighteenCouroutine());

    }

    public void ChapterNineteen()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterNineteenCouroutine());

    }

    public void ChapterTwenty()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwentyCouroutine());

    }

    public void ChapterTwentyOne()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwentyOneCouroutine());

    }

    public void ChapterTwentyTwo()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwentyTwoCouroutine());

    }

    public void ChapterTwentyThree()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwentyThreeCouroutine());

    }

    public void ChapterTwentyFour()
    {
        highlightManager.StartHighlightCoroutine();
        StartCoroutine(ChapterTwentyFourCouroutine());

    }
    IEnumerator IntroChapterCoroutine() 
    {
        Debug.Log("Inside intro chapter");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());

        yield return new WaitForSeconds(1f);        
        audioManager.PlayAudio();
        //PopulateGlowGameObjects();
        highlightManager.stopHighlight = false;


        while (true) 
        {
            if (audioSource.isPlaying)
            {
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(audioSource.clip.length);
                break;                

            }

            yield return null;
        }
        
        NextChapter();
        

        yield return null;
    }
    IEnumerator ChapterOneCouroutine() 
    {

        Debug.Log("Inside Chapter One");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());

        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;



        while (true) 
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {
                yield return new WaitForSeconds(.5f);
                audioSource.clip = audioManager.audioClips[25];
                yield return new WaitForSeconds(audioSource.clip.length);
                break;
            }
            yield return null;
        }
        
        NextChapter();

        yield return null;
    }

    IEnumerator ChapterTwoCouroutine()
    {


        Debug.Log("Inside Chapter Two");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;


        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;


            }
            yield return null;
        }

        NextChapter();

        yield return null;
    }

    IEnumerator ChapterThreeCouroutine()
    {


        Debug.Log("Inside Chapter Three");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterFourCouroutine()
    {

        Debug.Log("Inside Chapter Four");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterFiveCouroutine()
    {
        Debug.Log("Inside Chapter Five");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterSixCouroutine()
    {
        Debug.Log("Inside Chapter Six");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        Debug.Log(audioSource.clip.name);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterSevenCouroutine()
    {
        Debug.Log("Inside Chapter Seven");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterEightCouroutine()
    {
        Debug.Log("Inside Chapter Eight");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterNineCouroutine()
    {
        Debug.Log("Inside Chapter Nine");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTenCouroutine()
    {
        Debug.Log("Inside Chapter Ten");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterElevenCouroutine()
    {
        Debug.Log("Inside Chapter Eleven");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTwelveCouroutine()
    {
        Debug.Log("Inside Chapter Twelve");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterThirteenCouroutine()
    {
        Debug.Log("Inside Chapter Thirteen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterFourteenCouroutine()
    {
        Debug.Log("Inside Chapter Fourteen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterFifteenCouroutine()
    {
        Debug.Log("Inside Chapter Fifteen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterSixteenCouroutine()
    {
        Debug.Log("Inside Chapter Sixteen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterSeventeenCouroutine()
    {
        Debug.Log("Inside Chapter Seventeen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterEighteenCouroutine()
    {
        Debug.Log("Inside Chapter Eighteen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterNineteenCouroutine()
    {
        Debug.Log("Inside Chapter Ninteen");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTwentyCouroutine()
    {
        Debug.Log("Inside Chapter Twenty");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTwentyOneCouroutine()
    {
        Debug.Log("Inside Chapter TwentyOne");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTwentyTwoCouroutine()
    {
        Debug.Log("Inside Chapter TwentyTwo");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTwentyThreeCouroutine()
    {
        Debug.Log("Inside Chapter TwentyThree");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }

    IEnumerator ChapterTwentyFourCouroutine()
    {
        Debug.Log("Inside Chapter TwentyFour");
        Debug.Log("Current chapter interact Object tag is " + currentChapter.interactObjectTag.ToString());
        yield return new WaitForSeconds(1f);
        audioManager.PlayAudio();
        highlightManager.stopHighlight = false;

        while (true)
        {
            if (interactionManager.target == currentChapter.interactObjectTag)
            {

                yield return new WaitForSeconds(.5f);
                sceneAnimator.Play(currentChapter.interactObjectAnim.name);
                yield return new WaitForSeconds(4f);
                break;

            }
            yield return null;
        }
        //SJSludge.transform.localScale = new Vector3(0.0518035777f, 0f, 0.0518035777f);        
        NextChapter();
        yield return null;
    }
    public void PopulateDictionary() 
    {
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("IntroChapter", IntroChapter);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterOne", ChapterOne);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwo", ChapterTwo);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterThree", ChapterThree);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFour", ChapterFour);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFive", ChapterFive);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSix", ChapterSix);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSeven", ChapterSeven);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterEight", ChapterEight);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterNine", ChapterNine);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTen", ChapterTen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterEleven", ChapterEleven);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwelve", ChapterTwelve);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterThirteen", ChapterThirteen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFourteen", ChapterFourteen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFifteen", ChapterFifteen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSixteen", ChapterSixteen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSeventeen", ChapterSeventeen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterEighteen", ChapterEighteen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterNineteen", ChapterNineteen);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwenty", ChapterTwenty);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwentyOne", ChapterTwentyOne);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwentyTwo", ChapterTwentyTwo);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwentyThree", ChapterTwentyThree);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwentyFour", ChapterTwentyFour);


        /*
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterOne", ChapterOne);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwo", ChapterTwo);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterThree", ChapterThree);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFour", ChapterFour);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFive", ChapterFive);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSix", ChapterSix);
        /*
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterTwoStory", ChapterTwoStory);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterThreeStory", ChapterThreeStory);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFourStory", ChapterFourStory);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterFiveStory", ChapterFiveStory);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSixStory", ChapterSixStory);
        functionDictionary.GetComponent<GlobalActionDictionary>().ActionDict.Add("ChapterSevenStory", ChapterSevenStory);
        */
    }
}

