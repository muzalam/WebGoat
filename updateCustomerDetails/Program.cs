using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace updateCustomerDetails
{
    class Program
    {
        static void Main(string[] args)
        {



            //makeFile();
            string test()
            {
                string[] lines = File.ReadAllLines("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin1.txt");


                string[] col = lines[0].Split('|');
                Array.Resize<string>(ref col, 6);
                //Console.WriteLine(col.Length);
                //Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])));
                byte[] data = Convert.FromBase64String(col[5]);

                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                HashWithSaltResult hashResultSha256 = pwHasher.HashWithSalt((col[2]), 64, SHA256.Create(), Encoding.UTF8.GetString(data));
                return hashResultSha256.Salt;

            }
            string test2()
            {
                string[] lines = File.ReadAllLines("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin.txt");

                string[] col = lines[0].Split('|');
                Array.Resize<string>(ref col, 6);
                //Console.WriteLine(col.Length);
                //Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])));
                PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                HashWithSaltResult hashResultSha256 = pwHasher.HashWithSalt(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])), 64, SHA256.Create());
                var salt = hashResultSha256.Salt;
                var digest = hashResultSha256.Digest;
                col[2] = digest;
                col[5] = salt;
                return salt;

            }

            void makeFilePhase1()
            {
                string[] lines = File.ReadAllLines("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin.txt");
                foreach (string line in lines)
                {
                    string[] col = line.Split('|');
                    Array.Resize<string>(ref col, 6);
                    //Console.WriteLine(col.Length);
                    //Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])));
                    PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                    HashWithSaltResult hashResultSha256 = pwHasher.HashWithSalt(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])), 64, SHA256.Create());
                    var salt = hashResultSha256.Salt;
                    var digest = hashResultSha256.Digest;
                    col[2] = digest;
                    col[5] = salt;
                    //byte[] data = Convert.FromBase64String(salt);
                    var hello = String.Join("|", col);
                    //Console.WriteLine(hello);
                    using (StreamWriter sw = File.AppendText("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin1.txt"))
                    {
                        sw.WriteLine(hello);

                    }

                    //File.AppendAllText("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin.txt", col);
                    // process col[0], col[1], col[2]
                }
            }
            byte[] CreateSalt()
            {
                var buffer = new byte[16];
                var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(buffer);
                return buffer;
            }

            byte[] HashPassword(string password, byte[] salt)
            {
                var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

                argon2.Salt = salt;
                argon2.DegreeOfParallelism = 8; // four cores
                argon2.Iterations = 4;
                argon2.MemorySize = 1024 * 1024; // 1 GB

                return argon2.GetBytes(16);
            }
            bool VerifyHash(string password, byte[] salt, byte[] hash)
            {
                var newHash = HashPassword(password, salt);
                return hash.SequenceEqual(newHash);
            }
            void makeFilePhase2()
            {
                string[] lines = File.ReadAllLines("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin1.txt");
                foreach (string line in lines)
                {
                    string[] col = line.Split('|');
                    Array.Resize<string>(ref col, 6);
                    //Console.WriteLine(col.Length);
                    //Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])));
                    //PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
                    //HashWithSaltResult hashResultSha256 = pwHasher.HashWithSalt(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])), 64, SHA256.Create());
                    //var salt = hashResultSha256.Salt;
                    //var digest = hashResultSha256.Digest;
                    //col[2] = digest;
                    //col[5] = salt;
                    //byte[] data = Convert.FromBase64String(salt);
                    var salt = CreateSalt();
                    var hash = HashPassword(Encoding.UTF8.GetString(Convert.FromBase64String(col[2])), salt);
                    col[2] = Convert.ToBase64String(salt);
                    col[5] = Convert.ToBase64String(hash);

                    var hello = String.Join("|", col);
                    Console.WriteLine(hello);
                    using (StreamWriter sw = File.AppendText("C:\\Users\\student\\Workspace\\WebGoat\\WebGoat\\DB_Scripts\\datafiles\\customerlogin.txt"))
                    {
                        sw.WriteLine(hello);

                    }
                }

            }
            makeFilePhase2();
        }
    }
} 
