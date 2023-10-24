using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    // Переменные для скорости движения всех объектов, из которых состоит игрок.
    [SerializeField] private float MoveSpeed = 5;
    [SerializeField] private float SteerSpeed = 180;
    [SerializeField] private float BodySpeed = 5;
    [SerializeField] private int Gap = 10;

    // Ссылка на объект тела змейки
    [SerializeField] private GameObject BodyPrefab;

    [SerializeField] private DynamicJoystick _joystick;

    // Списки которые хранят данные о каждой части тела игрока.
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Вызываем в методе start функцию создания нового тела, для того чтобы на старте змея уже состояла из 5 элементов.
    void Start() {
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    void Update() {

        // Постоянное передвижение вперед.
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Поворот
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        // Вычесление повыорота исходя из данных экранного joystick.
        Vector3 rotationDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (rotationDirection != Vector3.zero)
        {
            // Поворот змейки.
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, SteerSpeed * Time.deltaTime);
        }

        // Хранение позиции в истории.
        PositionsHistory.Insert(0, transform.position);

        // Перемещение частей тела.
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Перемещение частей тела до поворота.
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // изменение повыорота частей тела змеи.
            body.transform.LookAt(point);

            index++;
        }
    }

    public void GrowSnake() {
        // Создание новой части тела.
        // Добавление ее в список.
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }
}