// Copyright (c) 2011, Outercurve Foundation.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// - Redistributions of source code must  retain  the  above copyright notice, this
//   list of conditions and the following disclaimer.
//
// - Redistributions in binary form  must  reproduce the  above  copyright  notice,
//   this list of conditions  and  the  following  disclaimer in  the documentation
//   and/or other materials provided with the distribution.
//
// - Neither  the  name  of  the  Outercurve Foundation  nor   the   names  of  its
//   contributors may be used to endorse or  promote  products  derived  from  this
//   software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  BUT  NOT  LIMITED TO, THE IMPLIED
// WARRANTIES  OF  MERCHANTABILITY   AND  FITNESS  FOR  A  PARTICULAR  PURPOSE  ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL,  SPECIAL,  EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO,  PROCUREMENT  OF  SUBSTITUTE  GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)  HOWEVER  CAUSED AND ON
// ANY  THEORY  OF  LIABILITY,  WHETHER  IN  CONTRACT,  STRICT  LIABILITY,  OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE)  ARISING  IN  ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

﻿using System;
using WebsitePanel.EnterpriseServer;
using WebsitePanel.Providers.ResultObjects;
using WebsitePanel.Providers.HostedSolution;

namespace WebsitePanel.Portal.Lync
{
    public partial class EditLyncUser : WebsitePanelModuleBase
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindItems();

        }

        private void BindItems()
        {
            // get settings
            LyncUser lyncUser = ES.Services.Lync.GetLyncUserGeneralSettings(PanelRequest.ItemID, PanelRequest.AccountID);

            // title
            litDisplayName.Text = lyncUser.DisplayName;

            planSelector.planId = lyncUser.LyncUserPlanId.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            try
            {
                LyncUserResult res =  ES.Services.Lync.SetUserLyncPlan(PanelRequest.ItemID, PanelRequest.AccountID, Convert.ToInt32(planSelector.planId));
                if (res.IsSuccess && res.ErrorCodes.Count == 0)
                {
                    messageBox.ShowSuccessMessage("UPDATE_LYNC_USER");
                    return;
                }
            }
            catch(Exception ex)
            {
                messageBox.ShowErrorMessage("UPDATE_LYNC_USER", ex);
            }
        }
    }
}