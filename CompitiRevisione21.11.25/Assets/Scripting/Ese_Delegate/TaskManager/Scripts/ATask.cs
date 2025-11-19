using System;
using UnityEngine;

public abstract class ATask
{
    public abstract string taskId  { get; set; }
    public abstract string taskName { get; set; }
    public abstract string description { get; set; }
    public abstract bool isStarted { get; set; }
    public abstract bool isCompleted { get; set; }
    
    public static event Action OnTaskStart;
    
    public static event Action OnTaskCompleted;

    public abstract void CheckClicks();

}
