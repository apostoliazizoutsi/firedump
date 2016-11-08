﻿using Firedump.models.configuration.jsonconfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class Compression
    {
        ConfigurationManager configurationManagerInstance = ConfigurationManager.getInstance();
        private Process proc;
        private IAdapterListener listener;

        /// <summary>
        /// Absolute path of the file to compress
        /// </summary>
        public string absolutePath { set; get; }

        public Compression() { }

        public Compression(string absolutePath)
        {
            this.absolutePath = absolutePath;
        }

        public Compression(IAdapterListener listener)
        {
            this.listener = listener;
        }

        public CompressionResultSet doCompress7z()
        {
            string fileType;

            StringBuilder arguments = new StringBuilder();
            arguments.Append("a -bsp1 ");

            //security
            if (configurationManagerInstance.compressConfigInstance.enablePasswordEncryption)
            {
                if (configurationManagerInstance.compressConfigInstance.encryptHeader)
                {
                    arguments.Append("-mhe=on ");
                }
                if (!string.IsNullOrEmpty(configurationManagerInstance.compressConfigInstance.password))
                {
                    if (configurationManagerInstance.compressConfigInstance.fileType != 0)
                    {
                        arguments.Append("-mem=AES256 ");
                    }
                    arguments.Append("-p" + configurationManagerInstance.compressConfigInstance.password + " ");
                }
            }

            //compression level
            switch (configurationManagerInstance.compressConfigInstance.compressionLevel)
            {
                case 0:
                    arguments.Append("-mx1 ");
                    break;
                case 1:
                    arguments.Append("-mx3 ");
                    break;
                case 2:
                    arguments.Append("-mx5 ");
                    break;
                case 3:
                    arguments.Append("-mx7 ");
                    break;
                case 4:
                    arguments.Append("-mx9 ");
                    break;
                default:
                    arguments.Append("-mx9 ");
                    break;
            }

            //enable multithreading
            if (configurationManagerInstance.compressConfigInstance.useMultithreading)
            {
                arguments.Append("-mmt ");
            }

            //filetype
            switch (configurationManagerInstance.compressConfigInstance.fileType)
            {
                case 0:
                    arguments.Append("-t7z ");
                    fileType = ".7z";
                    break;
                case 1:
                    arguments.Append("-tgzip ");
                    fileType = ".gzip";
                    break;
                case 2:
                    arguments.Append("-tzip ");
                    fileType = ".zip";
                    break;
                case 3:
                    arguments.Append("-tbzip2 ");
                    fileType = ".bzip2";
                    break;
                case 4:
                    arguments.Append("-ttar ");
                    fileType = ".tar";
                    break;
                case 5:
                    arguments.Append("-tiso ");
                    fileType = ".iso";
                    break;
                case 6:
                    arguments.Append("-tudf ");
                    fileType = ".udf";
                    break;
                default:
                    arguments.Append("-tzip ");
                    fileType = ".zip";
                    break;
            }


            string f7zip = "resources\\7z64\\7z.exe";
            if (configurationManagerInstance.compressConfigInstance.use32bit)
            {
                f7zip = "resources\\7z\\7z.exe"; 
            }

            //setting filenames
            if (configurationManagerInstance.mysqlDumpConfigInstance.xml)
            {
                arguments.Append("\"" + absolutePath.Replace(".xml", fileType) + "\" ");
            }
            else
            {
                arguments.Append("\"" + absolutePath.Replace(".sql", fileType) + "\" ");
            }
            
            arguments.Append("\""+absolutePath+"\"");

            Console.WriteLine("Compression7z arguments: "+arguments.ToString());
            
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = f7zip,
                    Arguments = arguments.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true, //prepei na diavastoun me ti seira pou ginonte ta redirect alliws kolaei se endless loop
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            Console.WriteLine("Executing 7zip now.");
            CompressionResultSet result = new CompressionResultSet();
            proc.Start();

            if(listener != null)
            {
                listener.onCompressStart();
            }

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Console.WriteLine("Comp:"+line);
                
                if(listener != null)
                {
                    if (line.Contains("%"))
                    {
                        int per = 0;
                        int.TryParse(line.Substring(0, 3), out per);
                        //Console.WriteLine("per:" + per);
                        listener.compressProgress(per);
                    }
                }
                
            }

            while (!proc.StandardError.EndOfStream)
            {
                string line = proc.StandardError.ReadLine();
                result.standardError += line + "\n";
                Console.WriteLine(line);
            }

            proc.WaitForExit();

            if(proc.ExitCode!=0)
            {
                result.wasSucessful = false;
            }
            else
            {
                result.wasSucessful = true;
            }

            result.resultAbsPath = absolutePath.Replace(".sql", fileType);

            return result;
        }


        public void KillProc()
        {
            try
            {
                proc.Kill();
                proc.Close();
                proc = null;
            } catch(Exception ex)
            {

            }
        }


    }
}