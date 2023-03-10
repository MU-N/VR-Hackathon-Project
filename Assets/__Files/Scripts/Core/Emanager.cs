using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRHackathon
{
    public class Emanager : MonoBehaviour
    {
        public Material skyMat;

        // Start is called before the first frame update



        // Update is called once per frame
        public void ChangeEnviromentRender(float AtmosThickness,float fogThikness)
        {
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", AtmosThickness);
            RenderSettings.fogDensity = fogThikness;
        }
    }
}
