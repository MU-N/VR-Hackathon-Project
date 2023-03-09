using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRHackathon
{
    public class LevelManager : MonoBehaviour
    {
        public GameObject enviromentManager;
        public Image O2fillImage;
        public Image Co2fillImage;
        // The current CO2 level
        public  float maxTreeCounts=2;
        private Emanager envormentScript;
        private float co2Level = 0;


        public float AtmosThickness = 3.5f;
        public float FogThickness = .15f;
        public float fadeTime = 8f;
        private float fogChangeRate;
        private float atomicChangeRate;

        // Start is called before the first frame update
        void Start()
        {
            // Subscribe to the TreePlanted event
            Dirt.BalanceEnviroment += OnTreePlanted;
            envormentScript=enviromentManager.GetComponent<Emanager>();
            O2fillImage = GameObject.FindWithTag("O2Image").GetComponent<Image>() ;
            Co2fillImage = GameObject.FindWithTag("Co2Image").GetComponent<Image>() ;
 

            envormentScript.ChangeEnviromentRender(AtmosThickness, FogThickness);
      
            co2Level = maxTreeCounts;
            fogChangeRate = FogThickness / maxTreeCounts;
            atomicChangeRate = AtmosThickness / maxTreeCounts;
        }

        // Method that will be called when the TreePlanted event is raised
        private void OnTreePlanted()
        {
         

            if (co2Level - 1 >= 0)
            {
                co2Level -= 1;

                O2fillImage.fillAmount +=1/maxTreeCounts;
                Co2fillImage.fillAmount = co2Level / maxTreeCounts;
             
               // FogThickness -= fogChangeRate;
                if (FogThickness<0)
                {
                    FogThickness = 0;
                }
                    

                StartCoroutine(ChangeFogAndAtmosThicknessOverTime(FogThickness - fogChangeRate, AtmosThickness- atomicChangeRate, fadeTime));
              
                 //envormentScript.ChangeEnviromentRender(AtmosThickness, FogThickness);

              

                if (co2Level == 0)
                {
                    WinTheGame();
                }
            }
        }

        public void WinTheGame()
        {
            StartCoroutine(ChangeFogAndAtmosThicknessOverTime(0, .66f, fadeTime));

           // envormentScript.ChangeEnviromentRender(.66f, 0);
             
        }

        private IEnumerator ChangeFogAndAtmosThicknessOverTime(float targetFogThickness, float targetAtmosThickness, float duration)
        {
            float startFogThickness = FogThickness;
            float startAtmosThickness = AtmosThickness;
            float timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                FogThickness = Mathf.Lerp(startFogThickness, targetFogThickness, timeElapsed / duration);

                AtmosThickness = Mathf.Lerp(startAtmosThickness, targetAtmosThickness, timeElapsed / duration);
                timeElapsed += Time.deltaTime;

                // Call environment script to update the render settings
                envormentScript.ChangeEnviromentRender(AtmosThickness, FogThickness);

                yield return null;
            }

            FogThickness = targetFogThickness;
            AtmosThickness = targetAtmosThickness;

            // Call environment script to update the render settings one last time
           // envormentScript.ChangeEnviromentRender(AtmosThickness, FogThickness);
        }




        private void OnValidate()
        {
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", AtmosThickness);
            RenderSettings.fogDensity = FogThickness;
        }
    }
}
