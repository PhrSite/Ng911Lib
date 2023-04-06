/////////////////////////////////////////////////////////////////////////////////////
//  File: Utils.cs                                                  9 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////


namespace UnitTests
{
    internal class Utils
    {
        public static string GetRawData(string strPath, string strFileName)
        {
            string strFilePath = $"{strPath}{strFileName}";
            Assert.True(File.Exists(strFilePath), $"The {strFileName} input file was missing.");
            string strData = File.ReadAllText(strFilePath);
            return strData;
        }
    }
}
