using UnityEngine;
using TMPro;

public class CoinSlotTrigger : MonoBehaviour
{
    public TMP_Text statusText;

    public int credits = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            credits += 1;

            if (statusText != null)
            {
                statusText.text = "Credit Added: $2\nSpin Available";
            }

            Destroy(other.gameObject);
        }
    }

    public bool UseCredit()
    {
        if (credits > 0)
        {
            credits -= 1;
            return true;
        }

        if (statusText != null)
        {
            statusText.text = "Insert $2 Coin First";
        }

        return false;
    }
}