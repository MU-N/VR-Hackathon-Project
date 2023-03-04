using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handAnim : MonoBehaviour
{
    //links the trigger inputs to hand animator params

    public InputActionProperty pinchanimact;
    public InputActionProperty gripanimact;

    public Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float triggerVal =  pinchanimact.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerVal);

        float gripVal = gripanimact.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripVal);
    }
}
