using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class FaceMovement : MonoBehaviour
{   
    public Material leftEye, rightEye, leftEyebrow, rightEyebrow;

    [Space]
    [Header("Eyes Offset")]
    [Range(-1f,1f)]
    public float horizontal = 0;

    [Range(-1f,1f)]
    public float vertical = 0;

    [Header("Eyes Size")]
    [Range(0f,4f)]
    public float xEyeScale = 1;

    [Range(0f,4f)]
    public float yEyeScale = 1;
    [Space]


    [Header("Look Direction")]
    public bool mirrorDirection = false;

    [Range(-1f,1f)]
    public float xLook = 0;

    [Range(-1f,1f)]
    public float yLook = 0;

    [Space]

    [Header("Pupil Size")]

    [Range(0f,4f)]
    public float xScale = 1;

    [Range(0f,4f)]
    public float yScale = 1;

    [Space]
    [Header("Eyebrows")]
    public Vector2 offset = new Vector2(0,0);
    public Vector2 scale = new Vector2(1,1);

    [Range(-3.2f, 3.2f)]
    public float rotation = 0f;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xes = 1f/xEyeScale;
        float yes = 1f/yEyeScale;

        float xles = (1f - xes)/2f;
        float yles = (1f - (yes))/2f;

        //float yls = ((1f - vertical) - (ys))/2f - (ys*(vertical/2f);


        leftEye.SetTextureOffset("_MaskTex", new Vector2(horizontal + xles, yles-vertical));
        rightEye.SetTextureOffset("_MaskTex", new Vector2(horizontal + xles, yles-vertical));
        leftEye.SetTextureScale("_MaskTex", new Vector2(xes, yes));
        rightEye.SetTextureScale("_MaskTex", new Vector2(xes, yes));


        float xs = (1f/xScale)*xes;
        float ys = (1f/yScale)*yes;


        float xls = (1f - xs)/2f;
        float yls = (1f - (ys))/2f - vertical*ys - vertical*yes;

        leftEye.SetTextureOffset("_MainTex", new Vector2(xls + (mirrorDirection?1:-1)*xLook, yls-yLook));
        leftEye.SetTextureScale("_MainTex", new Vector2(xs, ys));
        rightEye.SetTextureOffset("_MainTex", new Vector2(xls + xLook, yls-yLook));
        rightEye.SetTextureScale("_MainTex", new Vector2(xs, ys));

        Vector2 iScale = new Vector2(1f/scale.x, 1f/scale.y);

        
        Vector2 iOffset = (Vector2.one - iScale) * .5f;

        rightEyebrow.SetTextureOffset("_MainTex",iOffset + new Vector2(offset.x, -offset.y));
        leftEyebrow.SetTextureOffset("_MainTex",iOffset + new Vector2(offset.x, -offset.y));
        rightEyebrow.SetTextureScale("_MainTex",iScale);
        leftEyebrow.SetTextureScale("_MainTex",iScale);

        rightEyebrow.SetFloat("_Angle", rotation);
        leftEyebrow.SetFloat("_Angle", rotation);
    }
}
