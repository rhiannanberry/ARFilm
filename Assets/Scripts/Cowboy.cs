using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform horse;
    public Transform horseHips;
    public Transform hips;

    Vector3 offset, hipPosition;
    bool parented = true;
    bool offsetset = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (offsetset) {
            transform.position = horseHips.position - offset;
        }
    }

    void DeparentHorse() {
        offsetset = false;
    }

    void GetHipPosition() {
        hipPosition = hips.transform.position;
        Debug.Log("DDKDDKDK" + hipPosition);

    }


    void StartShoot() {
        transform.eulerAngles = transform.eulerAngles + 150f * Vector3.up; 
        transform.position = new Vector3(hipPosition.x, transform.position.y, hipPosition.z);

    }

    void CalculateHorseOffset() {
        if (!offsetset) {
            offset = horseHips.position - transform.position;
            offsetset = true;
        }
        
    }

}
