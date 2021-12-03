using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSystem : MonoBehaviour
{
    public static int checkCase;
    public GameObject correct, incorrect;
    private float timeRemaining = 3;
    // Start is called before the first frame update
    void Start()
    {
        correct.SetActive(false);
        incorrect.SetActive(false);
        checkCase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (checkCase)
        {
            case 0:
                correct.SetActive(false);
                incorrect.SetActive(false);  
                break;            
            case 1:
                correct.SetActive(true);
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                SetInactiveAfterDelay();
                break; 
            case 2:
                incorrect.SetActive(true);
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                SetInactiveAfterDelay();                                    
                break;  
        }
    }
    void SetInactiveAfterDelay()
    {
        checkCase = 0;
    }
}
