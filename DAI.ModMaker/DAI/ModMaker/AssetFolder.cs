using System;
using System.Collections.Generic;

namespace DAI.ModMaker
{
    public class AssetFolder
    {
        public string Name;

        public string Path;

        public List<int> Children;

        public List<Guid> Assets;

        public AssetFolder()
        {
            Children = new List<int>();
            Assets = new List<Guid>();
        }
    }
}
