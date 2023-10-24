using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private SnakeController controller;
    private RandomMeshSpawner spawner;

    //Поиск объектов и получение из них нужных компонентов на сцене.
    private void Start()
    {
        controller = GameObject.Find("Snake_Head").GetComponent<SnakeController>();
        spawner = GameObject.Find("AppleMesh").GetComponent<RandomMeshSpawner>();
    }

    //Действие при сборе объекта игроком.
    private void OnTriggerEnter(Collider other)
    {
        controller.GrowSnake();
        spawner.GenerateObjectOneRandom();
        Destroy(gameObject);
    }
}
