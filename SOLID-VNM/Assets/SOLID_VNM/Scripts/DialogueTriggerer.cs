using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Dialogue;
using SOLID_VNM.GameBehaviour;
using Zenject;

public class DialogueTriggerer : MonoBehaviour
{

    [SerializeField]
    private DialogueNodeGraph _dialogueNodeGraph;

    [Inject]
    private GameLoop _gameLoop;

    private void Start()
    {
        _gameLoop.Play(_dialogueNodeGraph);
    }
}
