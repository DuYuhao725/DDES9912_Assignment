using UnityEngine;

public class SpinButtonAction : MonoBehaviour
{
    public MachineController machineController;
    public ReelController reelController;

    public void TriggerSpin()
    {
        Debug.Log("Spin button triggered.");

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
            Debug.Log("Machine is not ready to spin.");
        }
    }
}