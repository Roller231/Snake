using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        if (target)
        {
            // Получаем направление к цели.
            Vector3 direction = target.position - transform.position;


            // Если вектор направления ненулевой.
            if (direction != Vector3.zero)
            {
                // Вычисляем кватернион поворота.
                Quaternion rotation = Quaternion.LookRotation(direction);

                // Применяем поворот объекту.
                transform.rotation = rotation;
            }
        }
    }

}