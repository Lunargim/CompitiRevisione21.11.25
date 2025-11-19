using UnityEngine;

public abstract class ATask : MonoBehaviour
{
    public abstract string taskId  { get; set; }
    public abstract string taskName { get; set; }
    public abstract string description { get; set; }
    public abstract bool isStarted { get; set; }
    public abstract bool isCompleted { get; set; }

    public delegate void OnStart();
    public event OnStart OnTaskStart;
    
    public delegate void OnComplete();
    public event OnComplete OnTaskCompleted;

    public abstract void Click();

}
