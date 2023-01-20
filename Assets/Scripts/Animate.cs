using UnityEngine;

public class Animate : Play
{
    public Animation animate;

    public override void PlayObject()
    {
        animate.Play();
        Debug.Log("PlayingAnim");
    }
}
