using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StaticModelGroupEntityData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public List<StaticModelGroupMemberData> MemberDatas { get; set; }

		[FieldOffset(132, 248)]
		public uint NetworkIdCount { get; set; }

		[FieldOffset(136, 252)]
		public Guid HackToSolveRealTimeTweakingIssue { get; set; }

		public StaticModelGroupEntityData()
		{
			MemberDatas = new List<StaticModelGroupMemberData>();
		}
	}
}
