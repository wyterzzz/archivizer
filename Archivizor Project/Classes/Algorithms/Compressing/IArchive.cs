using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace Archivizor_Project.Classes.Algorithms.Compressing
{
    public interface IArchive
    {
        void ExtractArchive(String archivePath, String destinationPath);

        void GenerateArchive(String archivePath);

        void Add(String itemPath);

        void AddRange(String[] itemsPaths);

        void AddRange(List<String> itemsPaths);
    }
}
