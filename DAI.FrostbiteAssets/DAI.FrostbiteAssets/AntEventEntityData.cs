using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntEventEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<AntEventData> OnEnterEvents { get; set; }

		[FieldOffset(20, 104)]
		public List<AntEventData> OnUpdateEvents { get; set; }

		[FieldOffset(24, 112)]
		public List<AntEventData> OnLeaveEvents { get; set; }

		[FieldOffset(28, 120)]
		public bool RequireLink { get; set; }

		[FieldOffset(29, 121)]
		public bool SendAsPlayerEvent { get; set; }

		[FieldOffset(30, 122)]
		public bool AutoActivate { get; set; }

		public AntEventEntityData()
		{
			OnEnterEvents = new List<AntEventData>();
			OnUpdateEvents = new List<AntEventData>();
			OnLeaveEvents = new List<AntEventData>();
		}
	}
}
