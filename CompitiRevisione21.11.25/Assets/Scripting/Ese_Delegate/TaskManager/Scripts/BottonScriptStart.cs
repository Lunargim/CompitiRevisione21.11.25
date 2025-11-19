using UnityEngine;
using System;

public class BottonScriptStart : MonoBehaviour
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
