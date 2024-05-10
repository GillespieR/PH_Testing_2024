using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    StoryManager storyManager;
    AudioSource audioSource;

    //public TextMeshProUGUI simText;
    //public Slider textSlider;
    // Start is called before the first frame update
    void Start()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        audioSource = storyManager.gameObjectDictionary["AudioManager"].GetComponent<AudioManager>().audioSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void UpdateTextSize()
    {
        simText.fontSize = textSlider.value;
    }
    */

    public void ShowCCPanel(GameObject panel)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();

        rect.DOAnchorMax(new Vector2(1f, .35f), .2f, false);

        //DOTween.To(() => rect.anchorMax, y => rect.anchorMax = y, new Vector2(0f, .25f));

        /*
        DOTween.Sequence()
            .Join(DOTween.To(() => rect.anchorMin, y => rect.anchorMin = y, new Vector2(.15f, 0f), 1f))
            .Join(DOTween.To(() => rect.anchorMax, y => rect.anchorMax = y, new Vector2(.35f, 0f), 1f))
            .SetRelative(true)
            .Play();
        */
    }

    public void MuteOnOff()
    {


        StartCoroutine(MuteOnOffCo());
    }

    IEnumerator MuteOnOffCo() 
    {
        while (true) 
        {
            if (audioSource.isPlaying)
            {

                audioSource.mute = true;
                
            }
            yield return null;
        }

        while (true) 
        {
            if (!audioSource.isPlaying)
            {

                audioSource.mute = false;
                
            }

            yield return null;
        }
        
    }
}
