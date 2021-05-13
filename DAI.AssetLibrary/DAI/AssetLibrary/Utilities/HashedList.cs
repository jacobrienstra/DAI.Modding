using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DAI.AssetLibrary.Utilities
{
	public class HashedList<T> : KeyedCollection<T, T>
	{
		protected override T GetKeyForItem(T item)
		{
			return item;
		}

		public int RemoveAll(Predicate<T> match)
		{
			int cnt = 0;
			T[] array = this.ToArray();
			foreach (T entry in array)
			{
				if (match(entry))
				{
					Remove(entry);
					cnt++;
				}
			}
			return cnt;
		}
	}
}
