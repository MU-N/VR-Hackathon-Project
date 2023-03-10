using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public int DirtN2Level;
    public bool fertile;
    public bool wet;
    public bool seeded;
    public int seedType;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject currTree;
    public Material oriMat;
    public Material wetMat;


    public static event Action BalanceEnviroment;

    // Method that will be called when the tree is planted
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            if (wet|| !seeded)
            {
                return;
            }
            wet = true;
           
            GetComponent<MeshRenderer>().material = wetMat;
            if(currTree)
            {
                currTree.GetComponent<Animator>().SetBool("Grow1", true);
                BalanceEnviroment.Invoke();
            }
         
        }

        if (!seeded && collision.gameObject.CompareTag("Seed"))
        {      
                seedType = collision.gameObject.GetComponent<Seed>().sType;
                seeded = true;
                Destroy(collision.gameObject);

                if(seedType==1)
                {
                    currTree = tree1;
                }
                else if(seedType==2)
                {
                    currTree = tree2;
                }
                else if(seedType==3)
                {
                    currTree = tree3;
                }

                currTree.SetActive(true);            
        }
    }
}
