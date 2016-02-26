using UnityEngine;
using System.Collections;

namespace Assets.AnimationControllers
{
    public class HeroAnimStateController : MonoBehaviour
    {
        // A reference to the Hero object so that we can query its state
        private Hero hero;

        // The animator used to control this heros animation
        Animator animator;

        // The previous animation state
        private int previousState = 0;

        // Use this for initialization
        void Start()
        {
            hero = GameObject.Find("Hero").GetComponent<Hero>();

            animator = this.transform.GetChild(0).GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (hero.CurrentAction != null)
                animator.SetInteger("State", hero.CurrentAction.Id);
            else
                animator.SetInteger("State", AnimationState.Idle);

            // Control the heros sprite direction
            switch (hero.DirectionFaced)
            {
                case "Left":
                    hero.transform.FindChild("Sprite").localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case "Right":
                    hero.transform.FindChild("Sprite").localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    break;
            }
        }
    }

}