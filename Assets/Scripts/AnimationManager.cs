using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    StoryManager sM;
    Animator targetAnimator;

    public List<AnimationClip> animClips = new List<AnimationClip>();

    // Start is called before the first frame update
    void Start()
    {
        sM = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void PlayAnimation() 
    {
        targetAnimator = sM.gameObjectDictionary["SludgeJudge"].GetComponent<Animator>();

        

    }
}
