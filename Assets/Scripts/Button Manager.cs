using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Area 1 Lore
    [SerializeField] GameObject Area1Button;
    [SerializeField] GameObject[] Area1Buttons;
    //Area 2 Lore
    [SerializeField] GameObject Area2Button;
    [SerializeField] GameObject[] Area2Buttons;
    //Area 3 Lore
    [SerializeField] GameObject Area3Button;
    [SerializeField] GameObject[] Area3Buttons;
    //Area 4 Lore
    [SerializeField] GameObject Area4Button;
    [SerializeField] GameObject[] Area4Buttons;
    //Area 5 Lore
    [SerializeField] GameObject RichGuyButton;
    [SerializeField] GameObject[] RichGuyButtons;

    [SerializeField] GameObject LoreButton;

    public void Start()
    {
        ResetMenu();
    }

    public void ResetMenu()
    {
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);

        foreach (GameObject go in Area1Buttons)
            go.SetActive(false);

        foreach (GameObject go in Area2Buttons)
            go.SetActive(false);

        foreach (GameObject go in Area3Buttons)
            go.SetActive(false);

        foreach (GameObject go in Area4Buttons)
            go.SetActive(false);

        foreach (GameObject go in RichGuyButtons)
            go.SetActive(false);
    }

    public void GoToMainGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GivePlayerLoreMenu()
    {
        LoreButton.SetActive(false);
        Area1Button.SetActive(true);
        Area2Button.SetActive(true);
        Area3Button.SetActive(true);
        Area4Button.SetActive(true);
        RichGuyButton.SetActive(true);
    }

    public void Area1ButtonClicked()
    {
        foreach (GameObject go in Area1Buttons)
            go.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void Area2ButtonClicked()
    {
        foreach (GameObject go in Area2Buttons)
            go.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void Area3ButtonClicked()
    {
        foreach (GameObject go in Area3Buttons)
            go.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void Area4ButtonClicked()
    {
        foreach (GameObject go in Area4Buttons)
            go.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void RichGuyButtonClicked()
    {
        foreach (GameObject go in RichGuyButtons)
            go.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }
}
