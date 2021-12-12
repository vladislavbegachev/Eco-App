using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Скрипт, определяющий свойства объектов мусора
// Скрипт должен быть привязан к объекту, который нужно перетаскивать.

public class Draggable : MonoBehaviour
{
    public static bool _resetObject;
    public static int progress;
    void Start()
    {
        progress = 0;
        LevelController.percentageHasChanged = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.layer == 7)
         {
             if  (gameObject.tag != "органика" && gameObject.tag != "утилизация")   // специальное условие для бака с неорганикой на первом уровне
             {
                 //Destroy(gameObject);
                 gameObject.SetActive(false);
                 CheckSystem.checkCase = 1;
                 progress ++;
                 LevelController.percentageHasChanged = true;
             }
             else
             {
                 CheckSystem.checkCase = 2;
                 HeartSystem.health -= 1;
                 _resetObject = true;
             }
         }
        else if (other.gameObject.layer == 3) //номер слоя, на котором находятся контейнеры
        {
            if (gameObject.tag == other.tag) //правильно
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
                CheckSystem.checkCase = 1;
                progress ++;
                LevelController.percentageHasChanged = true;
            }
            else //неправильно
            {
                CheckSystem.checkCase = 2;
                HeartSystem.health -= 1;
                _resetObject = true;
            }   
        }
    }
}

