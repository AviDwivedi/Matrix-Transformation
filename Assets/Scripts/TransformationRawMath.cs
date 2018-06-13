using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationRawMath : MonoBehaviour {
    public GameObject[] vertecies;
    public Vector3[] vertexOrigions;

    public Vector3 translation;
    public Vector3 rotation;
    public Vector3 scale;



	void Start () {
        vertecies = GameObject.FindGameObjectsWithTag( "Vertex" );
        vertexOrigions = new Vector3[vertecies.Length];
        
        for(int i=0; i<vertecies.Length; i++) {
            vertexOrigions[i] = vertecies[i].transform.position - transform.position;
        }

    }
	
    
	void Update () {
        ApplyTransfomation();
       
	}

    void ApplyTransfomation() {

        for (int i = 0; i < vertecies.Length; i++)
        {
            Vector3 newTransform;
            newTransform = vertexOrigions[i];
            newTransform = ApplyScale(newTransform);
            newTransform = ApplyTranslation(newTransform);
            newTransform = ApplyRotation(newTransform);
            

            vertecies[i].transform.position = newTransform;
        }

    }


    Vector3 ApplyTranslation(Vector3 _point) {
        return _point + translation;
    }
    

    Vector3 ApplyScale(Vector3 _point) {
       
          
        _point.x = _point.x * scale.x;
        _point.y = _point.y * scale.y;
        _point.z = _point.z * scale.z;

           

        return _point;
    }


    Vector3 ApplyRotation(Vector3 _point) {

        _point = RotationAxisX(_point);
        _point = RotationAxisY(_point);
        _point = RotationAxisZ(_point);

        return _point;
    }

    Vector3 RotationAxisX(Vector3 _point) {
        Vector3 newPoint = _point;

        newPoint.y = _point.y * Mathf.Cos(rotation.x) + _point.z * Mathf.Sin(rotation.x);
        newPoint.z = _point.y *-1 * Mathf.Sin(rotation.x) + _point.z * Mathf.Cos(rotation.x);

        return newPoint;
    }
    Vector3 RotationAxisY(Vector3 _point)
    {
        Vector3 newPoint = _point;

        newPoint.x = _point.x * Mathf.Cos(rotation.y) + _point.z * -1 * Mathf.Sin(rotation.y);
        newPoint.z = _point.x *  Mathf.Sin(rotation.y) + _point.z * Mathf.Cos(rotation.y);

        return newPoint;
    }
    Vector3 RotationAxisZ(Vector3 _point)
    {
        Vector3 newPoint = _point;

        newPoint.x = _point.x * Mathf.Cos(rotation.z) + _point.y * Mathf.Sin(rotation.z);
        newPoint.y = _point.x * -1 * Mathf.Sin(rotation.z) + _point.y * Mathf.Cos(rotation.z);

        return newPoint;
    }
}