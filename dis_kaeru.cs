using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;

public class dis_kaeru : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public float fadeDuration = 0.2f; // フェードの持続時間
    public string file_name = "kaeru";
    public TextAsset textAsset;
    public string data;

    public int count = 0;
    private void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(file_name);
        data = textAsset.text;
        StartCoroutine(IncrementEvery10Seconds());
    }

    void Update()
    {
        // 書き込み
        string[] arr = data.Split('\n');
        string newDisplayStr = "・" + arr[count % 100];

        // テキストが変わったときにフェード処理を行う
        if (targetText.text != newDisplayStr)
        {
            StartCoroutine(FadeText(targetText, newDisplayStr));
        }
    }

    IEnumerator FadeText(TextMeshProUGUI textMesh, string newText)
    {
        // フェードアウト
        Color originalColor = textMesh.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - normalizedTime);
            yield return null;
        }
        textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // テキストの更新
        textMesh.text = newText;

        // フェードイン
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, normalizedTime);
            yield return null;
        }
        textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1);
    }

    IEnumerator IncrementEvery10Seconds()
    {
        while (true) // 無限ループ
        {
            yield return new WaitForSeconds(5f); // 10秒待つ
            count++; // インクリメント
        }
    }
}