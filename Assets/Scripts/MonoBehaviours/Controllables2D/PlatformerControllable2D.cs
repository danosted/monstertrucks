namespace Assets.Code.MonoBehaviours.Controllables2D
{
    using UnityEngine;
    using IoC;
    using Common.DataAccess;
    using GameLogic;
    using Common;
    using Utilities;
    using Assets.Code.Common.Constants;

    public class PlatformerControllable2D : PrefabBase
    {
        public float Speed = 0.2f;

        public virtual void Activate(IUnityContainer container, Vector3? intialPosition = null)
        {
            base.Activate(container);
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
            var verticalInput = Input.GetAxis(InputConstants.VerticalAxisString) * Speed;
            var horizontalInput = Input.GetAxis(InputConstants.HorizontalAxisString) * Speed;
            transform.Translate(verticalInput, horizontalInput, 0f);
        }
    }
}
