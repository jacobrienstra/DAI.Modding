using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIScreenRenderEntityData : LogicReferenceObjectData
	{
		[FieldOffset(128, 256)]
		public ExternalObject<UICppScreenData> ScreenData { get; set; }

		[FieldOffset(132, 264)]
		public float Scale { get; set; }

		[FieldOffset(136, 268)]
		public UIScreenProjectionMode ProjectionMode { get; set; }

		[FieldOffset(140, 272)]
		public UIScreenRenderingPass RenderPass { get; set; }

		[FieldOffset(144, 276)]
		public int UpdateOrder { get; set; }

		[FieldOffset(148, 280)]
		public int RenderToRootView { get; set; }

		[FieldOffset(152, 288)]
		public List<Dummy> InputEvents { get; set; }

		[FieldOffset(156, 296)]
		public List<Dummy> OutputEvents { get; set; }

		[FieldOffset(160, 304)]
		public List<Dummy> InputFloatProperties { get; set; }

		[FieldOffset(164, 312)]
		public List<Dummy> InputIntProperties { get; set; }

		[FieldOffset(168, 320)]
		public List<Dummy> InputBoolProperties { get; set; }

		[FieldOffset(172, 328)]
		public List<Dummy> InputStringProperties { get; set; }

		[FieldOffset(176, 336)]
		public List<Dummy> InputTransformProperties { get; set; }

		[FieldOffset(180, 344)]
		public List<Dummy> InputVec3Properties { get; set; }

		[FieldOffset(184, 352)]
		public List<Dummy> InputVec4Properties { get; set; }

		[FieldOffset(188, 360)]
		public bool UseGameViewProjection { get; set; }

		[FieldOffset(189, 361)]
		public bool EnableDepthCulling { get; set; }

		[FieldOffset(190, 362)]
		public bool CenterScreen { get; set; }

		public UIScreenRenderEntityData()
		{
			InputEvents = new List<Dummy>();
			OutputEvents = new List<Dummy>();
			InputFloatProperties = new List<Dummy>();
			InputIntProperties = new List<Dummy>();
			InputBoolProperties = new List<Dummy>();
			InputStringProperties = new List<Dummy>();
			InputTransformProperties = new List<Dummy>();
			InputVec3Properties = new List<Dummy>();
			InputVec4Properties = new List<Dummy>();
		}
	}
}
