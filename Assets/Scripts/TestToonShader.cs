using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestToonShader : MonoBehaviour
{

    public Transform l;
    SkinnedMeshRenderer r;
    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SkinnedMeshRenderer>();
        r.sharedMaterials[0].SetVector("Vector3_B25F064F", l.position);
        r.sharedMaterials[1].SetVector("Vector3_B25F064F", l.position);

    }

    // Update is called once per frame
    void Update()
    {
        r.sharedMaterials[0].SetVector("Vector3_B25F064F", l.position);
        r.sharedMaterials[1].SetVector("Vector3_B25F064F", l.position);

    }
}
