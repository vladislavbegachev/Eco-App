using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{
    public GameObject LevelTexting;
    public GameObject ProgressTexting;
    private int Level;
    // Start is called before the first frame update
    void Start()
    {
        Level = SceneManager.GetActiveScene().buildIndex;
        switch (Level)
        {
            case 3:
                ToIndicate(1, "Легкая");
                break;
            case 4:
                ToIndicate(1, "Средняя");
                break;
            case 5:
                ToIndicate(1, "Тяжелая");
                break;
            case 6:
                ToIndicate(2, "Легкая");
                break;
            case 7:
                ToIndicate(2, "Средняя");
                break;
            case 8:
                ToIndicate(2, "Тяжелая");
                break;
            case 9:
                ToIndicate(3, "Легкая");
                break;
            case 10:
                ToIndicate(3, "Средняя");
                break;
            case 11:
                ToIndicate(3, "Невозможная");
                break;
            case 141:
                ToIndicate(4, "Легкая");
                break;
            case 134:
                ToIndicate(4, "Средняя");
                break;
            case 1241:
                ToIndicate(4, "Невозможная");
                break;            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTexting.GetComponent<Text>().text = $"Прогресс: {LevelController.percentageString}%";
    }
    void ToIndicate(int level, string difficulty)
    {
        LevelTexting.GetComponent<Text>().text = $"Уровень: {level}\nCложность: {difficulty}";
    }
}
