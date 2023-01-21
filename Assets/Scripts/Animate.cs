using System.Collections.Generic;
using UnityEngine;

public class Animate : Play
{
    private List<AnimationState> animationStates = new List<AnimationState>();
    public Animation animate;
    private int index = 0;

    private void Start()
    {
        foreach (AnimationState state in animate)
        {
            animationStates.Add(state);
        }
    }

    public override void PlayObject()
    {
        for(int i = 0; i <= animationStates.Count - 1; i++)
        {
            if (i == index)
                animate.Play(animationStates[i].name);
            
            else if 
                (index == animationStates.Count) animate.Stop();
        }

        index++;

        if (index > animationStates.Count) 
            index = 0;
    }
}
