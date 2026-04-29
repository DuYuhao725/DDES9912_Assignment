using UnityEngine;
using TMPro;

public class CoinSlotTrigger : MonoBehaviour
{
    public TMP_Text statusText;

    [Header("Credit System")]
    public int credits = 0;

    [Header("Ready Light")]
    public GameObject readyLightObject;
    public Light readyPointLight;
    public Material readyLightOnMaterial;
    public Material readyLightOffMaterial;

    [Header("Sound")]
    public AudioSource coinSound;

    private Renderer readyLightRenderer;

    void Start()
    {
        if (readyLightObject != null)
        {
            readyLightRenderer = readyLightObject.GetComponent<Renderer>();
        }

        UpdateReadyLight();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            credits += 1;

            if (coinSound != null)
            {
                coinSound.Play();
            }

            if (statusText != null)
            {
                statusText.text = "Credit Added: $2\nSpin Available";
            }

            Destroy(other.gameObject);

            UpdateReadyLight();
        }
    }

    public bool UseCredit()
    {
        if (credits > 0)
        {
            credits -= 1;

            if (statusText != null)
            {
                statusText.text = "Credit Used\nSpinning...";
            }

            UpdateReadyLight();

            return true;
        }

        if (statusText != null)
        {
            statusText.text = "Insert $2 Coin First";
        }

        UpdateReadyLight();

        return false;
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