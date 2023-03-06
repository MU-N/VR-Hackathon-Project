using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;

public class Pouring : MonoBehaviour
{
    public bool pour;
    public bool watered;
    public ParticleSystem pourfx;
    public float Pourangle;
    public float currangle;
    public GameObject waterPrefab;
    public Transform waterSpawnPoint;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currangle = Vector3.Angle(Vector3.down, transform.up);

        if (Vector3.Angle(Vector3.down, transform.up) < Pourangle)
        {
            pourfx.Play();
            pour = true;
            aud.Play();
            if(!watered)
            {
                Instantiate(waterPrefab, waterSpawnPoint.position, waterSpawnPoint.rotation);
                watered = true;
            }
        }
        else
        {
            pourfx.Stop();
            pour = false;
            aud.Stop();
            watered = false;
        }
    }
}