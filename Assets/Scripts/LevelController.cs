using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    private float percentage;
    public static string percentageString;
    public int NumberOfObjects;
    private float timeRemaining = 2;
    static bool toMove;
    public static bool percentageHasChanged;
    void Awake()
    {
        LevelController[] levelcontrollers = FindObjectsOfType<LevelController>();     // Проверка, если контроллеров больше, чем 1 на сцене
        if (levelcontrollers.Length > 1)
        {
            Destroy(gameObject); // Удалить лишние контроллеры
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      percentageString = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (HeartSystem.health == 0)
        {
          if (timeRemaining > 0)
          {
                timeRemaining -= Time.deltaTime;
          }
          else
          {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          }          
        }
        if (percentageHasChanged)
        {
          ChangingPercentage();
        }
        if (Draggable.progress == NumberOfObjects)
        {
          toMove = true;
          Draggable.progress = 0;
        }
        if (toMove == true)
        {
          if (timeRemaining > 0)
          {
                timeRemaining -= Time.deltaTime;
          }
          else
          {
            GoToNext();
          }
        }
      }
    void GoToNext()
    {      
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
          SceneManager.LoadScene(0);
        }
        else
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        toMove = false;            
        }
    }
    void ChangingPercentage()
    {
      percentage = ((float) Draggable.progress / NumberOfObjects) * 100;
      percentageString = percentage.ToString("#");
      percentageHasChanged = false;
    }
}
