using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldScaler : MonoBehaviour
{
    [SerializeField] private InputActionReference scaleActionReference;
    [SerializeField] private GameObject worldObj;
    public bool scaledUp;

   // Start is called before the first frame update
   void Start()
    {
        scaleActionReference.action.performed += onScale;
    }

    void onScale(InputAction.CallbackContext obj)
    {
        if(scaledUp)
        {
            worldObj.transform.localScale = Vector3.one;
        }

        else
        {
            worldObj.transform.localScale = Vector3.one * 5;
        }
    }
}
