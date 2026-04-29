using UnityEngine;
using System.Collections;

public class ReelController : MonoBehaviour
{
    [Header("Reel References")]
    public Transform reel1;
    public Transform reel2;
    public Transform reel3;
    public Transform reel4;

    [Header("Machine Reference")]
    public MachineController machineController;

    [Header("Coin / Money Box Reference")]
    public CoinSlotTrigger coinSlot;

    [Header("Sound Effects")]
    public AudioSource winSound;
    public AudioSource errorSound;

    [Header("Spin Settings")]
    public float spinDuration = 2f;
    public float spinSpeed = 720f;

    private int result1;
    private int result2;
    private int result3;
    private int result4;

    private Quaternion reel1BaseRotation;
    private Quaternion reel2BaseRotation;
    private Quaternion reel3BaseRotation;
    private Quaternion reel4BaseRotation;

    private bool isSpinning = false;

    void Start()
    {
        if (reel1 != null) reel1BaseRotation = reel1.localRotation;
        if (reel2 != null) reel2BaseRotation = reel2.localRotation;
        if (reel3 != null) reel3BaseRotation = reel3.localRotation;
        if (reel4 != null) reel4BaseRotation = reel4.localRotation;
    }

    public void StartReelSpin()
    {
        if (isSpinning)
        {
            return;
        }

        if (coinSlot == null || !coinSlot.UseCredit())
        {
            return;
        }

        isSpinning = true;

        StopAllCoroutines();
        StartCoroutine(SpinReelsCoroutine());
    }

    IEnumerator SpinReelsCoroutine()
    {
        float timer = 0f;

        while (timer < spinDuration)
        {
            timer += Time.deltaTime;

            if (reel1 != null) reel1.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);
            if (reel2 != null) reel2.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);
            if (reel3 != null) reel3.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);
            if (reel4 != null) reel4.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);

            yield return null;
        }

        StopReelsAndGenerateResult();
    }

    void StopReelsAndGenerateResult()
    {
        result1 = Random.Range(0, 4);
        result2 = Random.Range(0, 4);
        result3 = Random.Range(0, 4);
        result4 = Random.Range(0, 4);

        SetReelToResult(reel1, reel1BaseRotation, result1);
        SetReelToResult(reel2, reel2BaseRotation, result2);
        SetReelToResult(reel3, reel3BaseRotation, result3);
        SetReelToResult(reel4, reel4BaseRotation, result4);

        string resultMessage = CheckResult();

        if (resultMessage == "BIG WIN!" || resultMessage == "SMALL WIN!")
        {
            if (winSound != null)
            {
                winSound.Play();
            }
        }
        else
        {
            if (errorSound != null)
            {
                errorSound.Play();
            }
        }

        if (machineController != null)
        {
            machineController.FinishSpin(resultMessage);
        }

        isSpinning = false;
    }

    void SetReelToResult(Transform reel, Quaternion baseRotation, int result)
    {
        if (reel == null) return;

        Quaternion extraRotation = Quaternion.AngleAxis(result * 90f, Vector3.up);
        reel.localRotation = baseRotation * extraRotation;
    }

    string CheckResult()
    {
        if (result1 == result2 && result2 == result3 && result3 == result4)
        {
            return "BIG WIN!";
        }
        else if (result1 == result2 && result2 == result3)
        {
            return "SMALL WIN!";
        }
        else
        {
            return "LOSE";
        }
    }
}