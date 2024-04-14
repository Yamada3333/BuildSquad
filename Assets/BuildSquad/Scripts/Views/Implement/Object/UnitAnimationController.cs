using Spine;
using Spine.Unity;
using UnityEngine;

namespace BuildSquad.Scripts.Views.Implement.Object
{
    public class UnitAnimationController : MonoBehaviour
    {
        private GameObject _theMonster; //The current created monster
        private SkeletonAnimation _monsterAnimator; //The animator script of the monster

        private TrackEntry _trackEntry = new TrackEntry();

        private void Start()
        {
            _trackEntry.End += OnSpineAnimationEnd;
        }


        public void SummonNewMonster(GameObject monsterAnimation)
        {
            if (_theMonster != null)
                Destroy(_theMonster);

            //Create the selected monster
            _theMonster = Instantiate(monsterAnimation, transform);
            _theMonster.transform.localScale = new Vector3(0.4f, 0.4f, 1.0f);
            

            _monsterAnimator = _theMonster.GetComponent<SkeletonAnimation>();
        }

        public void ChangeAnimation(string animationName) //Names are: Idle, Walk, Dead and Attack
        {
            if (_monsterAnimator == null) return;

            //set the animation state to the selected one
            if (animationName == "Dead")
            {
                _trackEntry = _monsterAnimator.AnimationState.SetAnimation(0, "Dead", false);
            }
            else
            {
                if (animationName == "Break")
                {
                    animationName = "Dead";
                }

                _monsterAnimator.AnimationState.SetAnimation(0, animationName, false);
                _monsterAnimator.AnimationState.AddAnimation(0, "Idle", true, 0);
            }
        }

        private void OnSpineAnimationEnd(TrackEntry trackEntry)
        {
            Destroy(_theMonster);
        }

        public void OnSpineAnimationEnd()
        {
            Destroy(_theMonster);
        }
    }
}
