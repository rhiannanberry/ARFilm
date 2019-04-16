using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform horse;
    public Transform horseHips;
    public Transform hips;
    public Transform rightHand;
    public Transform hat;
    public Transform container;
    public Transform gun;
    public Transform gunDummy;

    public AudioClip gunSound;

    AudioSource aus;
    Vector3 offset, hipPosition;
    bool parented = true;
    bool offsetset = false;
    void Start()
    {
        aus = GetComponent<AudioSource>();
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

    void ChangeGunParent() {
        //gun.position = new Vector3(.209f,.252f,-2.17f);
        gun.SetParent(rightHand);
        gun.position = gunDummy.position;
        gun.rotation = gunDummy.rotation;
    }

    void PlayGunSound() {
        aus.clip = gunSound;
        aus.Play();
    }

    void DeparentHat() {
        hat.SetParent(container);
    }

}
