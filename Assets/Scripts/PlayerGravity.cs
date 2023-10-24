using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    //Объект с компонентом скрипта, к которому будет притягиваться игрок.
    [SerializeField] AppleScript attractorApple;
    //Переменная компонента Transform, для удобства работы с положением персонажа.
    private Transform playerTransform;

    private void Start()
    {
        //Задаем стартовые параметры для rb игрока.
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        //Указываем в вспомогательную переменную стартовые значения.
        playerTransform = transform;
    }

    private void FixedUpdate()
    {
        //Проверяем имеет ли что-то поле attractorApple.
        if (attractorApple)
        {
            //Вызываем метод притяжения.
            attractorApple.Attract(playerTransform);
        }
    }
}
