using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceEventRaiser : MonoBehaviour
{

    private Stack<IChoiceHandler> _choiceHandlers = new Stack<IChoiceHandler>();

    public IChoiceHandler CurrentChoiceHandler { get { return _choiceHandlers.Peek(); } }

    public void Push(IChoiceHandler choiceHandler)
    {
        _choiceHandlers.Push(choiceHandler);
    }

    public void Pop()
    {
        _choiceHandlers.Pop();
    }

    public void OnUIChoice(int choice)
    {
        if (CurrentChoiceHandler != null)
        {
            CurrentChoiceHandler.OnChoice(choice);
        }
    }
}
