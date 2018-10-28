using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Graph;
using SOLID_VNM.Core;
using Zenject;

public class DialogueTriggerer : MonoBehaviour
{

    [SerializeField]
    private VNGraph _dialogueNodeGraph;

    [Inject]
    private GameLoop _gameLoop;

    private void Start()
    {
        _gameLoop.Play(_dialogueNodeGraph);
    }
}
