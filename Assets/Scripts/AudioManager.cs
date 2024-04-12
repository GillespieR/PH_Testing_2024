using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    StoryManager storyManager;
    public AudioSource audioSource;

    public List<AudioClip> audioClips = new List<AudioClip>();

    public List<float> clipLengths = new List<float>();

    public float clipLength;

    // Start is called before the first frame update
    void Start()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) 
        {
            SetAudio();
            GetClipLength();
        }
        
    }

    public void GetClipLength() 
    {
        clipLength = audioSource.clip.length;
        clipLengths.Add(clipLength);

        Debug.Log(audioSource.clip.name.ToString() + " is " + clipLength + " seconds long");

    }
    public void SetAudio() 
    {
        int currentChapter = storyManager.currentChapterIndex;

        switch (currentChapter) 
        {
            case 0:
                
                audioSource.clip = audioClips[0];
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
            case 6:

                audioSource.clip = audioClips[6];
                break;
            case 7:
                audioSource.clip = audioClips[7];
                break;
            case 8:
                audioSource.clip = audioClips[8];
                break;
            case 9:
                audioSource.clip = audioClips[9];
                break;
            case 10:
                audioSource.clip = audioClips[10];
                break;
            case 11:
                audioSource.clip = audioClips[11];
                break;
            case 12:

                audioSource.clip = audioClips[12];
                break;
            case 13:
                audioSource.clip = audioClips[13];
                break;
            case 14:
                audioSource.clip = audioClips[14];
                break;
            case 15:
                audioSource.clip = audioClips[15];
                break;
            case 16:
                audioSource.clip = audioClips[16];
                break;
            case 17:
                audioSource.clip = audioClips[17];
                break;
            case 18:

                audioSource.clip = audioClips[18];
                break;
            case 19:
                audioSource.clip = audioClips[19];
                break;
            case 20:
                audioSource.clip = audioClips[20];
                break;
            case 21:
                audioSource.clip = audioClips[21];
                break;
            case 22:
                audioSource.clip = audioClips[22];
                break;
            case 23:
                audioSource.clip = audioClips[23];
                break;
            case 24:
                audioSource.clip = audioClips[24];
                break;



        }
    }

    public void PlayAudio() 
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
    }
}
