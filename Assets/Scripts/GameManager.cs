using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> models;
    [SerializeField]
    private GameObject playButton;

    private int currModel = 0;

    private void OnEnable()
    {
        EventManager.instance.NextItem += NextModel;
        EventManager.instance.PrevItem += PreviousModel;
    }

    private void OnDisable()
    {
        EventManager.instance.NextItem -= NextModel;
        EventManager.instance.PrevItem -= PreviousModel;
    }

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
        GameObject model = models[currModel];

        if (model.GetComponent<Play>())
            model.GetComponentInChildren<Play>().PlayObject();

        else if (model.GetComponentInParent<Play>())
            model.GetComponentInChildren<Play>().PlayObject();

        else if (model.GetComponentInChildren<Play>())
            model.GetComponentInChildren<Play>().PlayObject();
    }

    private bool CheckPlayScript()
    {
        GameObject model = models[currModel];

        if (model.GetComponent<Play>())
            return true;

        else if (model.GetComponentInParent<Play>())
            return true;

        else if (model.GetComponentInChildren<Play>())
            return true;

        else
            return false;
    }

    private void CheckPlay() => playButton.SetActive(CheckPlayScript());
}
