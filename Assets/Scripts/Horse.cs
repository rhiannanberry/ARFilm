﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cowboy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip() {
        transform.localScale = new Vector3(1,1,-1);
    }
}
