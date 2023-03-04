using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVisualManager : MonoBehaviour
{
    public Material defaultHandMat;
    public Material climbHandMat;

    [SerializeField] private SkinnedMeshRenderer handRenderer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ClimbAnchor>())
        {
            handRenderer.material = climbHandMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ClimbAnchor>())
        {
            handRenderer.material = defaultHandMat;
        }
    }
}
