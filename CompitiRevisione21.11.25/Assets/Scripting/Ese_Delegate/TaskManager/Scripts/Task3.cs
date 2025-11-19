using System;
using UnityEngine;

public class Task3 : ATask
{
    public override string taskId
    {
        get { return "ID345"; }
        set { taskId = "ID345"; }
    }

    public override string taskName
    {
        get { return "Task3"; }
        set { taskName = "Task3"; }
    }

    public override string description
    {
        get { return "Premi tre volte la barra spaziatrice"; }
        set { description = "Premi tre volte la barra spaziatrice"; }
    }

    public override bool isStarted
    {
        get { return false; }
        set { isStarted = false; }
    }

    public override bool isCompleted
    {
        get { return false; }
        set { isCompleted = false; }
    }

    public override event Action OnTaskStart;
    public override event Action OnTaskCompleted;

    private int _counter = 0;


    public void Update()
    {
        CheckClicks();
    }

    public override void CheckClicks()
    {
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