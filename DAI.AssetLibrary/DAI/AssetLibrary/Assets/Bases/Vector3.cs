namespace DAI.AssetLibrary.Assets.Bases
{
	public class Vector3
	{
		public float X;

		public float Y;

		public float Z;

		public Vector3(float inX, float inY, float inZ)
		{
			X = inX;
			Y = inY;
			Z = inZ;
		}

		public Vector3()
		{
			float single = 0f;
			Z = single;
			X = (Y = single);
		}

		public static Vector3 operator *(Vector3 A, float B)
		{
			A.X *= B;
			A.Y *= B;
			A.Z *= B;
			return A;
		}
	}
}
