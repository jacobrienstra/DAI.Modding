using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GamePhysicsComponentData : PhysicsComponentData
	{
		[FieldOffset(96, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(100, 200)]
		public List<ExternalObject<Dummy>> EffectParameters { get; set; }

		public GamePhysicsComponentData()
		{
			EffectParameters = new List<ExternalObject<Dummy>>();
		}
	}
}
