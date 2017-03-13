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

using OpenCBS.CoreDomain.Accounting;
using OpenCBS.Shared;


namespace OpenCBS.CoreDomain
{
    public class Teller
    {
        private int? _id;
        public int? Id
        {
            get { return _id == 0 ? null : _id; }
            set { _id = value; }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
        public bool Deleted { get; set; }
        public Branch Branch { get; set; }
        public OCurrency MinAmountTeller { get; set; }
        public OCurrency MaxAmountTeller { get; set; }
        public OCurrency MinAmountWithdrawal { get; set; }
        public OCurrency MaxAmountWithdrawal { get; set; }
        public OCurrency MinAmountDeposit { get; set; }
        public OCurrency MaxAmountDeposit { get; set; }
        public Currency Currency { get; set; }
        public User User { get; set; }

        public Teller Vault;

        private static Teller _currentTeller = new Teller();

        static public Teller CurrentTeller
        {
            get { return _currentTeller; }
            set { _currentTeller = value; }
        }

        public OCurrency CashInTill { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
