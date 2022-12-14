using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessingManager : MonoBehaviour
{

    public static bool postProcessing = true;
    [SerializeField] Toggle toggle;

    private void Start()
    {
        toggle.isOn = postProcessing;
    }

    public void PostOnOff(bool value)
    {
        postProcessing = toggle.isOn;
    }


}
