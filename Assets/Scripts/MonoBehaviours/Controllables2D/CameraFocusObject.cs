namespace Assets.Code.MonoBehaviours.Controllables2D
{
    using UnityEngine;
    using IoC;
    using Common.DataAccess;
    using GameLogic;
    using Common;
    using Utilities;

    public class CameraFocusObject : MonoBehaviour
    {
        protected virtual void Update()
        {
            FocusOnMeXY();
        }

        protected void FocusOnMeXY()
        {
            // This simple function makes the camera follow strictly on the 2d object given that it moves in the X-Y plane
            var myPos = this.transform.position;
            myPos.z = 0f;
            Camera.main.transform.position = myPos;
        }
    }
}
