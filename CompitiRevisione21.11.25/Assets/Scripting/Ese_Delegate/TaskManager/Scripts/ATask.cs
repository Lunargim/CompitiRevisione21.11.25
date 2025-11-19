using UnityEngine;

public abstract class ATask
{
    private string _taskId;
    private string _taskName;
    private string _description;
    private bool _isStarted;
    private bool _isCompleted;

    public delegate void OnStart();
    public event OnStart OnTaskStart;
    
    public delegate void OnComplete();
    public event OnComplete OnTaskCompleted;
    
}
