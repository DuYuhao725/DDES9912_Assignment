using UnityEngine;
using TMPro;

public class MachineController : MonoBehaviour
{
    [Header("Machine State")]
    public bool isPoweredOn = false;
    public int credits = 0;
    public string machineStatus = "OFF";

    [Header("UI References")]
    public TMP_Text statusText;
    public TMP_Text creditText;
    public TMP_Text messageText;

    void Start()
    {
        UpdateUI();
    }

    public void PowerOnMachine()
    {
        if (isPoweredOn)
        {
            messageText.text = "Machine is already on.";
            return;
        }

        isPoweredOn = true;
        machineStatus = "IDLE";
        messageText.text = "Machine powered on. Insert coin.";
        UpdateUI();

        Debug.Log("Machine powered on.");
    }

    public void UpdateUI()
    {
        if (statusText != null)
        {
            statusText.text = "Status: " + machineStatus;
        }

        if (creditText != null)
        {
            creditText.text = "Credits: " + credits;
        }

        if (messageText != null && messageText.text == "")
        {
            messageText.text = "Press Power to start the machine.";
        }
    }
}