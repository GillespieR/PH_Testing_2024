using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    StoryManager sM;
    Animator targetAnimator;

    public List<AnimationClip> animClips = new List<AnimationClip>();
    public List<float> animationDelays = new List<float>();


    public float elapsedTime;
    public bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        sM = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        targetAnimator = sM.gameObjectDictionary["Complete_Set_Animated"].GetComponent<Animator>();

        startTimer = false;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (startTimer) 
        {

            elapsedTime += Time.deltaTime;
        }
    }

    public void PopulateAnimationDelayList() 
    {
        
    }

    public void PlayDelayed() 
    {
        startTimer = true;
        Debug.Log("Value of startTimer is " + startTimer.ToString());        

        StartCoroutine(DelayAnimationCoroutine());
    }

    IEnumerator DelayAnimationCoroutine() 
    {

        Debug.Log("Value of elapsedTime is " + elapsedTime);
        Debug.Log("Value of animationDelays[0] is " + animationDelays[sM.currentChapterIndex]);
        yield return new WaitForSeconds(animationDelays[sM.currentChapterIndex]);                
        //overload/check to be able to pass name of the animation clip you want to delay so its not
        //always tied to the chapters animation - iterate to work for multiple animations in future
        targetAnimator.Play(sM.currentChapter.interactObjectAnim.name);
        Debug.Log("Current animation is " + sM.currentChapter.interactObjectAnim.name.ToString());
        yield return new WaitForSeconds(sM.currentChapter.interactObjectAnim.length);
        
    }
    /*
    public void SetAnimClip(Animator targetAnim) 
    {

        int currentChapter = sM.currentChapterIndex;


        switch (currentChapter)
        {
            case 0:
                targetAnim.add = audioClips[0];
                break;
            case 1:
                audioSource.clip = audioClips[1];
                break;
            case 2:
                audioSource.clip = audioClips[2];
                break;
            case 3:
                audioSource.clip = audioClips[3];
                break;
            case 4:
                audioSource.clip = audioClips[4];
                break;
            case 5:
                audioSource.clip = audioClips[5];
                break;


        }
    }*/


}
