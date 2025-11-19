using System;
using UnityEngine;

public class Task1 : ATask
{
    public string taskId { get { return "ID123"; } set => taskId = "ID123"; }
    public string taskName { get { return "Task1"; } set => taskName = "Task1";  }

    private string _description;
    public string description
    {
        get { return "Clicca tre volte il tasto destro"; }
        set => _description = "Clicca tre volte il tasto destro"; 
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

            if (Input.GetMouseButtonDown(1))
            {
                _counter++;
            }
            else if (!Input.GetMouseButton(1) && Input.anyKeyDown)
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
