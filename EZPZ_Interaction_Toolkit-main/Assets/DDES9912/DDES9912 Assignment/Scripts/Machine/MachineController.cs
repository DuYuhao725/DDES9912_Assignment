using UnityEngine;
using TMPro;

public class MachineController : MonoBehaviour
{
    [Header("Machine State")]
    public bool isPoweredOn = false;
    public bool canSpin = false;
    public bool isSpinning = false;
    public string machineStatus = "OFF";

    [Header("UI")]
    public TMP_Text statusText;
    public TMP_Text messageText;
    public TMP_Text resultText;

    void Start()
    {
        machineStatus = "OFF";
        UpdateUI();
        SetMessage("Click the power button to start the machine.");
        SetResult("");
    }

    public void PowerOnMachine()
    {
        if (isPoweredOn)
        {
            SetMessage("Machine is already on.");
            return;
        }

        isPoweredOn = true;
        canSpin = true;
        machineStatus = "READY";
        UpdateUI();
        SetMessage("Machine is on. Click the lever to spin.");
    }

    public bool CanUseLever()
    {
        return isPoweredOn && canSpin && !isSpinning;
    }

    public void StartSpin()
    {
        if (!CanUseLever())
        {
            return;
        }

        isSpinning = true;
        canSpin = false;
        machineStatus = "SPINNING";
        UpdateUI();
        SetMessage("Reels are spinning...");
        SetResult("");
    }

    public void FinishSpin(string resultMessage)
    {
        isSpinning = false;
        canSpin = true;
        machineStatus = "READY";
        UpdateUI();
        SetMessage("Click the lever to spin again.");
        SetResult(resultMessage);
    }

    public void UpdateUI()
    {
        if (statusText != null)
        {
            statusText.text = "Status: " + machineStatus;
        }
    }

    public void SetMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }

    public void SetResult(string result)
    {
        if (resultText != null)
        {
            resultText.text = "Result: " + result;
        }
    }
}