using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> models;
    [SerializeField]
    private int currModel = 0;
    [SerializeField]
    private GameObject playButton;

    private void Start()
    {
        for (int i = 0; i < models.Count; i++)
        {
            models[i].SetActive(false);
        }

        models[currModel].SetActive(true);
        CheckPlay();
    }

    public void NextModel()
    {
        for (int i = 0; i < models.Count; i++)
        {
            models[i].SetActive(false);
        }

        currModel++;

        if (currModel > models.Count - 1)
            currModel = 0;

        models[currModel].SetActive(true);
        CheckPlay();
    }

    public void PreviousModel()
    {
        for (int i = 0; i < models.Count; i++)
        {
            models[i].SetActive(false);
        }

        currModel--;

        if (currModel < 0)
            currModel = models.Count - 1;

        models[currModel].SetActive(true);
        CheckPlay();
    }

    public void PlayObject()
    {
        models[currModel].GetComponent<Play>().PlayObject();
    }

    private void CheckPlay()
    {
        if (models[currModel].GetComponent<Play>())
            playButton.SetActive(true);
        else
            playButton.SetActive(false);
    }
}
