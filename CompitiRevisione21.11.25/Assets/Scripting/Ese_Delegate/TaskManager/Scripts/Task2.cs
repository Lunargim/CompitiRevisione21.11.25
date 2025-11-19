using System;
using UnityEngine;

public class Task2 : ATask
{
    public string taskId { get { return "ID234"; } set => taskId = "ID234";  }
    public string taskName { get { return "Task2"; } set => taskName = "Task2";  }

    public string description
    {
        get { return "Clicca tre volte il tasto sinistro"; }
        set => description = "Clicca tre volte il tasto sinistro"; 
    }
    public bool isStarted
    {
        get { return false;} set => isStarted = false; 
    }

    public bool isCompleted
    {
        get { return false;} set => isCompleted = false; 
    }
    
    public event Action OnTaskStart;
    public event Action OnTaskCompleted;
    
    private int _counter = 0;
    

    public override void CheckClicks()
    {
        if (isStarted)
        {
            OnTaskStart?.Invoke();

            if (Input.GetMouseButtonDown(0))
            {
                _counter++;
            }
            else if (!Input.GetMouseButton(0) && Input.anyKeyDown)
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

