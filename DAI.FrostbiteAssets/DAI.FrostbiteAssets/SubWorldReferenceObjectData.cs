using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SubWorldReferenceObjectData : ReferenceObjectData
	{
		[FieldOffset(112, 240)]
		public string BundleName { get; set; }

		[FieldOffset(116, 248)]
		public BlueprintPersistenceSetting PersistenceSetting { get; set; }

		[FieldOffset(120, 256)]
		public ExternalObject<Dummy> InclusionSettings { get; set; }

		[FieldOffset(124, 264)]
		public bool AutoLoad { get; set; }

		[FieldOffset(125, 265)]
		public bool IsWin32SubLevel { get; set; }

		[FieldOffset(126, 266)]
		public bool IsXenonSubLevel { get; set; }

		[FieldOffset(127, 267)]
		public bool IsPs3SubLevel { get; set; }

		[FieldOffset(128, 268)]
		public bool IsGen4aSubLevel { get; set; }

		[FieldOffset(129, 269)]
		public bool IsGen4bSubLevel { get; set; }

		[FieldOffset(130, 270)]
		public bool IsIOSSubLevel { get; set; }

		[FieldOffset(131, 271)]
		public bool IsAndroidSubLevel { get; set; }

		[FieldOffset(132, 272)]
		public bool IsOSXSubLevel { get; set; }
	}
}
