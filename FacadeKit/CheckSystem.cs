using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FacadeKit
{
    internal class CheckSystem
    {
        public void Check()
        {
            Console.WriteLine("CheckSystem: Checking target...");
        }

        public void UploadCheckingResult()
        {
            Console.WriteLine("CheckSystem: Uploading checking result...");
        }

    }
}
