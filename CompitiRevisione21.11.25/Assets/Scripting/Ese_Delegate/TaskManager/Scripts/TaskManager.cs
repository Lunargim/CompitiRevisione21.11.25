using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] public List<ATask> Tasks = new List<ATask>();
    [SerializeField] public TextMeshProUGUI textTask;
    [SerializeField] public Button startButton;
    [SerializeField] public Button completedButton;
    private int _index = 0;
    public ATask currentTask;
    public ATask nextTask;

    public void Start()
    {
        currentTask = Tasks[_index];
        EnableButtons();
    }
    
    public void DisplayText()
    {
        textTask.text = currentTask.description;
    }
    
    public void Update()
    {
        if (currentTask.isStarted)
        {
            DisplayText();
            currentTask.CheckClicks();
        }
    }


    public ATask GetNextTask(int index)
    {
        nextTask = Tasks[index+1];
        return nextTask;
    }


    public void DisableButtons()
    {
        startButton.enabled = false;   
        completedButton.enabled = false;
    }

    public void EnableButtons()
    {
        startButton.enabled = true;
        completedButton.enabled = true;
    }

    public void SetStartingTask()
    {
        currentTask.isStarted = true;
    }

    public void OnEnable()
    {
        BottonScriptStart.OnBottonClicked += SetStartingTask;
    }

    public void OnDisable()
    {
        BottonScriptStart.OnBottonClicked -= SetStartingTask;
    }
    
}
