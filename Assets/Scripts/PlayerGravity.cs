using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    //������ � ����������� �������, � �������� ����� ������������� �����.
    [SerializeField] AppleScript attractorApple;
    //���������� ���������� Transform, ��� �������� ������ � ���������� ���������.
    private Transform playerTransform;

    private void Start()
    {
        //������ ��������� ��������� ��� rb ������.
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        //��������� � ��������������� ���������� ��������� ��������.
        playerTransform = transform;
    }

    private void FixedUpdate()
    {
        //��������� ����� �� ���-�� ���� attractorApple.
        if (attractorApple)
        {
            //�������� ����� ����������.
            attractorApple.Attract(playerTransform);
        }
    }
}
