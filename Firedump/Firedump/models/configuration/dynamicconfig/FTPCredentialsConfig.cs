﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration.dynamicconfig
{
    class FTPCredentialsConfig : LocationCredentialsConfig
    {
        public string hostname { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        /// <summary>
        /// Default value = 3306
        /// </summary>
        public int port { set; get; } = 3306;
        public bool useSFTP { set; get; }
        public string SshHostKeyFingerprint { set; get; } = "ssh-rsa 2048 xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx:xx";
        /// <summary>
        /// Use private key for SFTP login (useSFTP must be true or this is disregarded)
        /// If used privateKeyPath must also be set
        /// </summary>
        public bool usePrivateKey { set; get; }
        /// <summary>
        /// The path to the private key file
        /// </summary>
        public string privateKeyPath { set; get; }
    }
}