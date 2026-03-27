using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateModel : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
{
    [SerializeField] private Transform modelTransform;
    public UnityEvent<float> OnModelRotated;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor;
    private Quaternion actualRotation;// rotación hacia en control cuando comienza en agarre.
    private Quaternion initialModelRotation; // rotación del modelo cuando comienza el agarre.

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        interactor = args.interactorObject;

        // encuentra la rotación hacia el control cuando comienza el agarre, y la junta con la rotación del modelo.
        Vector3 relativePos = interactor.transform.position - modelTransform.position;
        Quaternion relativeRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        initialModelRotation = modelTransform.rotation;
        actualRotation = Quaternion.Euler(0f, -initialModelRotation.eulerAngles.y + relativeRotation.eulerAngles.y, 0f);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
            {
                MakeModelRotation();
            }
        }
    }

    private void MakeModelRotation()
    {
        // obtiene la rotación relativa al control.
        Vector3 relativePos = interactor.transform.position - modelTransform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        float desiredYRotation = rotation.eulerAngles.y; // get the Y component

         // obtiene la rotación final, substrayendo la rotación al inicio del agarre para que el objeto mantenga su rotación inicial. 
        Quaternion newRotation = Quaternion.Euler(0f, desiredYRotation - actualRotation.eulerAngles.y, 0f);
        modelTransform.rotation = newRotation; 
    }
}

