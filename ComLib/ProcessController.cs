using System.Diagnostics;

namespace ComLib
{
    public class ProcessController
    {
        public bool Start(string targetPath, string arguments = null)
        {
            try
            {
                Process.Start(targetPath, arguments);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
