using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCameraMatcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Camera>().fieldOfView = transform.parent.gameObject.GetComponent<Camera>().fieldOfView;
        GetComponent<Camera>().farClipPlane = transform.parent.gameObject.GetComponent<Camera>().farClipPlane;
    }
}
