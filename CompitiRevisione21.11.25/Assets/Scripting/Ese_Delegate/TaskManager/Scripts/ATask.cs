using System;
using UnityEngine;

public abstract class ATask : MonoBehaviour
{
    public abstract string taskId  { get; set; }
    public abstract string taskName { get; set; }
    public abstract string description { get; set; }
    public abstract bool isStarted { get; set; }
    public abstract bool isCompleted { get; set; }
    
    public abstract event Action OnTaskStart;
    
    public abstract event Action OnTaskCompleted;

    public abstract void CheckClicks();

}
