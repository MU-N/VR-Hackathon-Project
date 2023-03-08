using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRHackathon
{
    public class Emanager : MonoBehaviour
    {
        public Material skyMat;
        public float AtmosThickness;
        public float FogThickness;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", AtmosThickness);
            RenderSettings.fogDensity = FogThickness;
        }
    }
}
