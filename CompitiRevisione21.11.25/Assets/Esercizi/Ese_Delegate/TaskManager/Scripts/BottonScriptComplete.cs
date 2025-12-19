using System;
using UnityEngine;

public class BottonScriptComplete : MonoBehaviour
{
    public static event Action OnBottonClicked;

    public void OnClick()
    {
        OnBottonClicked?.Invoke();
    }
    
    public void OnEnable()
    {
        
    }
    public void OnDisable()
    {
        
    }
}
