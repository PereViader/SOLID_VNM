using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM;
using Zenject;
using SOLID_VNM.Scenes;

public class DialogueTriggerer : MonoBehaviour
{
    [SerializeField]
    private XNodeVisualNovelGraph _dialogueNodeGraph;

    [Inject]
    private Core _core;

    [Inject]
    private VisualNovelGraphImpl.Factory _visualNovelGraphFactory;

    private void Start()
    {
        _core.Play(_visualNovelGraphFactory.Create(_dialogueNodeGraph));
    }
}
