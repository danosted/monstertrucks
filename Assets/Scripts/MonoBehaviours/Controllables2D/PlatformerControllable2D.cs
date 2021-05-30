namespace Assets.Code.MonoBehaviours.Controllables2D
{
    using UnityEngine;
    using IoC;
    using DataAccess;
    using GameLogic;
    using Common;
    using Utilities;
    using Assets.Code.Common.Constants;

    public class PlatformerControllable2D : PrefabBase
    {
        protected float Speed { get; set; }

        public virtual void Activate(IoC container, Vector3? intialPosition = null)
        {
            base.Activate(container);
            Speed = Speed == 0f ? 1f : Speed;
            transform.position = intialPosition ?? Vector3.zero;
            gameObject.SetActive(true);
        }

        protected virtual void Update()
        {
            MoveXY();
        }

        protected virtual void MoveXY()
        {
            // TODO 1 (DRO): Make this more generic and configurable, like axis alignment for the view etc
            // Get cur input delta - we move here in the x - y plane, looking down the z plane
            var verticalInput = Input.GetAxis(InputConstants.VerticalAxisString);
            var horizontalInput = Input.GetAxis(InputConstants.HorizontalAxisString);
            transform.Translate(verticalInput, horizontalInput, 0f);
        }
    }
}
