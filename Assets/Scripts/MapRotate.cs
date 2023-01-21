using UnityEngine;

public class MapRotate : MonoBehaviour
{
    [SerializeField]
    private GameObject MapUI;

    private void Update()
    {
        if(transform.rotation.x < -.6f)
        {
            MapUI.GetComponent<Manager2D>().Show2D();
        }
    }
}
