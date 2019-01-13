using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Graph.XNode;
using SOLID_VNM.Core;
using Zenject;
using SOLID_VNM.Graph;

public class DialogueTriggerer : MonoBehaviour
{
    [SerializeField]
    private VNGraph _dialogueNodeGraph;

    [Inject]
    private Core _core;

    [Inject]
    private VisualNovelGraphImpl.Factory _visualNovelGraphFactory;

    private void Start()
    {
        _core.Play(_visualNovelGraphFactory.Create(_dialogueNodeGraph));
    }
}
