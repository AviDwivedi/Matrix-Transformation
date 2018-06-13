using UnityEngine;
using System.Collections;

public class MatrixTransformationUnity : MonoBehaviour
{
    public Vector3 translation;
    public Vector3 eulerAngles;
    public Vector3 scale = new Vector3(1, 1, 1);

    public GameObject[] vertecies;
    public Vector3[] vertexOrigions;

    // Use this for initialization
    void Start()
    {
        vertecies = GameObject.FindGameObjectsWithTag("Vertex");
        vertexOrigions = new Vector3[vertecies.Length];

        for (int i = 0; i < vertecies.Length; i++)
        {
            vertexOrigions[i] = vertecies[i].transform.position - transform.position;
        }

    }


    void Update()
    {
        Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        Matrix4x4 m = Matrix4x4.TRS(translation, rotation, scale);
        int i = 0;
        while (i < vertecies.Length)
        {
            vertecies [i].transform.position = m.MultiplyPoint3x4(vertexOrigions[i]);
            i++;
        }
        
    }
}