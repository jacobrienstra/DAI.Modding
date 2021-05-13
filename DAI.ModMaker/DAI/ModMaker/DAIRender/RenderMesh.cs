using SlimDX;
using SlimDX.Direct3D11;

namespace DAI.ModMaker.DAIRender
{
	public class RenderMesh
	{
		public Buffer VertexBuffer;

		public Buffer IndexBuffer;

		public Texture2D DiffuseTextureResource;

		public ShaderResourceView DiffuseTextureSRV;

		public Texture2D NormalTextureResource;

		public ShaderResourceView NormalTextureSRV;

		public int NumIndices;

		public bool IsHighlighted;

		public Vector4 TextureSlots;

		public Matrix World;

		public BoundingSphere BSphere;

		public Vector3 Center;

		public float Radius;

		public int MeshIndex;

		public bool IsVisible;

		public Vector3 Location => new Vector3(World.M41, World.M42, World.M43);

		public RenderMesh(RenderMesh B)
		{
			VertexBuffer = B.VertexBuffer;
			IndexBuffer = B.IndexBuffer;
			DiffuseTextureResource = B.DiffuseTextureResource;
			DiffuseTextureSRV = B.DiffuseTextureSRV;
			NormalTextureResource = B.NormalTextureResource;
			NormalTextureSRV = B.NormalTextureSRV;
			NumIndices = B.NumIndices;
			TextureSlots = B.TextureSlots;
			Center = B.Center;
			Radius = B.Radius;
			MeshIndex = B.MeshIndex;
			IsVisible = true;
			BSphere = new BoundingSphere(Center, Radius);
		}

		public RenderMesh()
		{
		}
	}
}
