using System;

namespace DAI.AssetLibrary.Assets.Bases
{
	public class ExternalGuid
	{
		public Guid FileGuid;

		public Guid InstanceGuid;

		public ExternalGuid(Guid InGuid1, Guid InGuid2)
		{
			FileGuid = InGuid1;
			InstanceGuid = InGuid2;
		}
	}
}
