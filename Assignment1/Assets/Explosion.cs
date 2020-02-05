using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Explosion : MonoBehaviour
{
    public GameObject earth;
    public GameObject meteor;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static float Distance(Vector3 a, Vector3 b)
    {
        float diff_x = a.x - b.x;
        float diff_y = a.y - b.y;
        float diff_z = a.z - b.z;
        return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Earth's 3D position: " + earth.transform.position+ meteor.transform.position);
        Vector3 radiusEarth = earth.transform.lossyScale/2;
        Vector3 radiusMeteor = meteor.transform.lossyScale / 2;
        

        Vector3 positionEarth = earth.transform.position;
        Vector3 positionMeteor = meteor.transform.position;

        float positionDistance = Distance(positionEarth, positionMeteor);
        Debug.Log("Position distance: " + positionDistance);
        float radiusDistance = Distance(radiusEarth, radiusMeteor);
        Debug.Log("Radius distance: " + radiusDistance);

        bool isColiding =  positionDistance < radiusDistance;
        Debug.Log("Coliding " + isColiding);
        

    }
}
