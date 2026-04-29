using UnityEngine;
using TMPro;

public class CoinSlotTrigger : MonoBehaviour
{
    public TMP_Text statusText;

    [Header("Machine Reference")]
    public MachineController machineController;

    [Header("Credit System")]
    public int credits = 0;
    public int coinValue = 2;

    [Header("Ready Light")]
    public GameObject readyLightObject;
    public Light readyPointLight;
    public Material readyLightOnMaterial;
    public Material readyLightOffMaterial;

    [Header("Sound")]
    public AudioSource coinSound;

    [Header("Machine Data Display")]
    public MachineDataDisplay dataDisplay;

    private Renderer readyLightRenderer;

    void Start()
    {
        if (readyLightObject != null)
        {
            readyLightRenderer = readyLightObject.GetComponent<Renderer>();
        }

        UpdateMoneyDisplay();
        UpdateReadyLight();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            if (machineController != null && !machineController.IsMachineStarted())
            {
                if (statusText != null)
                {
                    statusText.text = "Press START First";
                }

                return;
            }

            credits += 1;

            if (coinSound != null)
            {
                coinSound.Play();
            }

            Destroy(other.gameObject);

            UpdateMoneyDisplay();
            UpdateReadyLight();
        }
    }

    public bool UseCredit()
    {
        if (machineController != null && !machineController.IsMachineStarted())
        {
            if (statusText != null)
            {
                statusText.text = "Press START First";
            }

            return false;
        }

        if (credits > 0)
        {
            credits -= 1;

            UpdateMoneyDisplay();
            UpdateReadyLight();

            return true;
        }

        UpdateMoneyDisplay();
        UpdateReadyLight();

        return false;
    }

    private int GetCurrentMoney()
    {
        return credits * coinValue;
    }

    private void UpdateMoneyDisplay()
    {
        int balance = GetCurrentMoney();

        if (statusText != null)
        {
            statusText.text = "Current Balance: $" + balance;
        }

        if (dataDisplay != null)
        {
            dataDisplay.SetCurrentBalance(balance);
        }
    }

    private void UpdateReadyLight()
    {
        bool hasCredit = credits > 0;

        if (readyLightObject != null)
        {
            readyLightObject.SetActive(true);
        }

        if (readyPointLight != null)
        {
            readyPointLight.enabled = hasCredit;
        }

        if (readyLightRenderer != null)
        {
            if (hasCredit && readyLightOnMaterial != null)
            {
                readyLightRenderer.material = readyLightOnMaterial;
            }
            else if (!hasCredit && readyLightOffMaterial != null)
            {
                readyLightRenderer.material = readyLightOffMaterial;
            }
        }
    }
}