using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public int NumberOfObjects;
    static bool toMove;
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

    }

    // Update is called once per frame
    void Update()
    {
         if (Draggable.progress == NumberOfObjects)
        {
          toMove = true;
          Draggable.progress = 0;
          Next();
        }
      }
    void Next()
    {
        if (toMove)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            toMove = false;
        }
    }
}
