using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    //Main Menu button
    [SerializeField] GameObject LoreButton;

    //# of pages unlocked
    [SerializeField] SaveData saveData;

    //Big Red X
    [SerializeField] GameObject X;
    private List<GameObject> Xs = new List<GameObject>();


    public void Start()
    {
        ResetMenu();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ResetMenu();
        }
    }

    public void ResetMenu()
    {
        float x;
        float y;
        int totalUnlocked = saveData.pagesCollected;
        LoreButton.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);

        for (int i = 0; i < Xs.Count; i++)
        {
            Destroy(Xs.ElementAt(i));
        }

        Xs.Clear();

        foreach (GameObject go in Area1Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (totalUnlocked > 0)
            {
                totalUnlocked--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
           
        }
        foreach (GameObject go in Area2Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (totalUnlocked > 0)
            {
                totalUnlocked--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        foreach (GameObject go in Area3Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (totalUnlocked > 0)
            {
                totalUnlocked--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        foreach (GameObject go in Area4Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (totalUnlocked > 0)
            {
                totalUnlocked--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        foreach (GameObject go in RichGuyButtons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (totalUnlocked > 0)
            {
                totalUnlocked--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }
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
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                Xs.Add(x);
            }
        }
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void Area2ButtonClicked()
    {
        foreach (GameObject go in Area2Buttons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                Xs.Add(x);
            }
        }
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void Area3ButtonClicked()
    {
        foreach (GameObject go in Area3Buttons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                Xs.Add(x);
            }
        }
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void Area4ButtonClicked()
    {
        foreach (GameObject go in Area4Buttons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                Xs.Add(x);
            }
        }
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void RichGuyButtonClicked()
    {
        foreach (GameObject go in RichGuyButtons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                Xs.Add(x);
            }
        }
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);
    }

    public void LoreClicked(Button clickedLore)
    {
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

        clickedLore.gameObject.SetActive(true);
        clickedLore.gameObject.transform.position = new Vector2(500, 275);
        clickedLore.gameObject.transform.localScale = new Vector2(2, 18);


    }
}
