using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameObjectDictionary : MonoBehaviour
{
    /*
    [SerializeField]
    GameObject storyManagerRef;
    */
    public Dictionary<string, GameObject> gameObjectDict = new Dictionary<string, GameObject>();
    
    public List<GameObject> assets = new List<GameObject>();

    public List<GameObject> managers = new List<GameObject>();

    public List<GameObject> UIObjects = new List<GameObject>();

    public List<GameObject> cameras = new List<GameObject>();
    
    // Start is called before the first frame update
    private void Awake()
    {
        /*
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {

            //UI layer
            if (obj.layer == 5)
            {
                UIObjects.Add(obj);
            }

            //environment layer
            if (obj.layer == 7)
            {
                assets.Add(obj);
            }

            //camera layer
            if (obj.layer == 8)
            {
                cameras.Add(obj);
            }

            //systems layer 
            if (obj.layer == 9)
            {
                managers.Add(obj);
            }
        }
        */

        Populate();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate() 
    {

        foreach(GameObject go in assets)
        {
            gameObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict.Add(go.name, go);
        }

        foreach(GameObject go in managers) 
        {
            gameObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict.Add(go.name, go);
        }

        foreach(GameObject go in cameras)
        {
            gameObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict.Add(go.name, go);
        }

        foreach (GameObject go in UIObjects)
        {
            gameObject.GetComponent<GlobalGameObjectDictionary>().gameObjectDict.Add(go.name, go);
        }

    }
}
