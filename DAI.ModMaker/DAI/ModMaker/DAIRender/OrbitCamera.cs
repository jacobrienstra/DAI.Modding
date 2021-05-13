using System;
using SlimDX;

namespace DAI.ModMaker.DAIRender
{
	public class OrbitCamera : Camera
	{
		private Vector3 eye;

		private Vector3 target;

		private Vector3 up;

		private float rotY;

		private float rotOrtho;

		public OrbitCamera()
		{
			eye = new Vector3(4f, 2f, 0f);
			target = new Vector3(0f, 0f, 0f);
			up = new Vector3(0f, 1f, 0f);
			SetView(eye, target, up);
			base.Proj = Matrix.PerspectiveFovLH((float)Math.PI / 4f, 1.3f, 0f, 1f);
		}

		public void RotateOrtho(int value)
		{
			Vector3 axis = Vector3.Cross(target - eye, up);
			rotOrtho = (float)value / 100f;
			Matrix matrix = Matrix.RotationAxis(axis, rotOrtho);
			Vector3 vector32 = eye - target;
			vector32 = Vector3.TransformCoordinate(vector32, matrix);
			Vector3 vector33 = vector32 + target;
			Vector3 vector34 = target - vector33;
			float single = Vector3.Dot(vector34, up) / (vector34.Length() * up.Length());
			if (single < 0.9f && single > -0.9f)
			{
				eye = vector32 + target;
				SetView(eye, target, up);
			}
		}

		public void RotateY(int value)
		{
			rotY = (float)value / 100f;
			Matrix matrix = Matrix.RotationY(rotY);
			eye = Vector3.TransformCoordinate(eye, matrix);
			SetView(eye, target, up);
		}

		public void SetPerspective(float fov, float aspect, float znear, float zfar)
		{
			base.Proj = Matrix.PerspectiveFovLH(fov, aspect, znear, zfar);
		}

		public void SetView(Vector3 eye, Vector3 target, Vector3 up)
		{
			Matrix m31 = Matrix.LookAtLH(eye, target, up);
			m31.M31 = 0f - m31.M31;
			m31.M32 = 0f - m31.M32;
			m31.M33 = 0f - m31.M33;
			m31.M34 = 0f - m31.M34;
			base.View = m31;
		}

		public void Zoom(int value)
		{
			float num = ((value <= 0) ? 0.9f : 1.1f);
			Matrix matrix = Matrix.Scaling(num, num, num);
			eye = Vector3.TransformCoordinate(eye, matrix);
			SetView(eye, target, up);
		}
	}
}
