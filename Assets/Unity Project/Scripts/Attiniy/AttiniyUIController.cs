using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Governs the Attiniy-related UI (mostly the slider).
/// </summary>
public class AttiniyUIController : MonoBehaviour
{
    public const float ANIMATION_TIME = 0.35f;
    public const float MAX_ATTINIY_AMOUNT = 100f;
    public Slider AttiniySlider;

    private void Awake()
    {
        // JUST to initialize, the AttiniyComponent script will update this initially.
        AttiniySlider.value = MAX_ATTINIY_AMOUNT;
        AttiniySlider.maxValue = MAX_ATTINIY_AMOUNT;
    }

    // + + + + | Functions | + + + + 

    public void UpdateSlider(float newAmount) => AnimateAmount(AttiniySlider.value, newAmount);

    public void UpdateSlider(float fromAmount, float toAmount) => AnimateAmount(fromAmount, toAmount);

    public void AnimateAmount(float oldAmount, float newAmount)
    {
        StartCoroutine(AnimateToNewValue(oldAmount, newAmount, ANIMATION_TIME));
    }

    private IEnumerator AnimateToNewValue(float originalValue, float targetValue, float totalTime)
    {
        int numSteps = 20;
        for (float i = 0; i < totalTime; i += totalTime / numSteps)
        {
            AttiniySlider.value = Mathf.Lerp(originalValue, targetValue, i / totalTime);
            yield return new WaitForSeconds(totalTime / numSteps);
        }

        Debug.Log("Finished Animating to New Value!");
    }

}
