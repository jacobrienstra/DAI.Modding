using SlimDX;

namespace DAI.ModMaker.DAIRender
{
	public class Camera
	{
		public Matrix Proj { get; protected set; }

		public Matrix View { get; protected set; }

		public Matrix ViewProj => View * Proj;
	}
}
