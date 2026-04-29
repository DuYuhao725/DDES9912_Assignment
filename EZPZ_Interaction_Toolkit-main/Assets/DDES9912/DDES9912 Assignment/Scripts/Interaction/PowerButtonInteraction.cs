using UnityEngine;

public class PowerButtonInteraction : MonoBehaviour
{
    public MachineController machineController;

    private void OnMouseDown()
    {
        if (machineController != null)
        {
            machineController.PowerOnMachine();
        }
        else
        {
            Debug.LogWarning("MachineController reference is missing.");
        }
    }
}