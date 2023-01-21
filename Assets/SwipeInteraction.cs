using UnityEngine;

namespace Leap.Unity.Interaction {

    public class SwipeInteraction : MonoBehaviour
    {
        private InteractionController controller;

        [SerializeField]
        private float swipeTime;
        private float maxSwipeTime = .5f;
        private float maxSwipeSens = 3f;
        private float swipeSens = 1.5f;

        private bool swiped = false;

        void Start()
        {
            controller = GetComponent<InteractionHand>();
        }

        void Update()
        {
            if (controller.contactBones != null)
            {
                if ((maxSwipeSens * -1) < GetPalmXVelocity() && GetPalmXVelocity() < (swipeSens * -1) && swiped.Equals(false))
                {
                    swiped = true;
                    RightButton();
                }
                else if (maxSwipeSens > GetPalmXVelocity() && GetPalmXVelocity() > swipeSens && swiped.Equals(false))
                {
                    swiped = true;
                    LeftButton();
                }
            }

            if (swipeTime < maxSwipeTime && swiped.Equals(true))
            {
                swipeTime += Time.deltaTime;
            }
            else if (swipeTime > maxSwipeTime && swiped.Equals(true))
            {
                swipeTime = 0;
                swiped = false;
                controller.contactBones[controller.contactBones.Length - 1].rigidbody.velocity = Vector3.zero;
            }
        }

        private float GetPalmXVelocity() => controller.contactBones[controller.contactBones.Length - 1].rigidbody.velocity.x;

        private void RightButton() => EventManager.instance.OnNext();

        private void LeftButton() => EventManager.instance.OnPrior();
    }
}