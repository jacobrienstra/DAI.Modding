using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3PresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public string CommunicationId { get; set; }

		[FieldOffset(24, 96)]
		public string CommunicationSignature { get; set; }

		[FieldOffset(28, 104)]
		public List<Ps3SkuSettings> SkuSettings { get; set; }

		[FieldOffset(32, 112)]
		public List<Ps3ParentalLockAgeSettings> ParentalLockAgeSettings { get; set; }

		public Ps3PresenceBackendData()
		{
			SkuSettings = new List<Ps3SkuSettings>();
			ParentalLockAgeSettings = new List<Ps3ParentalLockAgeSettings>();
		}
	}
}
