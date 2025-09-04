using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEditor;

public class LoadingManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Slider loadingSlider;
    [SerializeField] TextMeshProUGUI loadingText; 

    [Header("Behavior")]
    [SerializeField] float loadSpeed = 0.6f;     // how fast the fake bar fills
    [SerializeField] float tipChangeInterval = 1.5f; // how often to change messages
    [SerializeField] string menuSceneName = "Menu";

    [Header("Loading Messages")]
    [TextArea]
    [SerializeField] string[] tips = new string[]
    {
        "Pretending to optimize nothing...",
        "Loading things that don’t exist...",
        "Rendering pixels you’ll never see...",
        "Unlocking features I didn’t make...",
        "Preparing absolutely nothing..."
    };

    int lastTipIndex = -1; 
    bool isLoadingDone = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        loadingSlider.value = 0f;

        StartCoroutine(FakeLoading());
        StartCoroutine(CycleTips());
    }

    IEnumerator FakeLoading()
    {
        while (loadingSlider.value < 1f)
        {
            loadingSlider.value += loadSpeed * Time.deltaTime;
            yield return null;
        }

        isLoadingDone = true;
        SceneManager.LoadScene(menuSceneName);
    }

    IEnumerator CycleTips()
    {
        SetRandomTip();

        while (!isLoadingDone)
        {
            yield return new WaitForSeconds(tipChangeInterval);
            SetRandomTip();
        }
    }

    void SetRandomTip()
    {
        if (tips == null || tips.Length == 0) return;

        int index = Random.Range(0, tips.Length);
        if (index == lastTipIndex && tips.Length > 1)
        {
            index = (index + 1) % tips.Length;
        }

        lastTipIndex = index;
        if (loadingText != null)
            loadingText.text = tips[index];
    }
}
