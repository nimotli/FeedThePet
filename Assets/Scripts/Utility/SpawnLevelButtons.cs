using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SpawnLevelButtons : MonoBehaviour
{
    [SerializeField]
    GameObject levelButtonsHolder;
    [SerializeField]
    GameObject button;
    [SerializeField]
    float refreshRate = .2f;
    List<Button> spawnedButtons = new List<Button>();
    void Start()
    {
        spawnButtons(24);
    }

    void spawnButtons(int number)
    {
        for (int i = 0; i < number; i++)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();

            Color32 buttonColor = generateColor();
            Button bt = button.GetComponent<Button>();
            ColorBlock cb = bt.colors;
            cb.normalColor = buttonColor;
            bt.colors = cb;

            GameObject obj =Instantiate(button, levelButtonsHolder.transform);
            obj.GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene(1); });
            spawnedButtons.Add(obj.GetComponent<Button>());
        }
        StartCoroutine(recolor());
    }

    IEnumerator recolor()
    {
        while(true)
        {
            for (int i = 0; i < spawnedButtons.Count; i++)
            {
                ColorBlock cb = spawnedButtons[i].colors;
                cb.normalColor = generateColor();
                spawnedButtons[i].colors = cb;
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
    Color32 generateColor()
    {
        byte r = (byte)Random.Range(0, 255);
        byte g = (byte)Random.Range(0, 255);
        byte b = (byte)Random.Range(0, 255);
        Color32 buttonColor = new Color32(r, g, b,255);
        return buttonColor;
    }
}
