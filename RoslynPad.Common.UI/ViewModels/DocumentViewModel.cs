using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using RoslynPad.Utilities;

namespace RoslynPad.UI
{
    [DebuggerDisplay("{Name}:{IsFolder}")]
    public class DocumentViewModel : NotificationObject
    {
        internal const string DefaultFileExtension = ".cs";

        private string _path;
        private string _name;
        private string _originalName;

#pragma warning disable CS8618 // Non-nullable field is uninitialized.
        private DocumentViewModel(string path)
#pragma warning restore CS8618 // Non-nullable field is uninitialized.
        {
            Path = path;

        }

        public void ChangePath(string newPath)
        {
            Path = newPath;

        }

        public string Path
        {
            get => _path;
            private set
            {

                if (SetProperty(ref _path, value))
                {
                    OriginalName = System.IO.Path.GetFileName(value);
                }
            }
        }



        public string GetSavePath()
        {
            return Path;
        }

        public static DocumentViewModel FromPath(string path)
        {
            return new DocumentViewModel(path);
        }


        public static string GetDocumentPathFromName(string path, string name)
        {
            if (!name.EndsWith(DefaultFileExtension, StringComparison.OrdinalIgnoreCase))
            {
                name += DefaultFileExtension;
            }

            return System.IO.Path.Combine(path, name);
        }

        internal string OriginalName
        {
            get => _originalName;
            private set
            {
                _originalName = value;
                Name = System.IO.Path.GetFileNameWithoutExtension(value);
            }
        }

        public string Name
        {
            get => _name;
            private set => SetProperty(ref _name, value);
        }


    }
}
