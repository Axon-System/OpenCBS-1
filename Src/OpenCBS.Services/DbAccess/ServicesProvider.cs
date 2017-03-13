﻿// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using OpenCBS.CoreDomain;
using OpenCBS.Shared.Settings;

namespace OpenCBS.Services
{
    public class ServicesProvider
    {
        private IServices _iServices;
        private static ServicesProvider _theUniqueInstance;

        private ServicesProvider()
        {
            if (TechnicalSettings.UseOnlineMode)
                _iServices = Remoting.GetInstance();
            else
                _iServices = new Standard();
        }

        public static IServices GetInstance()
        {
            if (_theUniqueInstance == null)
                _theUniqueInstance = new ServicesProvider();

            return _theUniqueInstance._iServices;
        }

        public static IServices GetInstance(string connectionString)
        {
            if (_theUniqueInstance == null)
                _theUniqueInstance = new ServicesProvider();

            return _theUniqueInstance._iServices;
        }

        public static ServicesProvider GetServiceProvider()
        {
            if (_theUniqueInstance == null)
                return _theUniqueInstance = new ServicesProvider();
            return _theUniqueInstance;
        }

        static bool _status = false;
        
        public void InitOnlineConnection(string pUserName, string pUserPass, string pDbName, string pComputerName, string pLoginName)
        {
            if (TechnicalSettings.UseOnlineMode && _status == false)
            {
                ((Remoting)_iServices).UserName = pUserName;
                ((Remoting)_iServices).Pass = pUserPass;
                ((Remoting)_iServices).Account = pDbName;

                User.CurrentUser.Md5 = _iServices.GetAuthentification(pUserName, 
                                                                        pUserPass, 
                                                                        pDbName, 
                                                                        pComputerName, 
                                                                        pLoginName);
                _iServices.RunTimeout();

                _status = true;
            }
        }
    }
}
