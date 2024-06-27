using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    StoryManager sM;
    Animator targetAnimator;
    SimulationTimer simTimer;

    public List<AnimationClip> animClips = new List<AnimationClip>();
    public List<float> animationDelays = new List<float>();


    public bool animationPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sM = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        targetAnimator = sM.gameObjectDictionary["Complete_Set_Animated"].GetComponent<Animator>();
        simTimer = sM.GetComponent<SimulationTimer>();

        // targetAnimator.StartPlayback();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void PopulateAnimationClipList() 
    {


        //I want to get all the animation clips in each chapter scriptable object and populate animClips list using a loop. Will clips work or do I have to use states?
        //I also want to make a corresponding list which would be a list of delays as floats
        foreach (AnimationClip _anim in animClips)
        {
            /*
            _anim = sM.currentChapter.interactObjectAnim;
            animClips[_anim] = sM.currentChapter.interactObjectAnim;
            */
        }
    }

    public void PlayDelayed() 
    {       
        Debug.Log("Value of startTimer is " + simTimer.startTimer.ToString());        
        StartCoroutine(DelayAnimationCoroutine());
    }

    public void PauseAnimation() 
    {

        simTimer.PauseTimer();
        targetAnimator.speed = 0;
        
    }

    public void ResumeAnimation() 
    {
        //know if this will resume animation where it left off?
        simTimer.ResumeTimer();
        targetAnimator.speed = 1;
        //targetAnimator.Play(sM.currentChapter.interactObjectAnim.ToString());
    }

    public void ResetAnimation()     
    {

        targetAnimator.Play(sM.currentChapter.interactObjectAnim.ToString(), -1);
    }

    IEnumerator DelayAnimationCoroutine() 
    {

        Debug.Log("Value of elapsedTime is " + simTimer.elapsedTime);
        Debug.Log("Value of current chapter animation delay is " + animationDelays[sM.currentChapterIndex]);

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
