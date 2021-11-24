using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace OWASP.WebGoat.NET.App_Code
{
    public static class FileValidator
    {

        public static void ValidateFile(string filePath)
        {
            string fileContents;

            using (StreamReader sr = new StreamReader(filePath))
            {
                fileContents = sr.ReadToEnd();
            }
            Regex regex = new Regex("^[\\s\\da-zA-Z]+$");

            if (!regex.IsMatch(fileContents))
                throw new FileValidatorInvalidFileException("File at " + filePath + " is not a valid text file!");

        }

        [Serializable]
        public class FileValidatorInvalidFileException : Exception
        {
            public FileValidatorInvalidFileException(string message) : base(message) { }

            public FileValidatorInvalidFileException(string message, Exception innerException) : base(message, innerException) { }

            public FileValidatorInvalidFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        }
    }
}