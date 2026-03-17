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

    [Header("Spin Settings")]
    public float spinDuration = 2f;
    public float spinSpeed = 800f;

    private int result1;
    private int result2;
    private int result3;
    private int result4;

    public void StartReelSpin()
    {
        StartCoroutine(SpinReelsCoroutine());
    }

    IEnumerator SpinReelsCoroutine()
    {
        float timer = 0f;

        while (timer < spinDuration)
        {
            timer += Time.deltaTime;

            if (reel1 != null) reel1.Rotate(Vector3.right * spinSpeed * Time.deltaTime);
            if (reel2 != null) reel2.Rotate(Vector3.right * spinSpeed * Time.deltaTime);
            if (reel3 != null) reel3.Rotate(Vector3.right * spinSpeed * Time.deltaTime);
            if (reel4 != null) reel4.Rotate(Vector3.right * spinSpeed * Time.deltaTime);

            yield return null;
        }

        StopReelsAndGenerateResult();
    }

    void StopReelsAndGenerateResult()
    {
        result1 = Random.Range(0, 3);
        result2 = Random.Range(0, 3);
        result3 = Random.Range(0, 3);
        result4 = Random.Range(0, 3);

        if (reel1 != null) reel1.rotation = Quaternion.Euler(result1 * 90f, 0f, 0f);
        if (reel2 != null) reel2.rotation = Quaternion.Euler(result2 * 90f, 0f, 0f);
        if (reel3 != null) reel3.rotation = Quaternion.Euler(result3 * 90f, 0f, 0f);
        if (reel4 != null) reel4.rotation = Quaternion.Euler(result4 * 90f, 0f, 0f);

        string resultMessage = CheckResult();

        if (machineController != null)
        {
            machineController.FinishSpin(resultMessage);
        }
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