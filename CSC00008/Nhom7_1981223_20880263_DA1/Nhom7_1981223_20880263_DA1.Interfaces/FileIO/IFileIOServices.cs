using System;
namespace Nhom7_1981223_20880263_DA1.Interfaces.FileIO
{
    public interface IFileIOServices
    {
        string GetUrlFile(string fileName);
        string[] GetArrayUrl(string key);
        string[] GetArrayUrlFileFromPath(string path);
    }
}
