using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    StoryManager storyManager;

    GameObject mainCam;
    CinemachineVirtualCamera main_VC;

    Dictionary<string, GameObject> gameObjectdictionary;

    //private Camera mainCam;

    //private CinemachineVirtualCamera vCamMain;

    GameObject wrongTarget;

    private void Awake()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
        mainCam = GameObject.FindWithTag("MainCamera").gameObject;
        //vcMain = storyManager.gameObjectDictionary["Main_VC"].GetComponent<>;      
        
    }
    private void Start()
    {
        gameObjectdictionary = storyManager.globalDictionaryObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict;
        main_VC = gameObjectdictionary["Main_VC"].gameObject.GetComponent<CinemachineVirtualCamera>();
        //vCamMain = gameObjectdictionary["Main_vcam"].gameObject.GetComponent<CinemachineVirtualCamera>();


        //gameObjectdictionary["WrongTarget"].gameObject.GetComponent<CinemachineVirtualCamera>();


    }

    public void SwitchCamPriority() 
    {

        StartCoroutine(SwitchCamPriorityCoroutine());
    }

    IEnumerator SwitchCamPriorityCoroutine() 
    {

        main_VC.Priority = 1;

        yield return null;
        /*
        //Debug.Log("Value of _riverCamTrans is" + _riverCamTrans);
        while (true) 
        {
            //Debug.Log("Value of _riverCamTrans is" + _riverCamTrans);
            if (_riverCamTrans)
            {
                yield return null;
                break;
            }
            else if(!_riverCamTrans && _riverToFlowTrans) 
            {
         
                yield return null;
                break;
            }            
            else
            {
                vCamMain.Priority = 1;
                yield return null;
                break;
            }
            yield return null;
        } 
        */
    }
}
