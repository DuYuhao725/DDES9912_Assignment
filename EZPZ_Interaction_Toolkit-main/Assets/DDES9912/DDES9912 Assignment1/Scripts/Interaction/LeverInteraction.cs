using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public MachineController machineController;
    public ReelController reelController;

    private void OnMouseDown()
    {
        Debug.Log("Lever clicked!");

        if (machineController == null)
        {
            Debug.LogWarning("MachineController reference is missing.");
            return;
        }

        if (reelController == null)
        {
            Debug.LogWarning("ReelController reference is missing.");
            return;
        }

        if (machineController.CanUseLever())
        {
            machineController.StartSpin();
            reelController.StartReelSpin();
        }
        else
        {
            Debug.Log("Lever cannot be used right now.");
        }
    }
}