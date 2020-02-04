using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject earth;
    public GameObject meteor;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Earth's 3D position: " + earth.transform.position+ meteor.transform.position);
        Vector3 radiusEarth = earth.transform.lossyScale/2;
        Vector3 radiusMeteor = meteor.transform.lossyScale / 2;
        

        Vector3 positionEarth = earth.transform.position;
        Vector3 positionMeteor = meteor.transform.position;

        float positionDistance = Vector3.Distance(positionEarth, positionMeteor);
        Debug.Log("Position distance: " + positionDistance);
        float radiusDistance = Vector3.Distance(radiusEarth, radiusMeteor);
        Debug.Log("Radius distance: " + radiusDistance);

        bool isColiding =  positionDistance < radiusDistance;
        Debug.Log("Coliding " + isColiding);
        

    }
}
