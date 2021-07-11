namespace Assets.Code.MonoBehaviours.Obstacles
{
    using UnityEngine;
    using IoC;
    using Common.DataAccess;
    using GameLogic;
    using Common;
    using Utilities;

    public class MovingObject : PrefabBase
    {
        protected float Speed { get; set; }

        public virtual void Activate(IUnityContainer container, Vector3 intialPosition)
        {
            base.Activate(container);
            Speed = 1f;
            transform.position = intialPosition;
            gameObject.SetActive(true);
        }

        protected virtual void Update()
        {
            Move();
            CheckOutOfBounds();
        }

        protected virtual void Move()
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }

        protected virtual void CheckOutOfBounds()
        {
            if(!Container.Resolve<ScreenUtil>().IsOutOfViewportBounds(transform.position))
            {
                return;
            }
            Deactivate();
        }

        protected virtual void OnMouseEnter()
        {
            ScoreLogic.AddToScore(-(int)Speed);
            Deactivate();
        }
    }
}
