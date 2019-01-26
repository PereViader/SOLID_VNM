using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceEventRaiser : MonoBehaviour
{

    private ChoiceHandler _choiceHandler;

    public ChoiceHandler ChoiceHandler
    {
        get { return _choiceHandler; }
        set
        {
            _choiceHandler = value;
            enabled = _choiceHandler != null;
        }
    }

    public void OnUIChoice(int choice)
    {
        if (ChoiceHandler != null)
        {
            ChoiceHandler.OnChoice(choice);
        }
    }
}
