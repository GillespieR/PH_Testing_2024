using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public StoryManager storyManager;
    AudioManager audioManager;
    AudioSource audioSource;
    
    public TextMeshProUGUI simText;
    //public Slider textSlider;
    public bool menuIsOpen = false;
    public bool subMenuIsOpen = false;
    public bool soundOff = false;
    public bool isPaused = false;
    public bool shouldExpandOnStart = false;
    
    public bool setBigFont = false;
    public bool fullText = false;
    bool pageBack = false;
    //public bool subMenuExpanded = false;
    //public bool subMenuCollapsed = false;    


    public Sprite soundOnButtonImage;
    public Sprite soundOffButtonImage;
    public GameObject soundButton;
    public GameObject expandSubMenuButton;
    public GameObject collapseSubMenuButton;
    public GameObject overflowNextPageButton;
    public AudioClip openSoundClip;
    public AudioClip closeSoundClip;
    Vector2 EMin;
    Vector2 EMax;
    Vector2 MMin;
    Vector2 MMax;
    Vector2 MinDiff;
    Vector2 MaxDiff;

    // Start is called before the first frame update
    void Start()
    {

        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        audioManager = storyManager.gameObjectDictionary["AudioManager"].GetComponent<AudioManager>();
        audioSource = audioManager.GetComponent<AudioSource>();
        
        //0.3499
        //Expanded:
        //Min
        EMin = new Vector2(0.287f, 0.234405026f);
        //Max
        EMax = new Vector2(0.69599998f, 0.349900007f);
        //Minimized:
        MMin = new Vector2(0.287f, 0.0656127259f);
        MMax = new Vector2(0.69600004f, 0.181129113f);
        //Differences
        MaxDiff = MMax - EMax;
        MinDiff = MMin - EMin;
        Debug.Log("MinDiff is: " + MinDiff.x + "," + MinDiff.y);// 0,-0.1687923
        Debug.Log("MaxDiff is: "+MaxDiff.x+","+ MaxDiff.y);//.960464E-08,-0.1687709
        MMin -= EMin;
        Debug.Log("modified MinDiff is: "+MMin.x+","+ MMin.y);
        Debug.Log("expanding menu");
        


        if (storyManager.hasBegun) 
        {
            
            SetTextSize();
        }
        
        
        if (shouldExpandOnStart)
        {                      
            ExpandMenu();
        }
        //ExpandMenu();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CollapseMenu();
        }

        CheckOverflow();
        //CheckFontSize();

    }

    /*public void UpdateTextSize()
    {
        simText.fontSize = textSlider.value;
    }*/

    public IEnumerator OpenMainMenuCoroutine()
    {
        GameObject.Find("PH Testing").GetComponent<AudioSource>().clip = openSoundClip;
        GameObject.Find("PH Testing").GetComponent<AudioSource>().Play();

        DOTween.To(() => GameObject.Find("MainMenuPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("MainMenuPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.661000013f, 0.810225546f), 1);
        yield return new WaitForSeconds(1f);
        GameObject.Find("HomeImage").GetComponent<Image>().enabled = true;
        GameObject.Find("SettingsImage").GetComponent<Image>().enabled = true;
        GameObject.Find("HomeText").GetComponent<TextMeshProUGUI>().enabled = true;
        GameObject.Find("SettingsText").GetComponent<TextMeshProUGUI>().enabled = true;
        DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.61644882f, 0.764741898f), 0.5f);
        DOTween.To(() => GameObject.Find("SettingsButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SettingsButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.61644882f, 0.5633873f), 0.5f);
        
        //Vector2(0.378842503,0.649000049)
    }

    public IEnumerator CloseMainMenuCoroutine()
    {
        GameObject.Find("PH Testing").GetComponent<AudioSource>().clip = closeSoundClip;
        GameObject.Find("PH Testing").GetComponent<AudioSource>().Play();
        DOTween.To(() => GameObject.Find("MainMenuPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("MainMenuPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.329000026f, 0.810225546f), 1);
        yield return new WaitForSeconds(1f);
        GameObject.Find("HomeImage").GetComponent<Image>().enabled = false;
        GameObject.Find("SettingsImage").GetComponent<Image>().enabled = false;
        GameObject.Find("HomeText").GetComponent<TextMeshProUGUI>().enabled = false;
        GameObject.Find("SettingsText").GetComponent<TextMeshProUGUI>().enabled = false;
        DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.378842503f, 0.764741898f), 0.5f);
        DOTween.To(() => GameObject.Find("SettingsButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SettingsButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.378842503f, 0.563387275f), 0.5f);
        
        //Vector2(0.378842503,0.649000049)
    }

    public void SetTextSize() 
    {            

            if (fullText)
            {
                simText.text = storyManager.currentChapter.fullText;

            }
            else if (!fullText)
            {

                simText.text = storyManager.currentChapter.shortenedText;

            }
    }

    public void ToggleFontSize() 
    {

        if (setBigFont)
        {
            IncreaseFontSize();
        }
        else 
        {            
            DecreaseFontSize();
        }

    }

    public void CheckFontSize() 
    {
    
        if(simText.fontSize == 36f) 
        {

            DecreaseFontSize();
            
        }
        else 
        {

            IncreaseFontSize();
        }
    }

     void IncreaseFontSize() 
    {

            simText.fontSize = 36f;
            simText.fontStyle = FontStyles.Bold;
            setBigFont = false;
        
    }

     void DecreaseFontSize()
    {
        if (!setBigFont) 
        {
            simText.fontSize = 24f;
            simText.fontStyle = FontStyles.Normal;
            setBigFont = true;
        }
        
    }

    public void CheckOverflow() 
    {

        if (simText.isTextOverflowing) 
        {
            overflowNextPageButton.GetComponent<Button>().enabled = true;
            
        }
        
        if(!simText.isTextOverflowing)
        {
            overflowNextPageButton.GetComponent<Button>().enabled = false;

        }        
    }

    public void ChangeOverflowPage() 
    {

        if(simText.pageToDisplay == 1) 
        {
            simText.pageToDisplay = 2;
        }
        else if(simText.pageToDisplay == 2) 
        {
            simText.pageToDisplay = 3;
        }
        else if(simText.pageToDisplay == 3) 
        {
            simText.pageToDisplay = 4;
        }
        else if (simText.pageToDisplay == 4)
        {
            simText.pageToDisplay = 1;
        }




    }

    public void OpenMainMenu()
    {
        menuIsOpen = true;
        StartCoroutine(OpenMainMenuCoroutine());
    }

    public void CloseMainMenu()
    {
        menuIsOpen = false;
        StartCoroutine(CloseMainMenuCoroutine());
    }

    public void ToggleMainMenu()
    {
        if(menuIsOpen)
        {
            CloseMainMenu();
        }
        else
        {
            OpenMainMenu();
        }
    }

    public void EnableExpandSubMenuButton() 
    {
        expandSubMenuButton.GetComponent<Image>().enabled = true;
        expandSubMenuButton.GetComponent<Button>().interactable = true;
    }

    public void DisableExpandSubMenuButton() 
    {
        expandSubMenuButton.GetComponent<Image>().enabled = false;
        expandSubMenuButton.GetComponent<Button>().interactable = false;
    }

    public void EnableCollapseSubMenuButton() 
    {
        collapseSubMenuButton.GetComponent<Button>().interactable = true;
        collapseSubMenuButton.GetComponent<Image>().enabled = true;
    }

    public void DisableCollapseSubMenuButton() 
    {
        collapseSubMenuButton.GetComponent<Button>().interactable = false;
        collapseSubMenuButton.GetComponent<Image>().enabled = false;
    }

    public void ToggleSound()
    {
        if (soundOff)
        {
            audioManager.GetComponent<AudioSource>().mute = true;
            soundOff = false;
            soundButton.GetComponent<Image>().sprite = soundOnButtonImage;
        }
        else
        {
            soundOff = true;
            audioManager.GetComponent<AudioSource>().mute = false;
            soundButton.GetComponent<Image>().sprite = soundOffButtonImage;
        }
    }


    public void PauseButton()
    {
        storyManager.isPaused = true;
    }

    public void PlayButton()
    {

        storyManager.isPaused = false;
    }



    public void CollapseMenu()
    {
        DOTween.To(() => GameObject.Find("BottomPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("BottomPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(1f, 0.0897745565f), 1);
        DOTween.To(() => GameObject.Find("TextFrame").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextFrame").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.989000022f, 0.0936454684f), 1);
        DOTween.To(() => GameObject.Find("SimScriptText").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SimScriptText").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.975500643f, 0.0693545416f), 1);
        DOTween.To(() => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.287f, 0.0656127259f), 1);
        DOTween.To(() => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.69600004f, 0.181129113f), 1);

        DOTween.To(() => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.342369974f, 0.112225451f), 1);
        DOTween.To(() => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.378842503f, 0.168129101f), 1);
        //DOTween.To(() => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.342369974f, 0.112225451f) - MinDiff), 1);
        //DOTween.To(() => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("CollapseSubmenuButton ").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.378842503f, 0.168129101f) - MaxDiff), 1);
        DOTween.To(() => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.578000009f, 0.112225451f), 1);
        DOTween.To(() => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.617000043f, 0.168129101f), 1);
        DOTween.To(() => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.389685035f, 0.112225451f), 1);
        DOTween.To(() => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.424000025f, 0.168129101f), 1);
        DOTween.To(() => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.526000023f, 0.112225451f), 1);
        DOTween.To(() => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.564999998f, 0.168129101f), 1);
        //DOTween.To(() => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.671000004f, 0.1121291f), 1);
        //DOTween.To(() => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.791000009f, 0.152999997f), 1);
        //DOTween.To(() => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.0610000044f, 0.103000008f), 1);
        //DOTween.To(() => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.0920000076f, 0.152999997f), 1);
        DOTween.To(() => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.474750012f, 0.0948282704f), 1);
        DOTween.To(() => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.520250082f, 0.170300826f), 1);
        DOTween.To(() => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.430551261f, 0.0991290957f), 1);
        DOTween.To(() => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.472250015f, 0.168129101f), 1);
        DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.296000004f, 0.112225451f), 1);
        DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.335000008f, 0.168129101f), 1);
        DOTween.To(() => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.631472409f, 0.112225451f), 1);
        DOTween.To(() => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.66900003f, 0.168129101f), 1);

        subMenuIsOpen = false;

        /*
        if (subMenuIsOpen)
        {

            subMenuExpanded = true;
        }

        if (!subMenuIsOpen)
        {

            subMenuCollapsed = true;
        }
        */

        //TextSizeButton

        //Vector2(0.975500643,0.08622545)
    }

    public void ExpandMenu()
    {
       
        
        if (subMenuIsOpen) 
        {
            
            DOTween.To(() => GameObject.Find("BottomPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("BottomPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(1f, 0.0897745565f), 1);
            DOTween.To(() => GameObject.Find("TextFrame").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextFrame").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.989000022f, 0.0936454684f), 1);
            DOTween.To(() => GameObject.Find("SimScriptText").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SimScriptText").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.975500643f, 0.0693545416f), 1);
            DOTween.To(() => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.287f, 0.0656127259f), 1);
            DOTween.To(() => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.7320001f, 0.181129113f), 1);

            DOTween.To(() => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.342369974f, 0.112225451f), 1);
            DOTween.To(() => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.378842503f, 0.168129101f), 1);
            //DOTween.To(() => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.342369974f, 0.112225451f) - MinDiff), 1);
            //DOTween.To(() => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("CollapseSubmenuButton ").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.378842503f, 0.168129101f) - MaxDiff), 1);
            DOTween.To(() => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.578000009f, 0.112225451f), 1);
            DOTween.To(() => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.617000043f, 0.168129101f), 1);
            DOTween.To(() => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.389685035f, 0.112225451f), 1);
            DOTween.To(() => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.424000025f, 0.168129101f), 1);
            DOTween.To(() => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.526000023f, 0.112225451f), 1);
            DOTween.To(() => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.564999998f, 0.168129101f), 1);
            //DOTween.To(() => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.671000004f, 0.1121291f), 1);
            //DOTween.To(() => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.791000009f, 0.152999997f), 1);
            //DOTween.To(() => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.0610000044f, 0.103000008f), 1);
            //DOTween.To(() => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.0920000076f, 0.152999997f), 1);
            DOTween.To(() => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.474750012f, 0.0948282704f), 1);
            DOTween.To(() => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.520250082f, 0.170300826f), 1);
            DOTween.To(() => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.430551261f, 0.0991290957f), 1);
            DOTween.To(() => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.472250015f, 0.168129101f), 1);
            DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.296000004f, 0.112225451f), 1);
            DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.335000008f, 0.168129101f), 1);
            DOTween.To(() => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.631472409f, 0.112225451f), 1);
            DOTween.To(() => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.66900003f, 0.168129101f), 1);
            //Overflow button tween below
            DOTween.To(() => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.6743338f, 0.1147097f), 1);
            DOTween.To(() => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.7042883f, 0.1681291f), 1);

            fullText = false;
            subMenuIsOpen = false;
        }
        else if (!subMenuIsOpen) 
        {
            simText.text = storyManager.currentChapter.fullText;
            
            //Min: Vector2(0.287,0.234405026)
            //Max: Vector2(0.69599998,0.349900007)
            DOTween.To(() => GameObject.Find("BottomPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("BottomPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(1, 0.26642552f), 1);
            DOTween.To(() => GameObject.Find("SimScriptText").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SimScriptText").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.975500643f, 0.25339514f), 1);
            DOTween.To(() => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.287f, 0.234405026f), 1);
            DOTween.To(() => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ModuleControlPanel").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.7320001f, 0.349900007f), 1);

            Vector2 SubmenuMinValue = new Vector2(0.342369974f, 0.112225451f);
            Debug.Log("MinDiff is: " + MinDiff.x + "," + MinDiff.y);
            float SubmenuMinValuex = SubmenuMinValue.x;
            float SubmenuMinValuey = SubmenuMinValue.y;
            SubmenuMinValuex -= MinDiff.x;
            SubmenuMinValuey -= MinDiff.y;
            Debug.Log("SubmenuMinValuex: " + SubmenuMinValuex);
            Debug.Log("SubmenuMinValuey: " + SubmenuMinValuey);
            Vector2 SubmenuMaxValue = new Vector2(0.378842503f, 0.168129101f);
            SubmenuMaxValue.x -= MaxDiff.x;
            SubmenuMaxValue.y -= MaxDiff.y;
            SubmenuMaxValue -= MaxDiff;
            Debug.Log("SubmenuMinValue is: " + SubmenuMinValue.x + "," + SubmenuMinValue.y);

            //Look here for CollapseSubMenuButton issue, potential isseu with values used for min/max
            DOTween.To(() => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.342369974f, 0.112225451f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ExpandSubmenuButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.378842503f, 0.168129101f) - MaxDiff), 1);
            //DOTween.To(() => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.342369974f, 0.112225451f) - MinDiff), 1);
            //DOTween.To(() => GameObject.Find("CollapseSubmenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("CollapseSubmenuButton ").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.378842503f, 0.168129101f) - MaxDiff), 1);

            DOTween.To(() => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.578000009f, 0.112225451f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("SoundOnButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.617000043f, 0.168129101f) - MaxDiff), 1);
            DOTween.To(() => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.389685035f, 0.112225451f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("BackButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.424000025f, 0.168129101f) - MaxDiff), 1);
            DOTween.To(() => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.526000023f, 0.112225451f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("ForwardButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.564999998f, 0.168129101f) - MaxDiff), 1);
            //DOTween.To(() => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.671000004f, 0.1121291f), 1);
            //DOTween.To(() => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextSlider").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.791000009f, 0.152999997f), 1);
            //DOTween.To(() => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.0610000044f, 0.103000008f), 1);
            //DOTween.To(() => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("MenuButton").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.0920000076f, 0.152999997f), 1);
            DOTween.To(() => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.474750012f, 0.0948282704f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("PlayButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.520250082f, 0.170300826f) - MaxDiff), 1);
            DOTween.To(() => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.430551261f, 0.0991290957f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("PauseButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.472250015f, 0.168129101f) - MaxDiff), 1);
            DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.296000004f, 0.112225451f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("HomeButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.335000008f, 0.168129101f) - MaxDiff), 1);
            DOTween.To(() => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMin = dest, (new Vector2(0.631472409f, 0.112225451f) - MinDiff), 1);
            DOTween.To(() => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("TextSizeButton").GetComponent<RectTransform>().anchorMax = dest, (new Vector2(0.66900003f, 0.168129101f) - MaxDiff), 1);
            //Overflow button tween below
            DOTween.To(() => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMin, dest => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMin = dest, new Vector2(0.6743338f, 0.1147097f) - MinDiff, 1);
            DOTween.To(() => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMax, dest => GameObject.Find("OverflowNextPage").GetComponent<RectTransform>().anchorMax = dest, new Vector2(0.7042883f, 0.1681291f) - MaxDiff, 1);

            fullText = true;
            subMenuIsOpen = true;

        }
       
    }
}
