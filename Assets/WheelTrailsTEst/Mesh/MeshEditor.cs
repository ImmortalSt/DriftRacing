using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MeshTest
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class MeshEditor : MonoBehaviour
    {
        private class Triangle
        {
            public readonly Vector3[] Vertices = new Vector3[3];
            public readonly int[] VerticesIndex = new int[3];
        }

        private Mesh _mesh;

        private List<Vector3> _meshVertices = new List<Vector3>();
        private List<int> _meshTriangles = new List<int>();

        private void Start()
        {
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh;
        }

        public void AddDotAndConnectLastTriagle(Vector3 dot)
        {
            _meshVertices.Add(dot);

            if (_meshVertices.Count >= 3)
            {
                int meshVerticesLenght = _meshVertices.Count - 1;
                Triangle triangle = new Triangle();

                triangle.Vertices[0] = _meshVertices[meshVerticesLenght];
                triangle.Vertices[1] = _meshVertices[meshVerticesLenght - 1];
                triangle.Vertices[2] = _meshVertices[meshVerticesLenght - 2];

                triangle.VerticesIndex[0] = meshVerticesLenght;
                triangle.VerticesIndex[1] = meshVerticesLenght - 1;
                triangle.VerticesIndex[2] = meshVerticesLenght - 2;

                SortTriangleClockwise(triangle);

                _meshTriangles.Add(triangle.VerticesIndex[0]);
                _meshTriangles.Add(triangle.VerticesIndex[1]);
                _meshTriangles.Add(triangle.VerticesIndex[2]);

                UpdateMesh();
            }
        }

        private void SortTriangleClockwise(Triangle target)
        {
            int lowestIndex = Utills.FindLowestZIndex(target.Vertices);
            Utills.Swap(ref target.VerticesIndex[0], ref target.VerticesIndex[lowestIndex]);
            Utills.Swap(ref target.Vertices[0], ref target.Vertices[lowestIndex]);

            float firstAngle = Vector3.Angle(Vector3.right, target.Vertices[1] - target.Vertices[0]);
            float secondAngle = Vector3.Angle(Vector3.right, target.Vertices[2] - target.Vertices[0]);


            if (firstAngle < secondAngle)
            {
                Utills.Swap(ref target.VerticesIndex[1], ref target.VerticesIndex[2]);
            }
        }

        private void UpdateMesh()
        {
            _mesh.Clear();
            _mesh.vertices = _meshVertices.ToArray();
            _mesh.triangles = _meshTriangles.ToArray();
            _mesh.Optimize();
            _mesh.RecalculateNormals();
        }
    }
}