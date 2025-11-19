using System;
using UnityEngine;

public class Task2 : ATask
{
    public override string taskId { get { return "ID234"; } set {taskId = "ID234"; } }
    public override string taskName { get { return "Task2"; } set {taskName = "Task2"; } }

    public override string description
    {
        get { return "Clicca tre volte il tasto sinistro"; }
        set { description = "Clicca tre volte il tasto sinistro"; }
    }
    public override bool isStarted
    {
        get { return false;} set { isStarted = false; }
    }

    public override bool isCompleted
    {
        get { return false;} set { isCompleted = false; }
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
        if (Input.GetMouseButtonDown(0))
        {
            _counter++;
        }else if (!Input.GetMouseButton(0) && Input.anyKeyDown)
        {
            _counter= 0;
        }

        if (_counter == 3)
        {
            isCompleted = true;
            OnTaskCompleted?.Invoke();
        }
    }
}

