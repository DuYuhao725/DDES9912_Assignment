using UnityEngine;
using TMPro;

public class MachineController : MonoBehaviour
{
    [Header("UI Text References")]
    public TMP_Text mainText;
    public TMP_Text statusText;
    public TMP_Text instructionText;
    public TMP_Text resultText;

    [Header("Reel Controller")]
    public ReelController reelController;

    [Header("Atmosphere Lights")]
    public GameObject atmosphereLights;

    [Header("Machine Data Display")]
    public MachineDataDisplay dataDisplay;

    [Header("Machine State")]
    public bool machineStarted = false;

    void Start()
    {
        machineStarted = false;

        if (atmosphereLights != null)
        {
            atmosphereLights.SetActive(false);
        }

        if (dataDisplay != null)
        {
            dataDisplay.SetMachineStatus("OFF");
            dataDisplay.SetCurrentBalance(0);
            dataDisplay.SetLastResult("None");
            dataDisplay.SetRewardOutput("No");
        }

        ShowPowerOffUI();
    }

    public void StartMachine()
    {
        machineStarted = true;

        if (atmosphereLights != null)
        {
            atmosphereLights.SetActive(true);
        }

        if (dataDisplay != null)
        {
            dataDisplay.SetMachineStatus("READY");
        }

        ShowReadyUI();
    }

    public void PowerOn()
    {
        StartMachine();
    }

    public void PowerOnMachine()
    {
        StartMachine();
    }

    public void PowerOff()
    {
        machineStarted = false;

        if (atmosphereLights != null)
        {
            atmosphereLights.SetActive(false);
        }

        if (dataDisplay != null)
        {
            dataDisplay.SetMachineStatus("OFF");
            dataDisplay.SetLastResult("None");
            dataDisplay.SetRewardOutput("No");
        }

        ShowPowerOffUI();
    }

    public void TogglePower()
    {
        if (machineStarted)
        {
            PowerOff();
        }
        else
        {
            PowerOn();
        }
    }

    public bool IsMachineStarted()
    {
        return machineStarted;
    }

    public bool CanUseLever()
    {
        if (!machineStarted)
        {
            ShowMessage("Press START First");
            return false;
        }

        return true;
    }

    public bool CanUseSpin()
    {
        if (!machineStarted)
        {
            ShowMessage("Press START First");
            return false;
        }

        return true;
    }

    public void StartSpin()
    {
        if (!machineStarted)
        {
            ShowMessage("Press START First");
            return;
        }

        if (reelController != null)
        {
            reelController.StartReelSpin();
        }
    }

    public void FinishSpin(string resultMessage)
    {
        if (mainText != null)
        {
            mainText.text = resultMessage + "\nInsert $2 Coin";
        }

        if (statusText != null)
        {
            statusText.text = "Status: READY";
        }

        if (instructionText != null)
        {
            instructionText.text = "Insert another $2 coin to play again.";
        }

        if (resultText != null)
        {
            resultText.text = "Result: " + resultMessage;
        }

        if (dataDisplay != null)
        {
            dataDisplay.SetLastResult(resultMessage);
        }
    }

    public void ShowMessage(string message)
    {
        if (mainText != null)
        {
            mainText.text = message;
        }

        if (instructionText != null)
        {
            instructionText.text = message;
        }
    }

    private void ShowPowerOffUI()
    {
        if (mainText != null)
        {
            mainText.text = "Status: OFF\nPress START";
        }

        if (statusText != null)
        {
            statusText.text = "Status: OFF";
        }

        if (instructionText != null)
        {
            instructionText.text = "Walk to the machine and press the power button.";
        }

        if (resultText != null)
        {
            resultText.text = "Result:";
        }
    }

    private void ShowReadyUI()
    {
        if (mainText != null)
        {
            mainText.text = "READY\nInsert $2 Coin";
        }

        if (statusText != null)
        {
            statusText.text = "Status: READY";
        }

        if (instructionText != null)
        {
            instructionText.text = "Insert $2 coin into the money box.";
        }

        if (resultText != null)
        {
            resultText.text = "Result:";
        }
    }
}