using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    StoryManager storyManager;
    public AudioSource audioSource;

    public UIManager uiManager;

    public List<AudioClip> audioClips = new List<AudioClip>();

    public List<float> clipLengths = new List<float>();

    public float clipLength;

    public AudioClip currentClip;

    int currentChapter;

    // Start is called before the first frame update
    void Start()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        uiManager = storyManager.gameObjectDictionary["UIManager"].GetComponent<UIManager>();
        audioSource = gameObject.GetComponent<AudioSource>();

        StartCoroutine(SetAudio());

    }

    // Update is called once per frame
    void Update()
    {

        //Is there a better place to put this instead of update
        GetCurrentClip();
        currentChapter = storyManager.currentChapterIndex;


    }

    public void GetCurrentClip() 
    {

        currentClip = audioSource.clip;
        Debug.Log("Current audio clip is " + currentClip.ToString());
    }
    public void GetClipLength() 
    {
        clipLength = audioSource.clip.length;
        clipLengths.Add(clipLength);

        Debug.Log(audioSource.clip.name.ToString() + " is " + clipLength + " seconds long");

    }

    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            storyManager.isPaused = false;

        }
        else if (!audioSource.isPlaying && storyManager.isPaused)
        {

            audioSource.UnPause();
            storyManager.isPaused = false;
        }
    }


    public void PauseAudio()
    {
        /*
        if (isPaused)
        {
            isPaused = false;
            GameObject.Find("AudioManager").GetComponent<AudioSource>().Pause();ee 
        }
        */
                
        audioSource.Pause();
        storyManager.isPaused = true;

    }
    public IEnumerator SetAudio() 
    {
        Debug.Log("Inside SetAudio in AudioManager");
        

        while (true) 
        {

            if (currentClip != storyManager.simChapters[currentChapter].chapAudio)
            {
                audioSource.clip = storyManager.simChapters[currentChapter].chapAudio;
            }

            yield return null;
        }
        

        yield return null;
        /*
        foreach(Chapters chap in storyManager.simChapters)         
        {

            audioSource.clip = storyManager.simChapters
        }

        

        switch (currentChapter) 
        {
            case 0:
                
                audioSource.clip = audioClips[0];                
                GetClipLength();
                break;
            case 1:
                audioSource.clip = audioClips[1];
                GetClipLength();
                break;
            case 2:
                audioSource.clip = audioClips[2];
                GetClipLength();
                break;
            case 3:
                audioSource.clip = audioClips[3];
                GetClipLength();
                break;
            case 4:
                audioSource.clip = audioClips[4];
                GetClipLength();
                break;
            case 5:
                audioSource.clip = audioClips[5];
                GetClipLength();
                break;
            case 6:

                audioSource.clip = audioClips[6];
                GetClipLength();
                break;
            case 7:
                audioSource.clip = audioClips[7];
                GetClipLength();
                break;
            case 8:
                audioSource.clip = audioClips[8];
                GetClipLength();
                break;
            case 9:
                audioSource.clip = audioClips[9];
                GetClipLength();
                break;
            case 10:
                audioSource.clip = audioClips[10];
                GetClipLength();
                break;
            case 11:
                audioSource.clip = audioClips[11];
                GetClipLength();
                break;
            case 12:

                audioSource.clip = audioClips[12];
                GetClipLength();
                break;
            case 13:
                audioSource.clip = audioClips[13];
                GetClipLength();
                break;
            case 14:
                audioSource.clip = audioClips[14];
                GetClipLength(); 
                break;
            case 15:
                audioSource.clip = audioClips[15];
                GetClipLength();
                break;
            case 16:
                audioSource.clip = audioClips[16];
                GetClipLength();
                break;
            case 17:
                audioSource.clip = audioClips[17];
                GetClipLength();
                break;
            case 18:

                audioSource.clip = audioClips[18];
                GetClipLength();
                break;
            case 19:
                audioSource.clip = audioClips[19];
                GetClipLength();
                break;
            case 20:
                audioSource.clip = audioClips[20];
                GetClipLength();
                break;
            case 21:
                audioSource.clip = audioClips[21];
                GetClipLength();
                break;
            case 22:
                audioSource.clip = audioClips[22];
                GetClipLength();
                break;
            case 23:
                audioSource.clip = audioClips[23];
                GetClipLength();
                break;
            case 24:
                audioSource.clip = audioClips[24];
                GetClipLength();
                break;
        }

        yield return null;
        */
    }
    /*
    public void PlayAudio() 
    {
        Debug.Log("Inside PlayAudio() in AudioManager.");        
        audioSource.Play();
    }*/
    
    /*
    public void PlayAudio() 
    {
        if (!audioSource.isPlaying && !uiManager.isPaused)
        {
            audioSource.Play();
        }    

        if(audioSource.isPlaying || uiManager.isPaused) 
        {
        
             
        }
    }
    */
}
