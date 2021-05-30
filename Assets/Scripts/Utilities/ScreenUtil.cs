namespace Assets.Code.Utilities
{
    using System;
    using System.Collections.Generic;
    using Assets.Code.MonoBehaviours.Obstacles;
    using UnityEngine;

    public class ScreenUtil
    {

        public Vector3 ViewportToWorldBorderMax
        {
            get
            {
                return Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.farClipPlane));
            }
        }
        public Vector3 ViewportToWorldBorderMin
        {
            get
            {
                return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
            }
        }

        public Vector3 ViewportToScreenBorderMax
        {
            get
            {
                return Camera.main.ViewportToScreenPoint(new Vector3(1, 1, Camera.main.farClipPlane));
            }
        }

        public Vector3 ViewportToScreenBorderMin
        {
            get
            {
                return Camera.main.ViewportToScreenPoint(new Vector3(0, 0, Camera.main.farClipPlane));
            }
        }

        public ScreenUtil()
        {
            //ViewportToWorldBorderMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
            //ViewportToWorldBorderMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.farClipPlane));

            //ViewportToScreenBorderMin = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, Camera.main.farClipPlane));
            //ViewportToScreenBorderMax = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, Camera.main.farClipPlane));
        }

        public Vector3 GetScreenPositionOnWorldPlane(Vector3 position)
        {
            return Camera.main.ScreenToWorldPoint(position);
        }


        public bool IsOutOfViewportBounds(Vector3 position)
        {
            if (position.y > ViewportToWorldBorderMax.y)
            {
                return true;
            }

            if (position.y < ViewportToWorldBorderMin.y)
            {
                return true;
            }

            if (position.x > ViewportToWorldBorderMax.x)
            {
                return true;
            }

            if (position.x < ViewportToWorldBorderMin.x)
            {
                return true;
            }

            return false;
        }

        public Vector2 GetScreenSizeInWorld()
        {
            return new Vector2(Mathf.Abs(ViewportToWorldBorderMin.x) + Mathf.Abs(ViewportToWorldBorderMax.x), Mathf.Abs(ViewportToWorldBorderMin.y) + Mathf.Abs(ViewportToWorldBorderMax.y));
        }

        public Vector2 GetScreenSize()
        {
            return new Vector2(Mathf.Abs(ViewportToScreenBorderMin.x) + Mathf.Abs(ViewportToScreenBorderMax.x), Mathf.Abs(ViewportToScreenBorderMin.y) + Mathf.Abs(ViewportToScreenBorderMax.y));
        }

        #region Evenly Distributed Points On Screen
        private struct Point
        {
            public int x;
            public int y;
        }

        public ICollection<Vector3> GenerateEvenlyDistributedScreenPoints()
        {
            // First calculate the field size based on the screen resolution
            var screenSize = GetScreenSizeInWorld();

            return GenerateEvenlyDistributedPositions((int)screenSize.x, (int)screenSize.y);
        }

        public ICollection<Vector3> GenerateEvenlyDistributedPositions(int width, int height)
        {
            // First calculate the field size based on the screen resolution
            var screenSize = GetScreenSizeInWorld();

            var fieldSize = new Point
            {
                x = width,
                y = height
            };

            // Initialize the drawingfield locations based on points
            var evenlyDistributedPoints = CreateEvenlyDistributedPoints(fieldSize.x, fieldSize.y);

            // Map the points to Vector3 in world coordinates
            var evenlyDistributedVector3Positions = MapAreasToVector3(evenlyDistributedPoints, fieldSize);
            return evenlyDistributedVector3Positions;
        }

        #region Mapping Points
        private ICollection<Point> CreateEvenlyDistributedPoints(int width, int height)
        {
            var areas = new List<Point>(width * height);
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    Point area = CreateAndPlaceCellInGrid(x, y);
                    areas.Add(area);
                }
            }
            return areas;
        }

        private Point CreateAndPlaceCellInGrid(int x, int y)
        {

            var area = new Point
            {
                x = x,
                y = y,
            };

            return area;
        }

        /// <summary>
        /// Map horizontal position from a 0-indexed environment
        /// </summary>
        private float MapHorizontalPosition(int x, Point fieldSize)
        {
            return MathUtil.MapInputFromInputRangeToOutputRange(x, 0, fieldSize.x, ViewportToWorldBorderMin.x, ViewportToWorldBorderMax.x);
        }

        /// <summary>
        /// Map vertical position from a 0-indexed environment
        /// </summary>
        private float MapVerticalPosition(int y, Point fieldSize)
        {
            return MathUtil.MapInputFromInputRangeToOutputRange(y, 0, fieldSize.y, ViewportToWorldBorderMin.y, ViewportToWorldBorderMax.y);
        }

        private Vector3 MapAreaToVector3(Point input, Point fieldSize)
        {
            return new Vector3(MapHorizontalPosition(input.x, fieldSize), MapVerticalPosition(input.y, fieldSize), Camera.main.nearClipPlane);
        }

        private ICollection<Vector3> MapAreasToVector3(ICollection<Point> inputs, Point fieldSize)
        {
            ICollection<Vector3> result = new List<Vector3>(inputs.Count);
            foreach (var i in inputs)
            {
                result.Add(MapAreaToVector3(i, fieldSize));
            }
            return result;
        }
        #endregion
        #endregion
    }

}
