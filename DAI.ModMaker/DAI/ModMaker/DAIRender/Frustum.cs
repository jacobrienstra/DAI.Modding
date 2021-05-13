using SlimDX;

namespace DAI.ModMaker.DAIRender
{
	public class Frustum
	{
		private readonly Plane[] InternalFrustum;

		public Frustum(Matrix ViewProj)
		{
			Plane[] plane = (InternalFrustum = new Plane[6]
			{
				new Plane(ViewProj.M14 + ViewProj.M11, ViewProj.M24 + ViewProj.M21, ViewProj.M34 + ViewProj.M31, ViewProj.M44 + ViewProj.M41),
				new Plane(ViewProj.M14 - ViewProj.M11, ViewProj.M24 - ViewProj.M21, ViewProj.M34 - ViewProj.M31, ViewProj.M44 - ViewProj.M41),
				new Plane(ViewProj.M14 + ViewProj.M12, ViewProj.M24 + ViewProj.M22, ViewProj.M34 + ViewProj.M32, ViewProj.M44 + ViewProj.M42),
				new Plane(ViewProj.M14 - ViewProj.M12, ViewProj.M24 - ViewProj.M22, ViewProj.M34 - ViewProj.M32, ViewProj.M44 - ViewProj.M42),
				new Plane(ViewProj.M13, ViewProj.M23, ViewProj.M33, ViewProj.M43),
				new Plane(ViewProj.M14 - ViewProj.M13, ViewProj.M24 - ViewProj.M23, ViewProj.M34 - ViewProj.M33, ViewProj.M44 - ViewProj.M43)
			});
			for (int i = 0; i < 6; i++)
			{
				InternalFrustum[i].Normalize();
			}
		}

		public static Frustum FromViewProj(Matrix ViewProj)
		{
			return new Frustum(ViewProj);
		}

		public int Intersect(BoundingSphere Sphere)
		{
			for (int i = 0; i < 6; i++)
			{
				if (Plane.DotCoordinate(InternalFrustum[i], Sphere.Center) + Sphere.Radius < 0f)
				{
					return 0;
				}
			}
			return 1;
		}

		public int Intersect(BoundingBox Box)
		{
			int num = 0;
			for (int i = 0; i < 6; i++)
			{
				switch (Plane.Intersects(InternalFrustum[i], Box))
				{
				case PlaneIntersectionType.Back:
					return 0;
				case PlaneIntersectionType.Front:
					num++;
					break;
				}
			}
			if (num == 6)
			{
				return 2;
			}
			return 1;
		}
	}
}
