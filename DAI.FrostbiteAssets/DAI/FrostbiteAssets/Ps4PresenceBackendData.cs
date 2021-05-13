using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps4PresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public Ps4TitleData DefaultTitleData { get; set; }

		[FieldOffset(32, 120)]
		public List<Ps4TitleData> TitleData { get; set; }

		[FieldOffset(36, 128)]
		public Ps4AgeSettings AgeSettings { get; set; }

		[FieldOffset(48, 152)]
		public List<Ps4CaCertificate> Certificates { get; set; }

		[FieldOffset(52, 160)]
		public string CommunicationId { get; set; }

		[FieldOffset(56, 168)]
		public string CommunicationSignature { get; set; }

		[FieldOffset(60, 176)]
		public string CommunicationPassphrase { get; set; }

		public Ps4PresenceBackendData()
		{
			TitleData = new List<Ps4TitleData>();
			Certificates = new List<Ps4CaCertificate>();
		}
	}
}
