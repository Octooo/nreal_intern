using UnityEngine;
using TMPro;
using System.Collections;
using System.Text;

public class dis_kaeru : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public float fadeDuration = 0.2f; // �t�F�[�h�̎�������
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
        // ��������
        string[] arr = data.Split('\n');
        string newDisplayStr = "�E" + arr[count % 100];

        // �e�L�X�g���ς�����Ƃ��Ƀt�F�[�h�������s��
        if (targetText.text != newDisplayStr)
        {
            StartCoroutine(FadeText(targetText, newDisplayStr));
        }
    }

    IEnumerator FadeText(TextMeshProUGUI textMesh, string newText)
    {
        // �t�F�[�h�A�E�g
        Color originalColor = textMesh.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - normalizedTime);
            yield return null;
        }
        textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // �e�L�X�g�̍X�V
        textMesh.text = newText;

        // �t�F�[�h�C��
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
        while (true) // �������[�v
        {
            yield return new WaitForSeconds(5f); // 10�b�҂�
            count++; // �C���N�������g
        }
    }
}