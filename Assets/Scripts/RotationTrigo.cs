using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrigo : MonoBehaviour
{
    [SerializeField]
    protected GameObject originGameObject;
    
    [SerializeField]
    protected float vitesse;

    [SerializeField]
    protected float distance;

    private float time;

    
	// Use this for initialization
	void Start ()
	{
	    distance += originGameObject.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    time = Time.time;
	    float x = originGameObject.transform.position.x + Mathf.Cos(time * vitesse) * distance;
	    float y = originGameObject.transform.position.y + 0;
	    float z = originGameObject.transform.position.z + Mathf.Sin(time * vitesse) * distance;

        GetComponent<Transform>().position = new Vector3(x, y, z);
	}
}
