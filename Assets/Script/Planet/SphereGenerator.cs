using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class SphereGenerator : MonoBehaviour
{
    public int subdivisions = 100;
    public float radius = 10f;
    public Texture2D heightmap;

    private void Start()
    {
        GenerateSphere();
        ApplyHeightmap();
    }

    private void GenerateSphere()
    {
        // Generate the sphere mesh as before
        // ...

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        // ...

        meshFilter.mesh = mesh;

        // Generate the mesh collider
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            meshCollider.sharedMesh = mesh;
        }
    }

    private void ApplyHeightmap()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector2 uv = mesh.uv[i];
            Color pixelColor = heightmap.GetPixel(Mathf.FloorToInt(uv.x * heightmap.width), Mathf.FloorToInt(uv.y * heightmap.height));

            // Apply height based on the grayscale value of the pixel
            vertices[i] = vertices[i] + vertices[i].normalized * pixelColor.grayscale * radius;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
