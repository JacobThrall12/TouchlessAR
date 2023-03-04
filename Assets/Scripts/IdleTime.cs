using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
namespace Leap.Unity.Interaction
{
    public class IdleTime : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayer idleVideo;

        [SerializeField]
        private RawImage view;

        [SerializeField]
        private InteractionController leftController, rightController;

        private float timer = 15f;
        private float maxTimer = 15f;

        private void Start()
        {
            leftController = GameObject.FindGameObjectWithTag("left").GetComponent<InteractionHand>();
            rightController = GameObject.FindGameObjectWithTag("right").GetComponent<InteractionHand>();
            view = GameObject.FindGameObjectWithTag("Image").GetComponent<RawImage>();
            view.enabled = false;
        }

        private void FixedUpdate()
        {
            if ((!leftController.isTracked || !rightController.isTracked) && timer > 0)
                timer -= Time.deltaTime;
            else if ((!leftController.isTracked || !rightController.isTracked) && timer <= 0)
            {
                view.enabled = true;
                idleVideo.Play();
            }
            else if (leftController.isTracked || rightController.isTracked)
            {
                timer = maxTimer;
                idleVideo.Stop();
                view.enabled = false;
            }
        }
    }
}