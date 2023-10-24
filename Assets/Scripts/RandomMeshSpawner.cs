using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMeshSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // ������ �������.
    [SerializeField] private MeshFilter meshFilter; // ��������� MeshFilter ������������� � ����.

    private void Start()
    {
        GenerateObjectsOnMesh();
    }

    private void GenerateObjectsOnMesh()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        int vertexCount = vertices.Length;

        for (int i = 0; i < vertexCount; i += 2) // ����������� ������� �� 2 ��� ������ �������� �����.
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

        // ���������� ��������� ������ �������.
        int randomIndex = Random.Range(0, vertexCount);
        

        // �������� ��������� �������.
        Vector3 randomVertex = vertices[randomIndex];

        //Test
        Debug.Log(randomVertex);

        // ������� ������ �� ������� ��������� �������.
        Instantiate(prefab, randomVertex, Quaternion.identity);
    }
}