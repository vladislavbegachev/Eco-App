using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт, определяющий свойства объектов мусора
// Скрипт должен быть привязан к объекту, который нужно перетаскивать.

public class Draggable : MonoBehaviour
{
    public static int progress = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.layer == 7)
         {
             if  (gameObject.tag != "органика" && gameObject.tag != "утилизация")   // специальное условие для бака с неорганикой на первом уровне
             {
                 gameObject.SetActive(false);
                 progress ++;
             }
         }
        if (other.gameObject.layer == 3) //номер слоя, на котором находятся контейнеры
        {
            if (gameObject.tag == other.tag) //правильно
            {
                gameObject.SetActive(false);
                progress ++;
            }
            else //неправильно
            {
                
            }   
        }
    }
}

