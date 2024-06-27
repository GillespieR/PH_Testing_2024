using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationTimer : MonoBehaviour
{

    public float elapsedTime;
    public float pausedTime;

    public bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void StartTimer() 
    {        
        elapsedTime = 0f;
        startTimer = true;
    }

    public void EndTimer() 
    {

        startTimer = false;
    }

    public void PauseTimer() 
    {
        startTimer = false;
        pausedTime = elapsedTime;
    }

    public void ResumeTimer() 
    {
        startTimer = true;

        if(pausedTime != 0) 
        {
            pausedTime = 0f;
        }
        
    }

    public void ResetTimer() 
    {
        startTimer = false;
        elapsedTime = 0f;
    }
}
