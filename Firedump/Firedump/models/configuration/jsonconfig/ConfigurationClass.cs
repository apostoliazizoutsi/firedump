﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.configuration
{
    public interface ConfigurationClass
    {
        void initializeConfig();
        void createConfig();
        void saveConfig();
    }
}