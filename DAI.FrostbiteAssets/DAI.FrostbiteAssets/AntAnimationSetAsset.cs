using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class AntAnimationSetAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<SkeletonAsset> SkeletonAsset { get; set; }

		[FieldOffset(16, 80)]
		public long AssetBankResource { get; set; }

		[FieldOffset(24, 88)]
		public int ActorAssetIndex { get; set; }

		[FieldOffset(28, 96)]
		public List<int> ClipAssetIndices { get; set; }

		[FieldOffset(32, 104)]
		public List<int> LoopingClipAssetIndices { get; set; }

		[FieldOffset(36, 112)]
		public int SceneOpMatrixAssetIndex { get; set; }

		[FieldOffset(40, 116)]
		public bool UseTraj2Ref { get; set; }

		[FieldOffset(41, 117)]
		public bool AllowAnimationCulling { get; set; }

		public AntAnimationSetAsset()
		{
			ClipAssetIndices = new List<int>();
			LoopingClipAssetIndices = new List<int>();
		}
	}
}
