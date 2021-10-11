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


   
            makeFile();
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

                void makeFile()
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

            }
        }
    } 
