﻿using Microsoft.Practices.ServiceLocation;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extensions;
using OpenCBS.Payroll.CommandData;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;using OpenCBS.ExceptionsHandler;using OpenCBS.ExceptionsHandler;using OpenCBS.ExceptionsHandler;using OpenCBS.ExceptionsHandler;

namespace OpenCBS.Payroll.Menu
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IMenu))]
    public class LeaveMenu : IMenu
    {
        /*public LeaveMenu(IApplicationController applicationController)
        {
            MefContainer.Current.Bind(this);            
        }*/

        public LeaveMenu()
        {
            MefContainer.Current.Bind(this);
        }

        public string InsertAfter
        {
            get { return "PayrollToolStripSeparator"; }
        }

        public string InsertInto
        {
            get { return "mnuPayroll"; }
        }

        public bool IsFirstMenuItem
        {
            get
            {
                return true;
            }
        }

        public ToolStripMenuItem GetItem()
        {
            var result = new ToolStripMenuItem { Name = "mnuLeaveApplication", Text = "Leave Application" };
            result.Click += (sender, args) =>
            {
                var appController = ServiceLocator.Current.GetInstance<IApplicationController>();
                if (appController != null)
                {
                    //appController.Subscribe<AlertsHiddenMessage>(this, OnAlertsHidden);
                    appController.Execute(new ShowLeaveApplicationCommandData());
                }
            };
            return result;
        }        
    }
}