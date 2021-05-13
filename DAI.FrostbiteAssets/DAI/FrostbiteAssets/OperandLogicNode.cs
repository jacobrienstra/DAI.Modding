using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class OperandLogicNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public UISimpleDataSource LeftDataSourceInfo { get; set; }

		[FieldOffset(28, 80)]
		public UILogicOperator Operator { get; set; }

		[FieldOffset(32, 88)]
		public UISimpleDataSource RightDataSourceInfo { get; set; }

		[FieldOffset(40, 104)]
		public double RightLiteralOperand { get; set; }

		[FieldOffset(48, 112)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(52, 120)]
		public ExternalObject<UINodePort> True { get; set; }

		[FieldOffset(56, 128)]
		public ExternalObject<UINodePort> False { get; set; }
	}
}
