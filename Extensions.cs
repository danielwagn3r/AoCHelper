using System;
using System.IO;
using System.Threading.Tasks;

namespace AoCHelper
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return String.IsNullOrEmpty(input);
        }

        public static async Task<string> ReadAllTextAsync(this FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
            {
                return String.Empty;
            }

            try
            {
                return await File.ReadAllTextAsync(fileInfo.FullName);
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        public static async Task<FileInfo> WriteAllTextAsync(this FileInfo fileInfo, string content)
        {
            await File.WriteAllTextAsync(fileInfo.FullName, content);
            return fileInfo;
        }

        public static FileInfo GetFileInfo(this DirectoryInfo directoryInfo, string fileName)
        {
            return new FileInfo(Path.Combine(directoryInfo.FullName, fileName));
        }
    }
}