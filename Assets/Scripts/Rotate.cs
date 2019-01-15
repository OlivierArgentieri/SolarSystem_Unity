using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] protected float speed;

    [SerializeField] protected bool reverseRotate = false;


	// Update is called once per frame
	void Update () {
        if(reverseRotate)
		    GetComponent<Transform>().Rotate(Vector3.up, -Time.deltaTime*speed);

        else
            GetComponent<Transform>().Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
