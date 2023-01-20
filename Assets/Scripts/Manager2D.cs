using UnityEngine;

public class Manager2D : MonoBehaviour
{
    [SerializeField]
    private GameObject HiddenObjects, ShownObjects;

    public void Show2D()
    {
        bool temp = false;
        SetAllBool(temp);
    }

    public void Show3D()
    {
        bool temp = true;
        SetAllBool(temp);
    }

    private void SetAllBool(bool setBool)
    {
        HiddenObjects.SetActive(!setBool);
        ShownObjects.SetActive(setBool);
    }
}
