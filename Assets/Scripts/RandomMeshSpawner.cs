using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMeshSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Префаб объекта.
    [SerializeField] private MeshFilter meshFilter; // Компонент MeshFilter прикрепленный к мешу.

    private void Start()
    {
        GenerateObjectsOnMesh();
    }

    private void GenerateObjectsOnMesh()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        int vertexCount = vertices.Length;

        for (int i = 0; i < vertexCount; i += 2) // Увеличиваем счетчик на 2 при каждой итерации цикла.
        {
            Vector3 vertex = vertices[i];
            Vector3 point = meshFilter.transform.TransformPoint(vertex);

            Instantiate(prefab, point, Quaternion.identity);
        }
    }
    public void GenerateObjectOneRandom()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        int vertexCount = vertices.Length;

        // Генерируем случайный индекс вершины.
        int randomIndex = Random.Range(0, vertexCount);
        

        // Получаем случайную вершину.
        Vector3 randomVertex = vertices[randomIndex];

        //Test
        Debug.Log(randomVertex);

        // Создаем объект на позиции случайной вершины.
        Instantiate(prefab, randomVertex, Quaternion.identity);
    }
}