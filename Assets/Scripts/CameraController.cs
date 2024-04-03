using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    StoryManager storyManager;

    Camera mainCam;

    Dictionary<string, GameObject> gameObjectdictionary;

    //private Camera mainCam;

    //private CinemachineVirtualCamera vCamMain;

    GameObject wrongTarget;

    private void Awake()
    {
        storyManager = GameObject.FindWithTag("StoryManager").GetComponent<StoryManager>();
               

    }
    private void Start()
    {
        gameObjectdictionary = storyManager.globalDictionaryObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict;
        //vCamMain = gameObjectdictionary["Main_vcam"].gameObject.GetComponent<CinemachineVirtualCamera>();
        
            
            //gameObjectdictionary["WrongTarget"].gameObject.GetComponent<CinemachineVirtualCamera>();


    }

    public void SwitchCamPriority(bool riverCamTrans, bool riverToFlowTrans) 
    {

        StartCoroutine(SwitchCamPriorityCoroutine(riverCamTrans, riverToFlowTrans));
    }

    IEnumerator SwitchCamPriorityCoroutine(bool _riverCamTrans, bool _riverToFlowTrans) 
    {        

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
                //vCamMain.Priority = 1;                
                yield return null;
                break;
            }
            yield return null;
        }       
    }
}
