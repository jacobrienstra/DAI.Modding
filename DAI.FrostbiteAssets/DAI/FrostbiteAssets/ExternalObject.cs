using DAI.AssetLibrary.Assets.Bases;

namespace DAI.FrostbiteAssets
{
	public class ExternalObject<T> where T : FrostbiteAssetBase
	{
		private T _ExtObj;

		private bool _ObjIsSet;

		public ExternalGuid Id { get; set; }

		public ExternalObject(T extObj)
		{
			_ExtObj = extObj;
			_ObjIsSet = true;
			Id = extObj.Id;
		}

		public ExternalObject(ExternalGuid id)
		{
			_ExtObj = null;
			Id = id;
		}

		public ExternalObject(ExternalGuid id, T extObj)
			: this(id, extObj, true)
		{
		}

		internal ExternalObject(ExternalGuid id, T extObj, bool isSet)
		{
			_ExtObj = extObj;
			_ObjIsSet = isSet;
			Id = id;
		}

		public T GetObject(AssetContainer container)
		{
			if (!_ObjIsSet)
			{
				_ObjIsSet = true;
				_ExtObj = (T)FrostbiteAssetFactory.CreateObjectFromGuid(container, Id);
			}
			return _ExtObj;
		}
	}
}
