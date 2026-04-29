using UnityEngine;
using TMPro;

public class MachineDataDisplay : MonoBehaviour
{
    public TMP_Text dataText;

    private string machineStatus = "OFF";
    private int currentBalance = 0;
    private string lastResult = "None";
    private string rewardOutput = "No";

    void Start()
    {
        UpdateBoard();
    }

    public void SetMachineStatus(string status)
    {
        machineStatus = status;
        UpdateBoard();
    }

    public void SetCurrentBalance(int balance)
    {
        currentBalance = balance;
        UpdateBoard();
    }

    public void SetLastResult(string result)
    {
        lastResult = result;
        UpdateBoard();
    }

    public void SetRewardOutput(string output)
    {
        rewardOutput = output;
        UpdateBoard();
    }

    private void UpdateBoard()
    {
        if (dataText != null)
        {
            dataText.text =
                "Machine Status: " + machineStatus +
                "\nCurrent Balance: $" + currentBalance +
                "\nLast Result: " + lastResult +
                "\nReward Output: " + rewardOutput;
        }
    }
}