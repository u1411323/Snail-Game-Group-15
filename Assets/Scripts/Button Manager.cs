using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //Area 1 Lore
    [SerializeField] GameObject Area1Button = null;
    [SerializeField] GameObject[] Area1Buttons = null;
    //Area 2 Lore
    [SerializeField] GameObject Area2Button = null;
    [SerializeField] GameObject[] Area2Buttons = null;
    //Area 3 Lore
    [SerializeField] GameObject Area3Button = null;
    [SerializeField] GameObject[] Area3Buttons = null;
    //Area 4 Lore
    [SerializeField] GameObject Area4Button = null;
    [SerializeField] GameObject[] Area4Buttons = null;
    //Area 5 Lore
    [SerializeField] GameObject RichGuyButton = null;
    [SerializeField] GameObject[] RichGuyButtons = null;
    //Main Menu button
    [SerializeField] GameObject LoreButton = null;
    //Start button
    [SerializeField] GameObject StartButton = null;

    [SerializeField] GameObject QuitButton = null;

    [SerializeField] GameObject CreditsButton = null;

    [SerializeField] GameObject ControlsButton = null;

    [SerializeField] TextMeshProUGUI CreditsText = null;

    [SerializeField] TextMeshProUGUI HowToPlayText = null;

    [SerializeField] GameObject panel = null;

    //# of pages unlocked
    [SerializeField] SaveData area1Save = null;
    //# of pages unlocked
    [SerializeField] SaveData area2Save = null;
    //# of pages unlocked
    [SerializeField] SaveData area3Save = null;
    //# of pages unlocked
    [SerializeField] SaveData area4Save = null;
    //# of pages unlocked
    [SerializeField] SaveData manSave = null;

    //Big Red X
    [SerializeField] GameObject X;
    private List<GameObject> Xs = new List<GameObject>();
    bool gameHasStarted = false;


    public void Start()
    {
        gameHasStarted = true;
    }

    public void Update()
    {
        if (gameHasStarted)
        {
            ResetMenu();
            gameHasStarted = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            ResetMenu();
        }
    }

    public void ResetMenu()
    {
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        float x;
        float y;
        int area1progress = area1Save.pagesCollected;
        int area2progress = area2Save.pagesCollected;
        int area3progress = area3Save.pagesCollected;
        int area4progress = area4Save.pagesCollected;
        int manProgress = manSave.pagesCollected;
        LoreButton.SetActive(true);
        StartButton.SetActive(true);
        QuitButton.SetActive(true);
        ControlsButton.SetActive(true);
        CreditsButton.SetActive(true);
        Area1Button.SetActive(false);
        Area2Button.SetActive(false);
        Area3Button.SetActive(false);
        Area4Button.SetActive(false);
        RichGuyButton.SetActive(false);

        //Delete the Xs
        for (int i = 0; i < Xs.Count; i++)
        {
            Destroy(Xs.ElementAt(i));
        }
        Xs.Clear();

        //Reset Area 1 Lore
        foreach (GameObject go in Area1Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (area1progress > 0)
            {
                area1progress--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
           
        }

        //Reset Area 2 Lore
        foreach (GameObject go in Area2Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (area2progress > 0)
            {
                area2progress--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        //Reset Area 3 Lore
        foreach (GameObject go in Area3Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (area3progress > 0)
            {
                area3progress--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        //Reset Area 4 Lore
        foreach (GameObject go in Area4Buttons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (area4progress > 0)
            {
                area4progress--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        //Reset Rich Guy Lore
        foreach (GameObject go in RichGuyButtons)
        {
            go.SetActive(false);
            x = go.GetComponent<ButtonPosition>().x;
            y = go.GetComponent<ButtonPosition>().y;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(0.75002f, 8.37f);
            if (manProgress > 0)
            {
                manProgress--;
                go.GetComponent<ButtonPosition>().unlocked = true;
            }
        }

        //Reset Credits and HTP Menu
        panel.gameObject.SetActive(false);
        HowToPlayText.gameObject.SetActive(false);
        CreditsText.gameObject.SetActive(false);
    }

    public void GoToMainGame()
    {
        SceneManager.LoadScene(1); // Game
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0); // Main Menu
    }

    public void GivePlayerLoreMenu()
    {
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;


        //Reset Credits and HTP Menu
        CreditsButton.gameObject.SetActive(false);
        ControlsButton.gameObject.SetActive(false);

        LoreButton.SetActive(false);
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        Area1Button.SetActive(true);
        Area2Button.SetActive(true);
        Area3Button.SetActive(true);
        Area4Button.SetActive(true);
        RichGuyButton.SetActive(true);
    }

    public void Area1ButtonClicked()
    {
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        foreach (GameObject go in Area1Buttons) 
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                x.transform.parent = this.gameObject.transform.transform;
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

        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;


        foreach (GameObject go in Area2Buttons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                x.transform.parent = this.gameObject.transform.transform;
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
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        foreach (GameObject go in Area3Buttons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                x.transform.parent = this.gameObject.transform.transform;
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
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        foreach (GameObject go in Area4Buttons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                x.transform.parent = this.gameObject.transform.transform;
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
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

        foreach (GameObject go in RichGuyButtons)
        {
            go.SetActive(true);
            if (!go.GetComponent<ButtonPosition>().unlocked)
            {
                go.GetComponent<Button>().enabled = false;
                GameObject x = Instantiate(X);
                x.transform.position = go.transform.position;
                x.transform.parent = this.gameObject.transform.transform;
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
        //Avoid Nullpointer Exceptions if being called somewhere it shouldn't.
        if (SceneManager.GetActiveScene().buildIndex != 0)
            return;

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

        //Delete the Xs
        for (int i = 0; i < Xs.Count; i++)
        {
            Destroy(Xs.ElementAt(i));
        }
        Xs.Clear();

        clickedLore.gameObject.SetActive(true);
        clickedLore.gameObject.transform.position = new Vector2(1250, 500);
        clickedLore.gameObject.transform.localScale = new Vector2(3, 27);


    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        panel.gameObject.SetActive(true);
        CreditsText.gameObject.SetActive(true);
    }

    public void OpenHTP()
    {
        panel.gameObject.SetActive(true);
        HowToPlayText.gameObject.SetActive(true);
    }
}
