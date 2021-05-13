using SlimDX;

namespace DAI.ModMaker.DAIRender
{
	public struct Vertex
	{
		public const int Stride = 44;

		public Vector3 Position;

		public Vector3 Normal;

		public Vector3 Tangent;

		public Vector2 TexCoord;

		public Vertex(Vector3 InPos, Vector3 InNormal, Vector3 InTangent, Vector2 InTexCoord)
		{
			Position = InPos;
			Normal = InNormal;
			Tangent = InTangent;
			TexCoord = InTexCoord;
		}
	}
}
