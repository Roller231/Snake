using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        if (target)
        {
            // �������� ����������� � ����.
            Vector3 direction = target.position - transform.position;


            // ���� ������ ����������� ���������.
            if (direction != Vector3.zero)
            {
                // ��������� ���������� ��������.
                Quaternion rotation = Quaternion.LookRotation(direction);

                // ��������� ������� �������.
                transform.rotation = rotation;
            }
        }
    }

}