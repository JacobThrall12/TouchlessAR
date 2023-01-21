using UnityEngine.Video;

public class VideoPlay : Play
{
    public VideoPlayer player;

    public override void PlayObject()
    {
        player.Play();
    }
}
