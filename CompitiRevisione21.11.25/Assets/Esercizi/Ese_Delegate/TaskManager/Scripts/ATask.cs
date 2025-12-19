using System;
using UnityEngine;

public abstract class ATask : MonoBehaviour
{
    private string _taskId { get; set; }
    private string _taskName { get; set; }
    public string description { get; set; }
    private bool _isStarted { get; set; }
    private bool _isCompleted { get; set; }
    
    public static event Action OnTaskStart;
    
    public static event Action OnTaskCompleted;

    public abstract void CheckClicks();

}
