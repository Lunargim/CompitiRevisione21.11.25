using System;
using UnityEngine;

public class Task3 : ATask
{
    public string taskId
    {
        get { return "ID345"; }
        set { taskId = "ID345"; }
    }

    public string taskName
    {
        get { return "Task3"; }
        set { taskName = "Task3"; }
    }

    public string description
    {
        get { return "Premi tre volte la barra spaziatrice"; }
        set { description = "Premi tre volte la barra spaziatrice"; }
    }

    public bool isStarted
    {
        get { return false; }
        set { isStarted = false; }
    }

    public bool isCompleted
    {
        get { return false; }
        set { isCompleted = false; }
    }

    public event Action OnTaskStart;
    public event Action OnTaskCompleted;

    private int _counter = 0;
    

    public override void CheckClicks()
    {
        if (isStarted)
        {
            OnTaskStart?.Invoke();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _counter++;
            }
            else if (!Input.GetKeyDown(KeyCode.Space) && Input.anyKeyDown)
            {
                _counter = 0;
            }

            if (_counter == 3)
            {
                isCompleted = true;
                OnTaskCompleted?.Invoke();
            }
        }
    }
}