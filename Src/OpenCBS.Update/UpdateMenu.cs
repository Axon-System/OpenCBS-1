﻿using OpenCBS.Update.Interface.Service;
using OpenCBS.Update.Service;
using OpenCBS.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCBS.Update
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IMenu))]
    public class UpdateMenu : IMenu
    {
        private IUpdateService UpdateService = new DefaultUpdateService();

        public UpdateMenu(/*IApplicationUpdateService updateService*/)
        {
            MefContainer.Current.Bind(this);
//            UpdateService = updateService;
        }       

        public string InsertAfter
        {
            get { return /*"contactMenuItem"*/"helpToolStripSeparator"; }            
        }

        public string Parent
        {
            get
            {
                return "mnuHelp";
            }
        }

        public int Index
        {
            get
            {
                return 100;
            }
        }

        public ToolStripMenuItem GetItem()
        {
            var result = new ToolStripMenuItem { Text = "Check for Update" };
            result.Click += (sender, args) =>
            {
                UpdateService.CheckForUpdate();
            };
            return result;
        }        
    }
}
