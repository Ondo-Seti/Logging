﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ondo.Logging.ConsoleApp
{
    public class LoggingEvents
    {
        public const int EXAMPLE = 100;

        public const int GENERATE_ITEMS = 1000;
        public const int LIST_ITEMS = 1001;
        public const int GET_ITEM = 1002;
        public const int INSERT_ITEM = 1003;
        public const int UPDATE_ITEM = 1004;
        public const int DELETE_ITEM = 1005;

        public const int GET_ITEM_NOTFOUND = 4000;
        public const int UPDATE_ITEM_NOTFOUND = 4001;

    }
}
