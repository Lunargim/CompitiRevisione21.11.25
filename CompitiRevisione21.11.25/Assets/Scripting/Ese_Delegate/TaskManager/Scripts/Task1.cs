using System;
using UnityEngine;

public class Task1 : ATask
{
    public override string taskId { get { return "ID123"; } set {taskId = "ID123"; } }
    public override string taskName { get { return "Task1"; } set {taskName = "Task1"; } }

    public override string description
    {
        get { return "Clicca tre volte il tasto destro"; }
        set { description = "Clicca tre volte il tasto destro"; }
    }
    public override bool isStarted
    {
        get { return false;} set { isStarted = false; }
    }

    public override bool isCompleted
    {
        get { return false;} set { isCompleted = false; }
    }

    public event Action OnTaskStart;
    public event Action OnTaskCompleted;
    
    private int _counter = 0;
    

    public override void CheckClicks()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _counter++;
        }else if (!Input.GetMouseButton(1) && Input.anyKeyDown)
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
