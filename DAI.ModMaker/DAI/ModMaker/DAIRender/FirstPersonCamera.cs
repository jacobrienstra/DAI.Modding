using System;

using SlimDX;

namespace DAI.ModMaker.DAIRender
{
    public class FirstPersonCamera : Camera
    {
        private Frustum CameraFrustum;

        public float Aspect { get; private set; }

        public float FarWindowHeight { get; private set; }

        public float FarWindowWidth => Aspect * FarWindowHeight;

        public float FarZ { get; private set; }

        public float FovX
        {
            get
            {
                float nearWindowWidth = 0.5f * NearWindowWidth;
                return 2f * (float)Math.Atan(nearWindowWidth / NearZ);
            }
        }

        public float FovY { get; private set; }

        public Vector3 Look { get; private set; }

        public float NearWindowHeight { get; private set; }

        public float NearWindowWidth => Aspect * NearWindowHeight;

        public float NearZ { get; private set; }

        public Vector3 Position { get; set; }

        public Vector3 Right { get; private set; }

        public Vector3 Up { get; private set; }

        public FirstPersonCamera()
        {
            Position = default(Vector3);
            Right = new Vector3(-1f, 0f, 0f);
            Up = new Vector3(0f, -1f, 0f);
            Look = new Vector3(0f, 0f, 1f);
            base.View = Matrix.Identity;
            base.Proj = Matrix.Identity;
            SetLens((float)Math.PI / 4f, 1f, 1f, 1000f);
            CameraFrustum = Frustum.FromViewProj(base.ViewProj);
        }

        public void LookAt(Vector3 pos, Vector3 target, Vector3 up)
        {
            Position = pos;
            Look = Vector3.Normalize(target - pos);
            Right = Vector3.Normalize(Vector3.Cross(up, Look));
            Up = Vector3.Cross(Look, Right);
        }

        public void Pitch(float angle)
        {
            Matrix matrix = Matrix.RotationAxis(Right, angle);
            Up = Vector3.TransformNormal(Up, matrix);
            Look = Vector3.TransformNormal(Look, matrix);
        }

        public void SetLens(float fovY, float aspect, float zn, float zf)
        {
            FovY = fovY;
            Aspect = aspect;
            NearZ = zn;
            FarZ = zf;
            NearWindowHeight = 2f * NearZ * (float)Math.Tan(0.5f * FovY);
            FarWindowHeight = 2f * FarZ * (float)Math.Tan(0.5f * FovY);
            base.Proj = Matrix.PerspectiveFovLH(FovY, Aspect, NearZ, FarZ);
        }

        public void Strafe(float d)
        {
            Position += Right * d;
        }

        public void UpdateViewMatrix()
        {
            Vector3 right = Right;
            Vector3 up = Up;
            Vector3 look = Look;
            Vector3 position = Position;
            look = Vector3.Normalize(look);
            up = Vector3.Normalize(Vector3.Cross(look, right));
            right = Vector3.Cross(up, look);
            float single = 0f - Vector3.Dot(position, right);
            float single2 = 0f - Vector3.Dot(position, up);
            float single3 = 0f - Vector3.Dot(position, look);
            Right = right;
            Up = up;
            Look = look;
            Matrix x = default(Matrix);
            x[0, 0] = Right.X;
            x[1, 0] = Right.Y;
            x[2, 0] = Right.Z;
            x[3, 0] = single;
            x[0, 1] = Up.X;
            x[1, 1] = Up.Y;
            x[2, 1] = Up.Z;
            x[3, 1] = single2;
            x[0, 2] = Look.X;
            x[1, 2] = Look.Y;
            x[2, 2] = Look.Z;
            x[3, 2] = single3;
            float single4 = 0f;
            x[2, 3] = single4;
            float single5 = (x[0, 3] = (x[1, 3] = single4));
            x[3, 3] = 1f;
            base.View = x;
            CameraFrustum = Frustum.FromViewProj(base.ViewProj);
        }

        public bool Visible(BoundingSphere BShpere)
        {
            if (CameraFrustum.Intersect(BShpere) > 0)
            {
                return true;
            }
            return false;
        }

        public bool Visible(BoundingBox BBox)
        {
            if (CameraFrustum.Intersect(BBox) > 0)
            {
                return true;
            }
            return false;
        }

        public void Walk(float d)
        {
            Position += Look * d;
        }

        public void Yaw(float angle)
        {
            Matrix matrix = Matrix.RotationY(0f - angle);
            Right = Vector3.TransformNormal(Right, matrix);
            Up = Vector3.TransformNormal(Up, matrix);
            Look = Vector3.TransformNormal(Look, matrix);
        }
    }
}
