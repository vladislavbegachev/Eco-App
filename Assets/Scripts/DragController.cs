using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool _isDragActive = false;

    private Vector2 _screenPosition;

    private Vector3 _worldPosition;

    private Draggable _lastDragged;

    void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();     // Проверка, если контроллеров больше, чем 1 на сцене  // DragController[] - массив, хранящий элементы типа DragController, controllers - название
        if (controllers.Length > 1)
        {
            Destroy(gameObject); // Удалить лишние контроллеры
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragActive)
        {                                                     //    Если была инициализирована InitDrag() функция
            if (Input.GetTouch(0).phase == TouchPhase.Ended) //     Если в последнем обновлении кадра число касаний = 0
            {
                Drop();                                     // Инициализировать Drop()
                return;
            }
        }
        if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }

    }

    void InitDrag()
    {
        _isDragActive = true;
    }

    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        if (Draggable._resetObject == true)
        {
            _lastDragged.transform.position = new Vector2(0f, 0f);
            Drop();
        }
    }

    void Drop()
    {
        _isDragActive = false;
        Draggable._resetObject = false;
    }

}
